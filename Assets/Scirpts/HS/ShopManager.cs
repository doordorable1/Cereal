using UnityEngine;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;

public class ShopManager : Singleton<ShopManager>
{
    public int money = -3;
    public TextMeshProUGUI money_text;
    public int roundplusmoney = 4;

    public List<GameObject> cardPrefab = new();
    public GameObject cardPrefab2;


    public List<GameObject> cardPrefabList = new ();

    public List<GameObject> cardRarity = new();

    private void OnEnable()
    {
        //Todo: 카드 rarity에 따른 카드 생성, 현재는 랜덤생성이므로 수정해야함
        YourMoneyText(money + roundplusmoney);
        for (int i = 0; i < 5; i++)
        {
            //my email : goalgoloo1@gmail.com
            var card = Instantiate(cardPrefab[i], cardPrefab2.transform);
            cardPrefabList.Add(card);
            
        }
    }

    private void OnDisable()
    {
        foreach (var cardPrefab in cardPrefabList)
        {
            Destroy(cardPrefab);
        }
    }

    public void YourMoneyText(int i)
    {
        money = i;
        money_text.text = money.ToString();
    }
    public void CardToHand(GameObject obj)
    {
        var card = obj.GetComponentInChildren<Card>();
        //old
        card.PointerEnterEvent.RemoveAllListeners();
        card.BeginDragEvent.RemoveAllListeners();


        //new
        card.transform.parent.transform.parent = StageManager.Instance.cards_hand.transform;


        StageManager.Instance.cards_hand.AddCard(card);

    }


    public void EnforceActiveCardSlot()
    {
        
        if (money > 4)
        {
            YourMoneyText(money - 5);
            StageManager.Instance.maxCardCenterSlot = StageManager.Instance.maxCardCenterSlot + 1;
        }

        

    }
    
    public void RerollCard()
    {
        if (money > 0) 
        { 
            YourMoneyText(money - 1);
            var v = cardPrefab2.GetComponentsInChildren<HorizontalCardHolder>();
            for (int i = 0; i < v.Length; i++)
            {
                Destroy(v[i].gameObject);
            }
            for (int i = 0; i < 5; i++)
            {
                var card = Instantiate(cardPrefab[i], cardPrefab2.transform);
                cardPrefabList.Add(card); 
                
            }
        }
    }
    
}