using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEffect : Effect
{
    [Header("Settings")]
    [SerializeField] private Projectile projectile;
    public Projectile Projectile { get => projectile; private set => projectile = value; }

    public override bool Apply(Character actor, Item item, Vector3 position, Character target)
    {
        throw new System.NotImplementedException();
    }
}
