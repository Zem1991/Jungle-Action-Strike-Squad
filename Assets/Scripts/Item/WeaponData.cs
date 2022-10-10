using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponData : ItemData
{
    [Header("WeaponData")]
    [SerializeField] private bool isSidearm;
    [SerializeField] private float range = 20F;
    [SerializeField] private float speed = 0.5F;
    [SerializeField][Range(0F, 2F)] private float accuracyModifier = 1F;
    public bool IsSidearm { get => isSidearm; private set => isSidearm = value; }
    public float Range { get => range; private set => range = value; }
    public float Speed { get => speed; private set => speed = value; }
    public float AccuracyModifier { get => accuracyModifier; set => accuracyModifier = value; }
}
