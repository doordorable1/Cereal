
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;


public class HorizontalCardHolder : MonoBehaviour
{
    public int index;
    public Card selectedCard;
    public Card hoveredCard;

    public List< GameObject> slotPrefab;
    private RectTransform rect;

    [Header("Spawn Settings")]
    [SerializeField] private int cardsToSpawn = 7;
    public List<Card> cards;

    bool isCrossing = false;
    [SerializeField] private bool tweenCardReturn = true;


    //카드 레어도에 따른 리스트
    public List<int> rare_weight = new(); // 70 40 20 10 1  / 부분/전체 
    public List<GameObject> rare_Card = new(); // 70 40 20 10 1  / 부분/전체 

   
    private void OnEnable()
    {
        CardAllGenerate();
    }



    public void CardAllGenerate() 
    {
        for (int k = 0; k < cardsToSpawn; k++)
        {
            int total = 0;
            for (int i = 0; i < rare_weight.Count; i++)
            { total += rare_weight[i]; }
            int randomValue = Random.Range(0, total+1);


            //가중치 총합으로 티어계산   70 20 10 
            float currentWeight = 0f;
            int index = 1;
            for (int i = 0; i < rare_weight.Count; i++)
            {
                currentWeight += rare_weight[i];
                if (randomValue <= currentWeight)
                {
                    index = i + 1;
                    break;
                }
            }
            //Debug.Log(index);

            ////SO 정보전달
            //var selsected_SO = list1;
            //if (index == 2) selsected_SO = list2;
            //if (index == 3) selsected_SO = list3;
            //if (index == 4) selsected_SO = list4;
            //if (index == 5) selsected_SO = list5;


            //생성
            var v = Instantiate(rare_Card[index - 1], transform);
            v.transform.localPosition = Vector3.zero;
           // v.GetComponentInChildren<Card>().activeSO = selsected_SO[Random.Range(0, selsected_SO.Count - 1)];
        }






        rect = GetComponent<RectTransform>();
        cards = GetComponentsInChildren<Card>().ToList();

        int cardCount = 0;

        foreach (Card card in cards)
        {
            card.PointerEnterEvent.AddListener(CardPointerEnter);
            card.PointerExitEvent.AddListener(CardPointerExit);
            card.BeginDragEvent.AddListener(BeginDrag);
            card.EndDragEvent.AddListener(EndDrag);
            card.name = cardCount.ToString();
            cardCount++;
        }

        StartCoroutine(Frame());

        IEnumerator Frame()
        {
            yield return new WaitForSecondsRealtime(.1f);
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].cardVisual != null)
                    cards[i].cardVisual.UpdateIndex(transform.childCount);
            }
        }

    }


    public void AddCard(Card card)
    {
        cards.Add(card);

        card.PointerEnterEvent.AddListener(CardPointerEnter);
        card.PointerExitEvent.AddListener(CardPointerExit);
        card.BeginDragEvent.AddListener(BeginDrag);
        card.EndDragEvent.AddListener(EndDrag);
    }



    private void BeginDrag(Card card)
    {
        selectedCard = card;
    }


    void EndDrag(Card card)
    {
        if (selectedCard == null)
            return;

        selectedCard.transform.DOLocalMove(selectedCard.selected ? new Vector3(0,selectedCard.selectionOffset,0) : Vector3.zero, tweenCardReturn ? .15f : 0).SetEase(Ease.OutBack);

        rect.sizeDelta += Vector2.right;
        rect.sizeDelta -= Vector2.right;

        selectedCard = null;

    }

    void CardPointerEnter(Card card)
    {
        hoveredCard = card;
    }

    void CardPointerExit(Card card)
    {
        hoveredCard = null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            if (index == 99)
            {
                if (hoveredCard != null)
                {
                    Destroy(hoveredCard.transform.parent.gameObject);
                    cards.Remove(hoveredCard);


                    ShopManager.Instance.YourMoneyText(ShopManager.Instance.money + 1);

                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            foreach (Card card in cards)
            {
                card.Deselect();
            }
        }

        if (selectedCard == null)
            return;

        if (isCrossing)
            return;

        for (int i = 0; i < cards.Count; i++)
        {

            if (selectedCard.transform.position.x > cards[i].transform.position.x)
            {
                if (selectedCard.ParentIndex() < cards[i].ParentIndex())
                {
                    Swap(i);
                    break;
                }
            }

            if (selectedCard.transform.position.x < cards[i].transform.position.x)
            {
                if (selectedCard.ParentIndex() > cards[i].ParentIndex())
                {
                    Swap(i);
                    break;
                }
            }
        }
    }

    void Swap(int index)
    {
        isCrossing = true;

        Transform focusedParent = selectedCard.transform.parent;
        Transform crossedParent = cards[index].transform.parent;

        cards[index].transform.SetParent(focusedParent);
        cards[index].transform.localPosition = cards[index].selected ? new Vector3(0, cards[index].selectionOffset, 0) : Vector3.zero;
        selectedCard.transform.SetParent(crossedParent);

        isCrossing = false;

        if (cards[index].cardVisual == null)
            return;

        bool swapIsRight = cards[index].ParentIndex() > selectedCard.ParentIndex();
        cards[index].cardVisual.Swap(swapIsRight ? -1 : 1);

        //Updated Visual Indexes
        foreach (Card card in cards)
        {
            card.cardVisual.UpdateIndex(transform.childCount);
        }
    }

}
