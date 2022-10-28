using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JASS Data/Ability/Attack Ability")]
public class AttackAbilityData : AbilityData
{
    [Header("AttackAbilityData")]
    [SerializeField] private Percent accuracy;
    [SerializeField][Min(1)] private int attacks = 1;
    public Percent Accuracy { get => accuracy; private set => accuracy = value; }
    public int Attacks { get => attacks; set => attacks = value; }
}
