using System;
using System.Collections.Generic;
using UnityEngine;

public class CardManager
{
    /*public Dictionary<string, ActiveSO> ActivesDic => activesDic;
    private Dictionary<string, ActiveSO> activesDic = new();
    public ActiveSO[] Actives => actives;
    private ActiveSO[] actives;
    public Dictionary<string, PassiveSO> PassivesDic => passivesDic;
    private Dictionary<string, PassiveSO> passivesDic = new();
    public PassiveSO[] Passives => passives;
    private PassiveSO[] passives;*/

    public List<CardTemplate> ActiveLapidaries => activeLapidaries;
    private List<CardTemplate> activeLapidaries = new();
    public List<CardTemplate> PassiveLapidaries => passiveLapidaries;
    private List<CardTemplate> passiveLapidaries = new();

    private SetActiveAbility setActiveAbility = new();
    private SetPassiveAbility setPassiveAbility = new();

    public void Init() // 패시브와 액티브 스크립트를 전부 Resources에서 가져옴
    {
        setActiveAbility.Init();

        foreach (ActiveSO activeInfo in Resources.LoadAll<ActiveSO>("SDH/Actives"))//("SDH/Lapidary/Actives"))
        {
            CardTemplate cardTemplate = (CardTemplate)Activator.CreateInstance(setActiveAbility.ActivesDic[activeInfo.name]);
            cardTemplate.cardInfo = activeInfo;
            activeLapidaries.Add(cardTemplate);
        }
        setPassiveAbility.Init();

        foreach (PassiveSO passiveInfo in Resources.LoadAll<PassiveSO>("SDH/Passives"))
        {
            CardTemplate cardTemplate = (CardTemplate)Activator.CreateInstance(setPassiveAbility.PassivesDic[passiveInfo.name]);
            cardTemplate.cardInfo2 = passiveInfo;
            passiveLapidaries.Add(cardTemplate);
        }

        /*actives = Resources.LoadAll<ActiveSO>("SDH/Actives");//Debug.Log(actives.Length);
        foreach (ActiveSO activeCardSO in actives)
        {
            activesDic.Add(activeCardSO.Id, activeCardSO);
        }
        setActiveAbility.SetAbility();

        passives = Resources.LoadAll<PassiveSO>("SDH/Passives");
        foreach(PassiveSO passiveCardSO in passives)
        {
            passivesDic.Add(passiveCardSO.Id, passiveCardSO);
        }
        setPassiveAbility.SetAbility();*/
    }
}
