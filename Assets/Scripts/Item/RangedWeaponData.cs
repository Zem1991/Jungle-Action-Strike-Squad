using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JASS Data/Item/Ranged Weapon")]
public class RangedWeaponData : WeaponData
{
    [Header("RangedWeaponData")]
    [SerializeField] private AmmunitionData defaultAmmo;
    //[SerializeField] private Projectile defaultProjectile;
    public AmmunitionData DefaultAmmo { get => defaultAmmo; private set => defaultAmmo = value; }
    //public Projectile DefaultProjectile { get => defaultProjectile; private set => defaultProjectile = value; }
}
