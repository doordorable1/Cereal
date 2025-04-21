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
        
        // 오레오I를 3개 추가합니다.
        Manager.Card.ActivesDic["OreoPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo), 3);
        };

        // 첵스I를 2개 추가합니다.
        Manager.Card.ActivesDic["ChexPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), 2);
        };

        // 후르츠링I을 4개 추가합니다.
        Manager.Card.ActivesDic["FrootPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot), 4);
        };

        // 코코볼을 8개 추가합니다.
        Manager.Card.ActivesDic["CocoPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), 8);
        };

        // 모든 기본 시리얼을 1개 추가합니다.
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

        // 오레오I를 5개 추가합니다.
        Manager.Card.ActivesDic["OreoPlusPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo), 5);
        };

        // 첵스I를 3개 추가합니다.
        Manager.Card.ActivesDic["ChexPlusPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex), 3);
        };

        // 후르츠링I을 9개 추가합니다.
        Manager.Card.ActivesDic["FrootPlusPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot), 9);
        };

        // 코코볼을 18개 추가합니다.
        Manager.Card.ActivesDic["CocoPlusPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), 18);
        };

        // 오레오I 1개마다 오레오II 1개로 변환합니다.
        Manager.Card.ActivesDic["OreoToOreo2"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Convert(new Cereal(CerealType.Oreo), new Cereal(CerealType.Oreo, 2));
        };

        // 첵스I 1개와 코코볼 1개마다 첵스II 1개로 변환합니다.
        Manager.Card.ActivesDic["ChexAndCocoToChex2"].OnExecute = () =>
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Chex));
            int b = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Coco));
            int c = Math.Min(a, b);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), c);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Chex), c);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Coco), c);
        };

        // 후르츠링I 2개마다 1개를 후르츠링II 1개로 변환합니다. 나머지는 코코볼로 변환합니다.
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
        
        // 오레오II를 4개 추가합니다.
        Manager.Card.ActivesDic["Oreo2Plus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 2), 5);
        };

        // 첵스II를 2개 추가합니다.
        Manager.Card.ActivesDic["Chex2Plus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), 2);
        };

        // 후르츠링I을 16개 추가합니다.
        Manager.Card.ActivesDic["FrootPlusPlusPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot), 16);
        };

        // 코코볼이 아닌 기본 1티어 시리얼의 수만큼 코코볼을 추가합니다.
        Manager.Card.ActivesDic["CocoPlusOthers"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), new Cereal(CerealType.Oreo));
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), new Cereal(CerealType.Oreo));
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), new Cereal(CerealType.Oreo));
        };

        // 오레오I 1개마다 오레오II 1개로 변환합니다. 사용한 오레오I은 반환됩니다.
        Manager.Card.ActivesDic["OreoToOreo2Advanced"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 2), new Cereal(CerealType.Oreo));
        };

        // 첵스I와 코코볼의 합 2개마다 첵스II 1개로 변환합니다. 첵스I와 코코볼이 1개씩은 필요합니다. 나머지는 버립니다.
        Manager.Card.ActivesDic["ChexAndCocoToChex2Advanced"].OnExecute = () =>
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Chex));
            int b = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Coco));
            if (a == 0 || b == 0) return;
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), (a + b) / 2);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Chex), a);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Coco), b);
        };

        // 후르츠링I 5개마다 4개를 후르츠링II 4개로 변환합니다. 나머지는 코코볼로 변환합니다.
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

        // 오레오II를 8개 추가합니다.
        Manager.Card.ActivesDic["Oreo2PlusPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 2), 8);
        };

        // 첵스II를 5개 추가합니다.
        Manager.Card.ActivesDic["Chex2PlusPlus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), 5);
        };

        // 후르츠링II을 10개 추가합니다.
        Manager.Card.ActivesDic["Froot2Plus"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot), 10);
        };

        // 가진 코코볼을 2배로 만듭니다.
        Manager.Card.ActivesDic["CocoDouble"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), new Cereal(CerealType.Coco));
        };

        // 오레오II 1개마다 오레오III 1개로 변환합니다.
        Manager.Card.ActivesDic["Oreo2ToOreo3"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Convert(new Cereal(CerealType.Oreo, 2), new Cereal(CerealType.Oreo, 3));
        };

        // 첵스II 1개와 코코볼 2개마다 첵스III 1개로 변환합니다.
        Manager.Card.ActivesDic["Chex2AndCocoToChex3"].OnExecute = () =>
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Chex, 2));
            int b = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Coco));
            int c = Math.Min(a, b / 2);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), c);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Chex), c);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Coco), c);
        };

        // 후르츠링II 2개마다 1개를 후르츠링III 1개로 변환합니다. 나머지는 코코볼로 변환합니다.
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

        // 오레오II 1개마다 오레오III 1개를 추가합니다. 오레오I 1개마다 오레오II 1개와 오레오III 1개를 추가합니다.
        Manager.Card.ActivesDic["OreoPlusUltimate"].OnExecute = () =>
        {
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 3), new Cereal(CerealType.Oreo, 2));
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 3), new Cereal(CerealType.Oreo));
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Oreo, 2), new Cereal(CerealType.Oreo));
        };

        // 첵스II와 코코볼의 합 3개마다 첵스II 1개로 변환합니다. 첵스II와 코코볼이 1개씩은 필요합니다. 나머지는 버립니다.
        Manager.Card.ActivesDic["Chex2AndCocoToChex3Advanced"].OnExecute = () =>
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Chex, 2));
            int b = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Coco));
            if (a == 0 || b == 0) return;
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Chex, 2), (a + b) / 3);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Chex), a);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Coco), b);
        };

        // 후르츠링II 4개마다 후르츠링III 3개로 변환합니다. 사용한 후르츠링II만큼 부산물로 코코볼을 생성합니다.
        Manager.Card.ActivesDic["Froot2ToFroot3AndCocoAdvanced"].OnExecute = () =>
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Froot, 2));
            int b = a * 3 / 4;
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Froot, 3), b);
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), a);
            Manager.Data.CerealBowlControl.Subtract(new Cereal(CerealType.Froot, 2));
        };

        // 가진 코코볼을 3배로 만듭니다.
        Manager.Card.ActivesDic["CocoTriple"].OnExecute = () =>
        {
            int a = Manager.Data.CerealBowlControl.GetCereal(new Cereal(CerealType.Coco));
            Manager.Data.CerealBowlControl.Add(new Cereal(CerealType.Coco), 2 * a);
        };
    }*/
}
