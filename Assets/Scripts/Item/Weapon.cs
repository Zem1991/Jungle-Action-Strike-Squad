using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "JASS/Item/Weapon")]
public abstract partial class Weapon : Item
{
    [Header("Weapon")]
    [SerializeField] private bool isSidearm;
    [SerializeField] private float attackDuration;
    public bool IsSidearm { get => isSidearm; private set => isSidearm = value; }
    public float AttackDuration { get => attackDuration; private set => attackDuration = value; }

    public abstract bool CheckAmmo(int required);
    public abstract void Attack(Character actor);
}
