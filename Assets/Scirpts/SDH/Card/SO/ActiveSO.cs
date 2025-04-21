using System;
using System.Collections.Generic;
using UnityEngine;

// < summary >
/// 액티브 카드
/// </summary>
[CreateAssetMenu(fileName = "ActiveCardSO", menuName = "Scriptable Objects/ActiveCardSO")]
public class ActiveSO : ScriptableObject
{
    [Header("Name")]
    public string Id;
    public string Name; // 카드명
    [TextArea(3,5)]
    public string Ability; // 카드 설명문

    [Space(20f)]
    [Range(1, 5)]
    public int rarity; // 희귀도

    [Space(20f)]
    [Header("Conditions")]
    public List<Cereal> Needs;

    [Header("Inputs")]
    public List<Cereal> Inputs;

    [Header("Outputs")]
    public List<Cereal> Outputs;

    [Header("Art")]
    public Sprite CardSprite; // 카드 아트
}
