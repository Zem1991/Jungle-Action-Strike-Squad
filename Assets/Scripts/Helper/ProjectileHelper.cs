using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProjectileHelper
{
    public static void Shoot(Character actor, RangedWeapon rangedWeapon, Vector3 attackDirection)
    {
        Ammunition currentAmmunition = rangedWeapon.CurrentAmmunition;
        RangedWeaponData rangedWeaponData = rangedWeapon.ItemData;

        Projectile projectilePrefab;
        int pellets;
        if (rangedWeaponData.NeedsAmmo)
        {
            projectilePrefab = currentAmmunition.ItemData.Projectile;
            pellets = currentAmmunition.ItemData.PelletAmount;
        }
        else
        {
            projectilePrefab = rangedWeaponData.DefaultAmmo.Projectile;
            pellets = rangedWeaponData.DefaultAmmo.PelletAmount;
        }

        List<Vector3> pelletDirectionList = new List<Vector3>();
        pelletDirectionList.Add(attackDirection);
        for (int i = 1; i < pellets; i++)
        {
            pelletDirectionList.Add(attackDirection);
        }

        Vector3 position = actor.GetPosition();
        Transform parent = null;
        for (int i = 0; i < pellets; i++)
        {
            Vector3 pelletDirection = pelletDirectionList[i];
            Quaternion rotation = Quaternion.LookRotation(pelletDirection, Vector3.up);

            Projectile newProj = Object.Instantiate(projectilePrefab, position, rotation, parent);
            newProj.Setup(actor, rangedWeapon, null);
        }
    }
}
