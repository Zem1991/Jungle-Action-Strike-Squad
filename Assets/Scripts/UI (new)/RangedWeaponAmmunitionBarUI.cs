using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeaponAmmunitionBarUI : ResourceBarUI
{
    public void Refresh(RangedWeapon rangedWeapon)
    {
        if (!rangedWeapon) return;
        Refresh(rangedWeapon.CurrentAmmunition.Stack);
    }
}
