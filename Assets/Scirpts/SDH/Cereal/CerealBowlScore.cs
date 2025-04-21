using System;
using System.Collections.Generic;
using UnityEngine;

public class CerealBowlScore
{
    public CerealScore CerealScoreRule => cerealScoreRule;
    private CerealScore cerealScoreRule;

    public Action Passives;

    public int CalculateCerealBowlScore()
    {
        cerealScoreRule = new();

        Passives = null;
        // read passive slot
        AdjustPassives();

        int score = 0;
        foreach (KeyValuePair<Cereal, int> elem in Manager.Data.CerealBowlControl.CerealBowl)
        {
            score += cerealScoreRule.CerealScoreDic[elem.Key] * elem.Value;
        }

        return score;
    }

    public void AdjustPassives()
    {
        Passives?.Invoke();
    }
}
