using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class StageManager : Singleton<StageManager>
{

    [Header("진행")]
    public float shop_open_delay=3;
    [Space(50)]



    [Header("Slot")]//라운드 관련
    public int maxCardCenterSlot;
    public TMPro.TextMeshProUGUI SLOT_text_cur;
    public TMPro.TextMeshProUGUI SLOT_text_mx;


    [Header("Round")]//라운드 관련
    public int round = 1; //현제 라운드
    public UnityEvent OnRoundStart;
    public UnityEvent OnRoundCheck;
    public UnityEvent OnRoundCalculateFinoshed;
    public UnityEvent OnRoundEnd;
    public TMPro.TextMeshProUGUI round_text;
    [Space(50)]


    [Header("Score")] //점수체크 관련
    public int score;//
    public List<int> score_required; //요구 점수 
    public int score_check_round = 2; //몇라운드에 스테이지 변경 
    int score_check_index; //현제 라운드
    public TMPro.TextMeshProUGUI score_text;
    public TMPro.TextMeshProUGUI score_gola_text;
    [Space(50)]


    [Header("Shop")]//상점 관련
    public GameObject shop_panel;
    [Space(50)]


    [Header("Field")] //점수체크 관련
    public HorizontalCardHolder cards_hand;
    public HorizontalCardHolder cards_center;
    public GameObject Game_Defeat;//겜 패배 
    public GameObject Game_Win;//겜 패배 
    [Space(50)]
    
    

    [Header("Stage")]//스테이지 관련    
    public UnityEvent OnStageStart;
    public UnityEvent OnStageEnd;
    public TMPro.TextMeshProUGUI stage_text;
    [Space(50)]



    Card selectedCard;
    int Holder_Mouse_Entered;
    
    void Start()
    {
        shop_panel.active = false;
        Game_Defeat.active = false;


        Manager.Data.StartGame();
        OnRoundStart.Invoke();

        GoToShop();


        score_gola_text.text= score_required[score_check_index].ToString();
        SMGDebug.Log("[Start Stage] Start Time: " + Time.time);
    }
    private void Update()
    {
        SLOT_text_cur.text = cards_center.cards.Count.ToString(); //현재 카드 수 
        SLOT_text_mx.text = maxCardCenterSlot.ToString(); //최대 카드 수



        if (cards_hand.selectedCard != null)
            selectedCard = cards_hand.selectedCard;

        if (cards_center.selectedCard != null)
            selectedCard = cards_center.selectedCard;


        if (Input.GetMouseButtonUp(0))
        {
            TryCardHanToCenter();
            TryCardCenterToHand();
        }
    }
    public void RoundCheck() //from 버튼 
    {
        //배치카드 함수실행 
        OnRoundCheck.Invoke();

        //배치카드 계산
        for(int i = 0; i < cards_center.cards.Count; i++)
        {
            cards_center.cards[i].GetComponentInChildren<Card>().Execute();
        }   
        OnRoundCalculateFinoshed.Invoke();


        //카드 손으로 회수
        for (int i = 0; i < cards_center.cards.Count; i++)
        {
            //old
            cards_center.cards[i].PointerEnterEvent.RemoveAllListeners();
            cards_center.cards[i].BeginDragEvent.RemoveAllListeners();

            //new
            cards_center.cards[i].transform.parent.transform.parent = cards_hand.transform;
            cards_hand.AddCard(cards_center.cards[i]);
        }
        cards_center.cards.Clear();

        //시리얼 담는거 기다림
        StartCoroutine(WaitCrealAnimation());

    }
    IEnumerator WaitCrealAnimation()
    {
        Tag.Find(Tags.blockui).gameObject.SetActive(true);
        yield return new WaitForSeconds(shop_open_delay);
        Tag.Find(Tags.blockui).gameObject.SetActive(false);
        RoundWaiting();
    }

    public void RoundWaiting()
    {
        //점수갱신
        var objs = FindObjectsByType<Card>(FindObjectsSortMode.None);
        OnRoundEnd.Invoke();
        


        //점수계산
        if (round % score_check_round == 0) //3일경우 3 6 9라운드마다 ~~
        {         
            score_check_index++;


            if (score_required[score_check_index-1] > score) //패배            
                Game_Defeat.active = true;
            
            if(score_check_index== score_required.Count && score_required[score_check_index - 1] <= score)   //승리      
                Game_Win.active=true;


            score_gola_text.text = score_required[score_check_index].ToString();
        }
        SMGDebug.Log($"curRound : {round}" + $" score :{score}");



        GoToShop();
        RoundRenew(round + 1);//다음라운드 
        OnRoundStart.Invoke();

    }




    public void TryCardHanToCenter()
    {
        //배치 최대 제한
        if (cards_center.GetComponentsInChildren<Card>().Length >= maxCardCenterSlot)
            return;

        if (selectedCard == false)
            return;

        if (Holder_Mouse_Entered != 1)
            return;

        if (cards_center.cards.Contains(selectedCard))
            return;


        //old
        cards_hand.cards.Remove(selectedCard);
        selectedCard.PointerEnterEvent.RemoveAllListeners();
        selectedCard.BeginDragEvent.RemoveAllListeners();


        //new
        selectedCard.transform.parent.transform.parent = cards_center.transform;
        cards_center.AddCard(selectedCard);


        //end
        selectedCard = null;
    }

    void TryCardCenterToHand()
    {
        if (selectedCard == false)
            return;

        if (Holder_Mouse_Entered != 0)
            return;

        if (cards_hand.cards.Contains(selectedCard))
            return;


        //old
        cards_center.cards.Remove(selectedCard);
        selectedCard.PointerEnterEvent.RemoveAllListeners();
        selectedCard.BeginDragEvent.RemoveAllListeners();


        //new
        selectedCard.transform.parent.transform.parent = cards_hand.transform;
        cards_hand.AddCard(selectedCard);


        //end
        selectedCard = null;
    }

    void RoundRenew(int i) { round = i; if (round_text) round_text.text = round.ToString(); }
   public  void ScoreRenew(int i) { score = i; if (score_text) score_text.text = score.ToString(); }
    void StageRenew(int i) { score_check_index = i; if (stage_text) stage_text.text = score_check_index.ToString(); }
    public void GoToShop() { shop_panel.active = true; }
    public void NextStage() 
    {
        StageRenew(score_check_index);

        StartCoroutine(c());
        OnStageStart.Invoke(); 
    }
    public void StageEnd() { }
    public void CenterMouseEnter(int index) { Holder_Mouse_Entered = index; }
    public void CenterMouseEixt() { Holder_Mouse_Entered = -99; }
    IEnumerator c()
    {
        yield return new WaitForSeconds(0.7f);
        shop_panel.active = false; 
        OnStageEnd.Invoke();
    }

}


/*
    public int when_check_count;//몇라운드 마다 체크하는지 
        //selectedCard.GetComponentInChildren<Card>().enabled = false;
    public List<GameObject> placed_cards;
            //Stage_change_panel.active = true;
 
    public GameObject Score_Check_panel;//전환시 잠깐보여주는 용도

 */