using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadCommand : Command
{
    public new ReloadAbilityData AbilityData { get => abilityData as ReloadAbilityData; }

    public void Initialize(ReloadAbilityData abilityData, Character actor, Item item)
    {
        base.Initialize(abilityData, actor, item);
    }

    public override bool CanExecute()
    {
        RangedWeapon rangedWeapon = GetWeapon();
        if (!rangedWeapon) return false;
        return rangedWeapon.CanReload();
    }

    protected override void StartExecution()
    {
        base.StartExecution();
        RangedWeapon rangedWeapon = GetWeapon();
        rangedWeapon.Reload(Actor);
    }

    private RangedWeapon GetWeapon()
    {
        return Item as RangedWeapon;
    }
}
