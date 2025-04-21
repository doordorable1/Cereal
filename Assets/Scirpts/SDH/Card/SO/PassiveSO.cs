using System;
using System.Collections.Generic;
using UnityEngine;

// < summary >
/// �нú� ī��
/// </summary>
[CreateAssetMenu(fileName = "PassiveCardSO", menuName = "Scriptable Objects/PassiveCardSO")]
public class PassiveSO : ScriptableObject
{
    [Header("Name")]
    public string Name; // ī���
    [TextArea(3, 5)]
    public string Ability; // ī�� ����

    [Space(20f)]
    [Range(1, 3)]
    public int rarity; // ī�� ��͵�
    [Range(1, 2)]
    public int priority; // ī�� �켱��
}
