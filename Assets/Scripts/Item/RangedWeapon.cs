using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    public new RangedWeaponData ItemData { get => itemData as RangedWeaponData; }

    [Header("RangedWeapon Ammunition")]
    [SerializeField] private Ammunition currentAmmunition;
    public Ammunition CurrentAmmunition { get => currentAmmunition; private set => currentAmmunition = value; }

    public void Initialize(RangedWeaponData itemData)
    {
        base.Initialize(itemData);
    }

    public override void AfterUse()
    {
        throw new System.NotImplementedException();
    }

    public override bool CheckAmmo(int required)
    {
        if (!ItemData.NeedsAmmo) return true;
        if (!CurrentAmmunition) return false;
        return CurrentAmmunition.Stack.CheckEnough(required);
    }

    public override void Attack(Character actor)
    {
        Vector3 direction = actor.GetDirection();
        Shoot(actor, direction);
    }

    public bool CanReload()
    {
        if (!ItemData.NeedsAmmo) return false;
        if (!CurrentAmmunition) return false;
        return !CurrentAmmunition.Stack.CheckFull();
    }

    public bool Reload(Character actor)
    {
        Ammunition nextAmmo = ReloadHelper.FindAmmo(actor, this);
        if (!nextAmmo) return false;
        CurrentAmmunition = nextAmmo;
        return true;
    }

    public bool Load(Ammunition ammunition, out Ammunition unloaded)
    {
        unloaded = null;
        //TODO: check if ammunition is acceptable and if not return false with unloaded = null;
        Unload(out unloaded);
        CurrentAmmunition = ammunition;
        return true;
    }

    public bool Unload(out Ammunition unloaded)
    {
        unloaded = CurrentAmmunition;
        CurrentAmmunition = null;
        return unloaded;
    }

    private void Shoot(Character actor, Vector3 direction)
    {
        int costPerShot = 1;
        if (!CheckAmmo(costPerShot))
        {
            //play SFX of empty gun
            return;
        }

        ProjectileHelper.Shoot(actor, this, direction);

        //play SFX of shot fired
        CurrentAmmunition?.Stack.Subtract(costPerShot);
    }
}
