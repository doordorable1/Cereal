using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class CerealInfo
{
    public Cereal cereal;
    public int count;
}

[Serializable]
public class ActiveInfo
{
    public string id;
    public int rarity;
}

public class DebugActive : MonoBehaviour
{
    [Header("Input Cereal")]
    public List<CerealInfo> inputCerealList = new List<CerealInfo>();

    [Header("Active Slot")]
    public List<ActiveInfo> activeList;


    CardTemplate cardTemplate;// activeSO;
    List<CardTemplate>[] abilitiesByRarity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int maxRarity = 5;
        abilitiesByRarity = new List<CardTemplate>[maxRarity + 1];
        for (int i = 1; i <= maxRarity; i++)
        {
            abilitiesByRarity[i] = Manager.Card.ActiveLapidaries.FindAll(elem => elem.cardInfo.rarity == i);
            //for (int j = 0; j < abilitiesByRarity[i].Count; j++)
            //{
            //    Debug.Log(i + "-" + j + ":" + abilitiesByRarity[i][j].cardInfo.Id);
            //}
        }
    }

    [ContextMenu("TestActive()")]
    void TestActive()
    {
        Manager.Data.CerealBowlControl.CerealBowl.Clear();
        for (int i = 0; i < inputCerealList.Count; i++)
        {
            CerealInfo inputCereal = inputCerealList[i];
            Manager.Data.CerealBowlControl.CerealBowl.Add(inputCereal.cereal, inputCereal.count);
        }

        string msg = "=Input Cereal=";
        var list1 = Manager.Data.CerealBowlControl.CerealBowl.ToList();
        for (int i = 0; i < list1.Count; i++)
        {
            Cereal cereal = list1[i].Key;
            msg += "\n" + cereal.cerealType.ToString() + "[" + cereal.cerealRank + "] " + list1[i].Value + " cnt";
        }


        for (int i = 0; i < activeList.Count; i++)
        {
            CardTemplate cardTemplate = abilitiesByRarity[activeList[i].rarity].Find(
                elem => elem.cardInfo.Id == activeList[i].id);
            if(cardTemplate == null)
            {
                Debug.Log("Not Found");
            }
            else
            {
                msg += "\ncardTemplate[" + i + "]: " + cardTemplate.cardInfo.Id + " / " + cardTemplate.cardInfo.Name + " / " + cardTemplate.cardInfo.Ability;
                cardTemplate.OnTable();
            }
                
        }


        msg += "\n=Output Cereal=";
        var list2 = Manager.Data.CerealBowlControl.CerealBowl.ToList();
        for (int i = 0; i < list2.Count; i++)
        {
            Cereal cereal = list2[i].Key;
            msg += "\n" + cereal.cerealType.ToString() + "[" + cereal.cerealRank + "] " + list2[i].Value + " cnt";
        }

        Debug.Log(msg);
    }
}
