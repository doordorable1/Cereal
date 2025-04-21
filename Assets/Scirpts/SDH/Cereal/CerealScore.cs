using System.Collections.Generic;
using UnityEngine;

public class CerealScore
{
    public Dictionary<Cereal, int> CerealScoreDic => cerealScoreDic;
    private Dictionary<Cereal, int> cerealScoreDic;

    public CerealScore()
    {
        cerealScoreDic = new()
        {
            { new(CerealType.Oreo, 1), 1 },
            { new(CerealType.Oreo, 2), 10 },
            { new(CerealType.Oreo, 3), 100 },

            { new(CerealType.Chex, 1), 1 },
            { new(CerealType.Chex, 2), 15 },
            { new(CerealType.Chex, 3), 250 },

            { new(CerealType.Coco, 1), 1 },

            { new(CerealType.Froot, 1), 1 },
            { new(CerealType.Froot, 2), 20 },
            { new(CerealType.Froot, 3), 400 }
        };
    }
}
