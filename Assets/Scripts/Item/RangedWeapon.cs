using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [Header("RangedWeapon Prefabs")]
    [SerializeField] private Projectile projectilePrefab;
    public Projectile Projectile { get => projectilePrefab; private set => projectilePrefab = value; }

    [Header("RangedWeapon Settings")]
    [SerializeField] private bool needsAmmo;
    [SerializeField] private Ammunition ammunition;
    [SerializeField] private float attackRange;
    public bool NeedsAmmo { get => needsAmmo; private set => needsAmmo = value; }
    public Ammunition Ammunition { get => ammunition; private set => ammunition = value; }
    public float AttackRange { get => attackRange; private set => attackRange = value; }

    public override bool CheckAmmo(int required)
    {
        if (!NeedsAmmo) return true;
        if (!Ammunition) return false;
        int current = Ammunition.Amount.Current;
        return current >= required;
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

        Projectile proj = projectilePrefab;
        int pellets = 1;

        if (NeedsAmmo)
        {
            if (Ammunition.Projectile) proj = Ammunition.Projectile;
            pellets = Ammunition.PelletAmount;
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
        Ammunition?.Amount.Subtract(costPerShot);
    }

    //public Projectile Shoot(Character user, Vector3 direction)
    //{
    //    Projectile result = Instantiate(Projectile, user.transform.position, Quaternion.identity);
    //    result.transform.forward = direction;
    //    return result;
    //}

    public bool Reload()
    {
        //TODO: proper reloading
        Ammunition?.Amount.MakeFull();
        Debug.Log("Reloaded");
        return true;
    }
}
