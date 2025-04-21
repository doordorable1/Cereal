using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class cgb : MonoBehaviour
{
    public Button button;
    public int i;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponentInChildren<Button>();
        i = GetComponentInChildren<Card>().rarity;            
        button.onClick.AddListener(d);




        GetComponentInChildren<TMPro.TextMeshProUGUI>().text = i.ToString()+"Gold";
    }

    // Update is called once per frame
    void d()
    {
        if (ShopManager.Instance.money >= i )
        { 
            GetComponentInParent<ShopManager>().CardToHand(gameObject);
            ShopManager.Instance.YourMoneyText(ShopManager.Instance.money - i);
            Destroy(gameObject);
        }
    }
}
/*
 
        if (GetComponentInChildren<Card>().rarity == 1)
        {
            
            button.onClick.AddListener(() => d());
        }
        if (GetComponentInChildren<Card>().rarity == 2)
        {
            button.onClick.AddListener(() => d(2));
        }
        if (GetComponentInChildren<Card>().rarity == 3)
        {
            button.onClick.AddListener(() => d(3));
        }
        if (GetComponentInChildren<Card>().rarity == 4)
        {
            button.onClick.AddListener(() => d(4));
        }
        if (GetComponentInChildren<Card>().rarity == 5)
        {
            button.onClick.AddListener(() => d(5));
        }*/