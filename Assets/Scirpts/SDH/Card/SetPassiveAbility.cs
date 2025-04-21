using System;
using System.Collections.Generic;
using UnityEngine;

public class SetPassiveAbility
{
    public Dictionary<string, Type> PassivesDic => passivesDic;
    private Dictionary<string, Type> passivesDic = new();

    //////////
    // tier 1
    //////////

    public class OreoScorePlusOne : CardTemplate
    {
        public override void OnHand()
        {
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Oreo)] += 1;
        }
    }

    public class ChexScorePlusOne : CardTemplate
    {
        public override void OnHand()
        {
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Chex)] += 1;
        }
    }

    public class FrootScorePlusOne : CardTemplate
    {
        public override void OnHand()
        {
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Froot)] += 1;
        }
    }

    public class CocoScorePlusOne : CardTemplate
    {
        public override void OnHand()
        {
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Coco)] += 1;
        }
    }

    //////////
    // tier 2
    //////////

    public class AllScorePlusTwo : CardTemplate
    {
        public override void OnHand()
        {
            foreach (Cereal cereal in Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic.Keys)
            {
                if (cereal.cerealType == CerealType.Coco) continue;

                Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[cereal] += 2;
            }
        }
    }

    public class All2ScoreMultipleOneHalf : CardTemplate
    {
        public override void OnHand()
        {
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Oreo, 3)] *= 3;
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Oreo, 3)] /= 2;
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Chex, 3)] *= 3;
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Chex, 3)] /= 2;
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Froot, 3)] *= 3;
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Froot, 3)] /= 2;
        }
    }

    public class CocoScorePlusTwo : CardTemplate
    {
        public override void OnHand()
        {
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Coco)] += 2;
        }
    }

    /////////
    // tier 3
    //////////

    public class All3ScoreMultipleTwo : CardTemplate
    {
        public override void OnHand()
        {
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Oreo, 3)] *= 2;
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Chex, 3)] *= 2;
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Froot, 3)] *= 2;
        }
    }

    public class CocoScoreMultipleTwo : CardTemplate
    {
        public override void OnHand()
        {
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Coco)] *= 2;
        }
    }

    public void Init()
    {
        foreach (Type passive in typeof(SetPassiveAbility).GetNestedTypes(System.Reflection.BindingFlags.Public))
        {
            passivesDic.Add(passive.Name, passive);
        }
    }

    /*public void SetAbility()
    {
        //////////
        // tier 1
        //////////

        // ���ں��� ��ġ�� 1�� �����մϴ�.
        Manager.Card.PassivesDic["CocoScorePlusOne"].OnExecute = () =>
        {
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Coco)] += 1;
        };

        //////////
        // tier 2
        //////////
        
        // ��� �ø����� ��ġ�� 2�� �����մϴ�.
        Manager.Card.PassivesDic["AllScorePlusTwo"].OnExecute = () =>
        {
            foreach(Cereal cereal in Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic.Keys)
            {
                if (cereal.cerealType == CerealType.Coco) continue;

                Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[cereal] += 2;
            }
        };

        // ��� 2Ƽ�� �⺻ �ø����� ���� ��ġ�� 1.5�� �����մϴ�.
        Manager.Card.PassivesDic["All2ScoreMultipleOneHalf"].OnExecute = () =>
        {
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Oreo, 3)] *= 3;
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Oreo, 3)] /= 2;
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Chex, 3)] *= 3;
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Chex, 3)] /= 2;
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Froot, 3)] *= 3;
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Froot, 3)] /= 2;
        };

        // ���ں��� ��ġ�� 2�� �����մϴ�.
        Manager.Card.PassivesDic["CocoScorePlusTwo"].OnExecute = () =>
        {
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Coco)] += 2;
        };

        //////////
        // tier 3
        //////////

        // ��� 3Ƽ�� �⺻ �ø����� ���� ��ġ�� 2�� �����մϴ�.
        Manager.Card.PassivesDic["All3ScoreMultipleTwo"].OnExecute = () =>
        {
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Oreo, 3)] *= 2;
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Chex, 3)] *= 2;
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Froot, 3)] *= 2;
        };

        // ���ں��� ���� ��ġ�� 2��� �����մϴ�.
        Manager.Card.PassivesDic["CocoScoreMultipleTwo"].OnExecute = () =>
        {
            Manager.Data.CerealBowlScore.CerealScoreRule.CerealScoreDic[new Cereal(CerealType.Coco)] *= 2;
        };
    }*/
}
