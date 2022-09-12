using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Weapon : Item
{
    [Header("Weapon: Combat")]
    [SerializeField] private float range = 20F;
    [SerializeField] private float speed = 0.5F;
    [SerializeField] private float accuracy = 1F;
    [SerializeField] private int damageMin = 10;
    [SerializeField] private int damageMax = 15;
    public float Range { get => range; private set => range = value; }
    public float Speed { get => speed; private set => speed = value; }
    public float Accuracy { get => accuracy; set => accuracy = value; }
    public int DamageMin { get => damageMin; private set => damageMin = value; }
    public int DamageMax { get => damageMax; private set => damageMax = value; }
}
