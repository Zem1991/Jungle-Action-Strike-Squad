using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : Command
{
    [Header("AttackCommand Settings")]
    private int attacks = 1;

    [Header("AttackCommand Runtime")]
    private Vector3 startPos;
    private Vector3 targetPos;
    private Vector3 facingDir;
    private Vector3 attackDir;
    private int remaining;

    protected override bool CanExecute(Character actor, LevelTile slot, List<PathfindingNode> path)
    {
        Weapon weapon = actor.GetMainWeapon();
        if (!weapon) return false;

        bool ammoOK = weapon.CheckAmmo(Data.AmmoCost);
        bool actionOK = actor.ActionPoints.Current >= Data.ActionCostPercent;
        return ammoOK && actionOK;
    }

    protected override void StartExecution(Character actor, LevelTile slot, List<PathfindingNode> path, Action onStart, Action onFinish)
    {
        base.StartExecution(actor, slot, path, onStart, onFinish);
        startPos = Actor.GetPosition();
        targetPos = Tile.transform.position;
        facingDir = (targetPos - startPos).normalized;
        remaining = attacks;
    }

    public override void UpdateExecution()
    {
        Transform actorTransform = Actor.transform;
        if (actorTransform.forward != facingDir)
        {
            //Sometimes Dot gives 0.99999...F and then no extra rotation is done within the next if block.
            float dot = Vector3.Dot(actorTransform.forward, facingDir);
            if (dot < 1)
            {
                if (dot <= -1)
                {
                    //Rotation bug that happens when moving backwards.
                    //To "fix" it we add some slight rotation to force real rotation.
                    actorTransform.eulerAngles += new Vector3(0, 5F, 0);
                }

                //Rotate in place until facing target direction.
                Actor.RotateAt(facingDir);
                return;
            }
        }

        //wait for attack speed / current shot

        Weapon weapon = Actor.GetMainWeapon();
        if (remaining > 0)
        {
            //Check weapon.ammo.current > 0 ?
            weapon.Attack(Actor);
            remaining--;
        }
        else
        {
            //Command only truly finishes when projectile collides (I guess?)
            //FinishExecution();
        }
    }
}
