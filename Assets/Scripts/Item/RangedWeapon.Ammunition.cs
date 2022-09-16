using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class RangedWeapon : Weapon
{
    [Header("RangedWeapon Ammunition")]
    [SerializeField] private AmmunitionType ammunitionType;
    [SerializeField] private int magazineSize = 1;
    [SerializeField] private Ammunition currentAmmunition;
    public AmmunitionType AmmunitionType { get => ammunitionType; private set => ammunitionType = value; }
    public int MagazineSize { get => magazineSize; private set => magazineSize = value; }
    public Ammunition CurrentAmmunition { get => currentAmmunition; private set => currentAmmunition = value; }

    public override bool CheckAmmo(int required)
    {
        if (!NeedsAmmo()) return true;
        if (!CurrentAmmunition) return false;
        int current = CurrentAmmunition.Amount.Current;
        return current >= required;
    }

    public bool NeedsAmmo()
    {
        return ammunitionType != AmmunitionType.NONE;
    }

    public bool Reload()
    {
        //TODO: proper reloading
        CurrentAmmunition?.Amount.MakeFull();
        Debug.Log("Reloaded");
        return true;
    }
}
