using System;
using System.Collections.Generic;
using UnityEngine;

// < summary >
/// 패시브 카드
/// </summary>
[CreateAssetMenu(fileName = "PassiveCardSO", menuName = "Scriptable Objects/PassiveCardSO")]
public class PassiveSO : ScriptableObject
{
    [Header("Name")]
    public string Name; // 카드명
    [TextArea(3, 5)]
    public string Ability; // 카드 설명문

    [Space(20f)]
    [Range(1, 3)]
    public int rarity; // 카드 희귀도
    [Range(1, 2)]
    public int priority; // 카드 우선도
}
