using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSidearmAmmunitionBarUI : ResourceBarUI
{
    public void Refresh(Character character)
    {
        if (character) return;
        RangedWeapon rangedWeapon = character.GetSidearm() as RangedWeapon;
        if (!rangedWeapon) return;
        Refresh(rangedWeapon.CurrentAmmunition.Stack);
    }
}
