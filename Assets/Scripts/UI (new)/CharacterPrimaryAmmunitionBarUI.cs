using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPrimaryAmmunitionBarUI : ResourceBarUI
{
    public void Refresh(Character character)
    {
        if (character) return;
        RangedWeapon rangedWeapon = character.GetMainWeapon() as RangedWeapon;
        if (!rangedWeapon) return;
        Refresh(rangedWeapon.CurrentAmmunition.Stack);
    }
}
