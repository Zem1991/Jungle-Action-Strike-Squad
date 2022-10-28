using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCheck
{
    public bool CheckPrimary(Character character)
    {
        Weapon weapon = character.GetMainWeapon();
        return weapon;
    }

    public bool CheckSidearm(Character character)
    {
        Weapon weapon = character.GetSidearm();
        return weapon;
    }
}
