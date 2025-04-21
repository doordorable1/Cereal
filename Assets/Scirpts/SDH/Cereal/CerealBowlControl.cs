using System;
using System.Collections.Generic;
using UnityEngine;

public enum CerealType
{
    // �⺻ ���� 4��
    Oreo, // ������ Ư¡: �нú�ó�� ��ȭ ����
    Chex, // ý�� Ư¡: �ٸ� ������ �ʿ�
    Froot, // �ĸ����� Ư¡: ��ũ���� �Ϻΰ� ���ڷ� ����
    Coco // ���ں� Ư¡: �ڰ� ����, ��ũ ����
}

[Serializable]
public class Cereal: IEquatable<Cereal>
{
    public Cereal(CerealType cerealType, int cerealRank = 1)
    {
        this.cerealType = cerealType;
        this.cerealRank = cerealRank;
    }

    public CerealType cerealType; // �ø��� ����
    public int cerealRank; // �ø��� ����

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

    public int GetCereal(Cereal cereal) // cereal�� ���� ��ȯ
    {
        if (!cerealBowl.ContainsKey(cereal))
        {
            Debug.Log("No cereal" + cereal.cerealType);
            return -1;
        }

        return cerealBowl[cereal];
    }

    public void Convert(Cereal cereal1, Cereal cereal2) // cereal1�� cereal2�� ��ȯ
    {
        if (!cerealBowl.ContainsKey(cereal1))
        {
            return;
        }

        Add(cereal2, cerealBowl[cereal1]);
        Subtract(cereal1);
    }

    public void Add(Cereal cereal, int num) // cereal�� num�� �߰�
    {
        if (!cerealBowl.ContainsKey(cereal))
        {
            cerealBowl.Add(cereal, 0);
        }

        cerealBowl[cereal] += num;
    }

    public void Add(Cereal cereal1, Cereal cereal2) // cereal1�� cereal2�� �߰�
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

    public void Subtract(Cereal cereal, int num) // cereal�� num�� ����
    {
        if (!cerealBowl.ContainsKey(cereal) || cerealBowl[cereal] < num)
        {
            return;
        }

        cerealBowl[cereal] -= num;
    }

    public void Subtract(Cereal cereal) // cereal�� ���� ����
    {
        if (!cerealBowl.ContainsKey(cereal))
        {
            Debug.Log("No cereal" + cereal.cerealType);
            return;
        }

        cerealBowl[cereal] = 0;
    }
}