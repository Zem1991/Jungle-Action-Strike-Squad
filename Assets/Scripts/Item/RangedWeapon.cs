using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    public new RangedWeaponData ItemData { get => itemData as RangedWeaponData; }

    public void Initialize(RangedWeaponData itemData)
    {
        base.Initialize(itemData);
    }

    [Header("RangedWeapon Ammunition")]
    [SerializeField] private Ammunition currentAmmunition;
    public Ammunition CurrentAmmunition { get => currentAmmunition; private set => currentAmmunition = value; }

    public override bool CheckAmmo(int required)
    {
        if (!NeedsAmmo()) return true;
        if (!CurrentAmmunition) return false;
        int current = CurrentAmmunition.Stack.Current;
        return current >= required;
    }

    public bool NeedsAmmo()
    {
        return ItemData.DefaultAmmo.Type != AmmunitionType.NONE;
    }

    public bool Reload()
    {
        //TODO: proper reloading
        CurrentAmmunition?.Stack.MakeFull();
        Debug.Log("Reloaded");
        return true;
    }

    public override void Attack(Character actor)
    {
        Vector3 direction = actor.GetDirection();
        Shoot(actor, direction);
    }

    private void Shoot(Character actor, Vector3 direction)
    {
        int costPerShot = 1;
        if (!CheckAmmo(costPerShot))
        {
            //play SFX of empty gun
            return;
        }

        Projectile proj = ItemData.DefaultAmmo.Projectile;
        int pellets = 1;

        if (NeedsAmmo())
        {
            if (CurrentAmmunition.ItemData.Projectile) proj = CurrentAmmunition.ItemData.Projectile;
            pellets = CurrentAmmunition.ItemData.PelletAmount;
        }

        List<Vector3> pelletDirectionList = new List<Vector3>();
        pelletDirectionList.Add(direction);
        for (int i = 1; i < pellets; i++)
        {
            pelletDirectionList.Add(direction);
        }

        Vector3 position = actor.GetPosition();
        Transform parent = null;
        for (int i = 0; i < pellets; i++)
        {
            Vector3 pelletDirection = pelletDirectionList[i];
            Quaternion rotation = Quaternion.LookRotation(pelletDirection, Vector3.up);

            Projectile newProj = Instantiate(proj, position, rotation, parent);
            newProj.Setup(actor, this, null);
        }

        //play SFX of shot fired
        CurrentAmmunition?.Stack.Subtract(costPerShot);
    }

    //public Projectile Shoot(Character user, Vector3 direction)
    //{
    //    Projectile result = Instantiate(Projectile, user.transform.position, Quaternion.identity);
    //    result.transform.forward = direction;
    //    return result;
    //}
}
