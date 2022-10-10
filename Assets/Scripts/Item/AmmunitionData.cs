using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JASS Data/Item/Ammunition")]
public class AmmunitionData : ItemData
{
    [Header("AmmunitionData")]
    [SerializeField] private AmmunitionType type;
    [SerializeField] private Projectile projectile;
    [SerializeField] private int pelletAmount = 1;
    [SerializeField] private int pelletSpread = 0;
    public AmmunitionType Type { get => type; private set => type = value; }
    public Projectile Projectile { get => projectile; private set => projectile = value; }
    public int PelletAmount { get => pelletAmount; private set => pelletAmount = value; }
    public int PelletSpread { get => pelletSpread; private set => pelletSpread = value; }
}
