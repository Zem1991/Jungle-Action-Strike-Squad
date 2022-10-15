using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item
{
    public new WeaponData ItemData { get => itemData as WeaponData; }

    public void Initialize(WeaponData itemData)
    {
        base.Initialize(itemData);
    }
    
    public abstract bool CheckAmmo(int required);
    public abstract void Attack(Character actor);
}
