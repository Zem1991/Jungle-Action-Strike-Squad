using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JASS Data/Item/Ranged Weapon")]
public class RangedWeaponData : WeaponData
{
    [Header("RangedWeaponData")]
    [SerializeField][Min(1)] private int magazineSize = 1;
    [SerializeField] private bool needsAmmo = true;
    [SerializeField] private AmmunitionData defaultAmmo;
    //[SerializeField] private Projectile defaultProjectile;
    public int MagazineSize { get => magazineSize; set => magazineSize = value; }
    public bool NeedsAmmo { get => needsAmmo; private set => needsAmmo = value; }
    public AmmunitionData DefaultAmmo { get => defaultAmmo; private set => defaultAmmo = value; }
    //public Projectile DefaultProjectile { get => defaultProjectile; private set => defaultProjectile = value; }
}
