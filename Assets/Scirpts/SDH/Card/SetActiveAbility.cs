using System;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveAbility
{
    public Dictionary<string, Type> ActivesDic => activesDic;
    private Dictionary<string, Type> activesDic = new();

    //////////
    // tier 1
    //////////

    public class OreoPlus : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo), 3);
        }
    }

    public class ChexPlus : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex), 2);
        }
    }

    public class FrootPlus : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot), 4);
        }
    }

    public class CocoPlus : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), 8);
        }
    }

    public class AllPlus : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo), 1);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex), 1);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot), 1);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), 1);
        }
    }

    //////////
    // tier 2
    //////////

    public class OreoPlusPlus : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo), 5);
        }
    }

    public class ChexPlusPlus : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex), 3);
        }
    }

    public class FrootPlusPlus : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot), 9);
        }
    }

    public class CocoPlusPlus : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), 18);
        }
    }

    public class OreoToOreo2 : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Convert(new Cereal(CerealType.Oreo), new Cereal(CerealType.Oreo, 2));
        }
    }

    public class ChexAndCocoToChex2 : CardTemplate
    {
        public override void OnTable()
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Chex));
            int b = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Coco));
            int c = Math.Min(a, b);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), c);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Chex), c);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Coco), c);
        }
    }

    public class FrootToFroot2AndCoco : CardTemplate
    {
        public override void OnTable()
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Froot));
            int b = a / 2;
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot, 2), b);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), a - b);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Froot));
        }
    }

    //////////
    // tier 3
    //////////

    public class Oreo2Plus : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 2), 4);
        }
    }

    public class Chex2Plus : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), 2);
        }
    }

    public class FrootPlusPlusPlus : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot), 16);
        }
    }

    public class CocoPlusOthers : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), new Cereal(CerealType.Oreo));
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), new Cereal(CerealType.Chex));
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), new Cereal(CerealType.Froot));
        }
    }

    public class OreoToOreo2Advanced : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 2), new Cereal(CerealType.Oreo));
        }
    }

    public class ChexAndCocoToChex2Advanced : CardTemplate
    {
        public override void OnTable()
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Chex));
            int b = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Coco));
            if (a == 0 || b == 0) return;
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), (a + b) / 2);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Chex));
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Coco));
        }
    }

    public class FrootToFroot2AndCocoAdvanced : CardTemplate
    {
        public override void OnTable()
        {
            int x = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Froot));
            int y = x * 4 / 5;
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot, 2), y);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), x - y);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Froot));
        }
    }

    //////////
    // tier 4
    //////////

    public class Oreo2PlusPlus : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 2), 8);
        }
    }

    public class Chex2PlusPlus : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), 5);
        }
    }

    public class Froot2Plus : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot, 2), 10);
        }
    }

    public class CocoDouble : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), new Cereal(CerealType.Coco));
        }
    }

    public class Oreo2ToOreo3 : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Convert(new Cereal(CerealType.Oreo, 2), new Cereal(CerealType.Oreo, 3));
        }
    }

    public class Chex2AndCocoToChex3 : CardTemplate
    {
        public override void OnTable()
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Chex, 2));
            int b = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Coco));
            int c = Math.Min(a, b / 2);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 3), c);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Chex, 2), c);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Coco), c);
        }
    }

    public class Froot2ToFroot3AndCoco : CardTemplate
    {
        public override void OnTable()
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Froot, 2));
            int b = a / 2;
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot, 3), b);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), a - b);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Froot, 2));
        }
    }

    //////////
    // tier 5
    //////////

    public class OreoPlusUltimate : CardTemplate
    {
        public override void OnTable()
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 3), new Cereal(CerealType.Oreo, 2));
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 3), new Cereal(CerealType.Oreo));
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 2), new Cereal(CerealType.Oreo));
        }
    }

    public class Chex2AndCocoToChex3Advanced : CardTemplate
    {
        public override void OnTable()
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Chex, 2));
            int b = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Coco));
            if (a == 0 || b == 0) return;
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), (a + b) / 3);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Chex));
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Coco));
        }
    }

    public class Froot2ToFroot3AndCocoAdvanced : CardTemplate
    {
        public override void OnTable()
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Froot, 2));
            int b = a * 3 / 4;
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot, 3), b);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), a);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Froot, 2));
        }
    }

    public class CocoTriple : CardTemplate
    {
        public override void OnTable()
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Coco));
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), 2 * a);
        }
    }

    public void Init()
    {
        foreach (Type active in typeof(SetActiveAbility).GetNestedTypes(System.Reflection.BindingFlags.Public))
        {
            activesDic.Add(active.Name, active);
        }
    }

    /*public void SetAbility()
    {
        //////////
        // tier 1
        //////////
        
        // ������I�� 3�� �߰��մϴ�.
        Manager.Card.ActivesDic["OreoPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo), 3);
        };

        // ý��I�� 2�� �߰��մϴ�.
        Manager.Card.ActivesDic["ChexPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), 2);
        };

        // �ĸ�����I�� 4�� �߰��մϴ�.
        Manager.Card.ActivesDic["FrootPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot), 4);
        };

        // ���ں��� 8�� �߰��մϴ�.
        Manager.Card.ActivesDic["CocoPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), 8);
        };

        // ��� �⺻ �ø����� 1�� �߰��մϴ�.
        Manager.Card.ActivesDic["AllPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo), 1);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex), 1);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot), 1);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), 1);
        };

        //////////
        // tier 2
        //////////

        // ������I�� 5�� �߰��մϴ�.
        Manager.Card.ActivesDic["OreoPlusPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo), 5);
        };

        // ý��I�� 3�� �߰��մϴ�.
        Manager.Card.ActivesDic["ChexPlusPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex), 3);
        };

        // �ĸ�����I�� 9�� �߰��մϴ�.
        Manager.Card.ActivesDic["FrootPlusPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot), 9);
        };

        // ���ں��� 18�� �߰��մϴ�.
        Manager.Card.ActivesDic["CocoPlusPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), 18);
        };

        // ������I 1������ ������II 1���� ��ȯ�մϴ�.
        Manager.Card.ActivesDic["OreoToOreo2"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Convert(new Cereal(CerealType.Oreo), new Cereal(CerealType.Oreo, 2));
        };

        // ý��I 1���� ���ں� 1������ ý��II 1���� ��ȯ�մϴ�.
        Manager.Card.ActivesDic["ChexAndCocoToChex2"].OnExecute = () =>
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Chex));
            int b = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Coco));
            int c = Math.Min(a, b);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), c);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Chex), c);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Coco), c);
        };

        // �ĸ�����I 2������ 1���� �ĸ�����II 1���� ��ȯ�մϴ�. �������� ���ں��� ��ȯ�մϴ�.
        Manager.Card.ActivesDic["FrootToFroot2AndCoco"].OnExecute = () =>
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Froot));
            int b = a / 2;
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot, 2), b);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), a - b);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Froot));
        };

        //////////
        // tier 3
        //////////
        
        // ������II�� 4�� �߰��մϴ�.
        Manager.Card.ActivesDic["Oreo2Plus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 2), 5);
        };

        // ý��II�� 2�� �߰��մϴ�.
        Manager.Card.ActivesDic["Chex2Plus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), 2);
        };

        // �ĸ�����I�� 16�� �߰��մϴ�.
        Manager.Card.ActivesDic["FrootPlusPlusPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot), 16);
        };

        // ���ں��� �ƴ� �⺻ 1Ƽ�� �ø����� ����ŭ ���ں��� �߰��մϴ�.
        Manager.Card.ActivesDic["CocoPlusOthers"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), new Cereal(CerealType.Oreo));
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), new Cereal(CerealType.Oreo));
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), new Cereal(CerealType.Oreo));
        };

        // ������I 1������ ������II 1���� ��ȯ�մϴ�. ����� ������I�� ��ȯ�˴ϴ�.
        Manager.Card.ActivesDic["OreoToOreo2Advanced"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 2), new Cereal(CerealType.Oreo));
        };

        // ý��I�� ���ں��� �� 2������ ý��II 1���� ��ȯ�մϴ�. ý��I�� ���ں��� 1������ �ʿ��մϴ�. �������� �����ϴ�.
        Manager.Card.ActivesDic["ChexAndCocoToChex2Advanced"].OnExecute = () =>
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Chex));
            int b = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Coco));
            if (a == 0 || b == 0) return;
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), (a + b) / 2);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Chex), a);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Coco), b);
        };

        // �ĸ�����I 5������ 4���� �ĸ�����II 4���� ��ȯ�մϴ�. �������� ���ں��� ��ȯ�մϴ�.
        Manager.Card.ActivesDic["FrootToFroot2AndCocoAdvanced"].OnExecute = () =>
        {
            int x = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Froot));
            int y = x * 4 / 5;
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot, 2), y);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), x - y);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Froot));
        };

        //////////
        // tier 4
        //////////

        // ������II�� 8�� �߰��մϴ�.
        Manager.Card.ActivesDic["Oreo2PlusPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 2), 8);
        };

        // ý��II�� 5�� �߰��մϴ�.
        Manager.Card.ActivesDic["Chex2PlusPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), 5);
        };

        // �ĸ�����II�� 10�� �߰��մϴ�.
        Manager.Card.ActivesDic["Froot2Plus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot), 10);
        };

        // ���� ���ں��� 2��� ����ϴ�.
        Manager.Card.ActivesDic["CocoDouble"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), new Cereal(CerealType.Coco));
        };

        // ������II 1������ ������III 1���� ��ȯ�մϴ�.
        Manager.Card.ActivesDic["Oreo2ToOreo3"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Convert(new Cereal(CerealType.Oreo, 2), new Cereal(CerealType.Oreo, 3));
        };

        // ý��II 1���� ���ں� 2������ ý��III 1���� ��ȯ�մϴ�.
        Manager.Card.ActivesDic["Chex2AndCocoToChex3"].OnExecute = () =>
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Chex, 2));
            int b = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Coco));
            int c = Math.Min(a, b / 2);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), c);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Chex), c);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Coco), c);
        };

        // �ĸ�����II 2������ 1���� �ĸ�����III 1���� ��ȯ�մϴ�. �������� ���ں��� ��ȯ�մϴ�.
        Manager.Card.ActivesDic["Froot2ToFroot3AndCoco"].OnExecute = () =>
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Froot, 2));
            int b = a / 2;
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot, 3), b);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), a - b);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Froot, 2));   
        };

        //////////
        // tier 5
        //////////

        // ������II 1������ ������III 1���� �߰��մϴ�. ������I 1������ ������II 1���� ������III 1���� �߰��մϴ�.
        Manager.Card.ActivesDic["OreoPlusUltimate"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 3), new Cereal(CerealType.Oreo, 2));
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 3), new Cereal(CerealType.Oreo));
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 2), new Cereal(CerealType.Oreo));
        };

        // ý��II�� ���ں��� �� 3������ ý��II 1���� ��ȯ�մϴ�. ý��II�� ���ں��� 1������ �ʿ��մϴ�. �������� �����ϴ�.
        Manager.Card.ActivesDic["Chex2AndCocoToChex3Advanced"].OnExecute = () =>
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Chex, 2));
            int b = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Coco));
            if (a == 0 || b == 0) return;
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), (a + b) / 3);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Chex), a);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Coco), b);
        };

        // �ĸ�����II 4������ �ĸ�����III 3���� ��ȯ�մϴ�. ����� �ĸ�����II��ŭ �λ깰�� ���ں��� �����մϴ�.
        Manager.Card.ActivesDic["Froot2ToFroot3AndCocoAdvanced"].OnExecute = () =>
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Froot, 2));
            int b = a * 3 / 4;
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot, 3), b);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), a);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Froot, 2));
        };

        // ���� ���ں��� 3��� ����ϴ�.
        Manager.Card.ActivesDic["CocoTriple"].OnExecute = () =>
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Coco));
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), 2 * a);
        };
    }*/
}
