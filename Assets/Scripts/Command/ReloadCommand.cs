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

    protected override bool CanExecute(Character actor, LevelTile slot, List<PathfindingNode> path)
    {
        Weapon weapon = GetWeapon();
        RangedWeapon rangedWeapon = weapon as RangedWeapon;
        if (!rangedWeapon) return false;
        return rangedWeapon.CanReload();
    }

    protected override void StartExecution(Character actor, LevelTile slot, List<PathfindingNode> path, Action onStart, Action onFinish)
    {
        base.StartExecution(actor, slot, path, onStart, onFinish);
        Weapon weapon = GetWeapon();
        RangedWeapon rangedWeapon = weapon as RangedWeapon;
        rangedWeapon.Reload(actor);
    }

    private Weapon GetWeapon()
    {
        if (CommandData.Sidearm) return Actor.GetSidearm();
        else return Actor.GetMainWeapon();
    }
}
