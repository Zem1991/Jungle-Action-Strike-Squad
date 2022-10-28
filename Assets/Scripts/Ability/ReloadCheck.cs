using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadCheck
{
    public bool CheckPrimary(Character character)
    {
        RangedWeapon rangedWeapon = character.GetMainWeapon() as RangedWeapon;
        return CheckRangedWeapon(rangedWeapon);
    }

    public bool CheckSidearm(Character character)
    {
        RangedWeapon rangedWeapon = character.GetSidearm() as RangedWeapon;
        return CheckRangedWeapon(rangedWeapon);
    }

    private bool CheckRangedWeapon(RangedWeapon rangedWeapon)
    {
        Ammunition ammunition = rangedWeapon.CurrentAmmunition;
        if (!ammunition) return false;
        return ammunition.Stack.CheckFull();
    }
}
