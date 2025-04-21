using System;
using System.Collections.Generic;
using UnityEngine;

public enum CerealType
{
    // 기본 토핑 4종
    Oreo, // 오레오 특징: 패시브처럼 강화 가능
    Chex, // 첵스 특징: 다른 토핑이 필요
    Froot, // 후르츠링 특징: 랭크업시 일부가 코코로 유실
    Coco // 코코볼 특징: 자가 증식, 랭크 없음
}

[Serializable]
public class Cereal: IEquatable<Cereal>
{
    public Cereal(CerealType cerealType, int cerealRank = 1)
    {
        this.cerealType = cerealType;
        this.cerealRank = cerealRank;
    }

    public CerealType cerealType; // 시리얼 종류
    public int cerealRank; // 시리얼 레벨

    public bool Equals(Cereal cereal)
    {
        return cerealType.Equals(cereal.cerealType) && cerealRank.Equals(cereal.cerealRank);
    }

    public override bool Equals(object obj)
    {
        return obj is Cereal cereal && Equals(cereal);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(cerealType, cerealRank);
    }
}

public class CerealBowlControl
{
    public Dictionary<Cereal, int> CerealBowl => cerealBowl;
    private Dictionary<Cereal, int> cerealBowl;

    public CerealBowlControl()
    {
        cerealBowl = new()
        {
            { new(CerealType.Oreo), 5 },
            { new(CerealType.Chex), 5 },
            { new(CerealType.Froot), 5 },
            { new(CerealType.Coco), 5 }
        };
    }

    public int GetCereal(Cereal cereal) // cereal의 개수 반환
    {
        if (!cerealBowl.ContainsKey(cereal))
        {
            Debug.Log("No cereal" + cereal.cerealType);
            return -1;
        }

        return cerealBowl[cereal];
    }

    public void Convert(Cereal cereal1, Cereal cereal2) // cereal1을 cereal2로 교환
    {
        if (!cerealBowl.ContainsKey(cereal1))
        {
            return;
        }

        Add(cereal2, cerealBowl[cereal1]);
        Subtract(cereal1);
    }

    public void Add(Cereal cereal, int num) // cereal을 num개 추가
    {
        if (!cerealBowl.ContainsKey(cereal))
        {
            cerealBowl.Add(cereal, 0);
        }

        cerealBowl[cereal] += num;
    }

    public void Add(Cereal cereal1, Cereal cereal2) // cereal1을 cereal2개 추가
    {
        if (!cerealBowl.ContainsKey(cereal2))
        {
            return;
        }
        if (!cerealBowl.ContainsKey(cereal1))
        {
            cerealBowl.Add(cereal1, 0);
        }

        cerealBowl[cereal1] += cerealBowl[cereal2];
    }

    public void Subtract(Cereal cereal, int num) // cereal을 num개 감소
    {
        if (!cerealBowl.ContainsKey(cereal) || cerealBowl[cereal] < num)
        {
            return;
        }

        cerealBowl[cereal] -= num;
    }

    public void Subtract(Cereal cereal) // cereal을 전부 감소
    {
        if (!cerealBowl.ContainsKey(cereal))
        {
            Debug.Log("No cereal" + cereal.cerealType);
            return;
        }

        cerealBowl[cereal] = 0;
    }
}