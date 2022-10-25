using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadCommand : Command
{
    public new ReloadCommandData CommandData { get => commandData as ReloadCommandData; }

    public void Initialize(ReloadCommandData commandData)
    {
        base.Initialize(commandData);
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
