using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private DamageEffect damage;
    //Explosion
    //Trajectory
    public DamageEffect Damage { get => damage; private set => damage = value; }
    //Explosion
    //Trajectory

    [Header("Runtime")]
    [SerializeField] private Character user;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Action onFinish;
    public Character User { get => user; private set => user = value; }
    public Weapon Weapon { get => weapon; private set => weapon = value; }
    public Action OnFinish { get => onFinish; private set => onFinish = value; }
    
    public void Setup(Character user, Weapon weapon, Action onFinish)
    {
        //Physics.IgnoreCollision(collider, user.GetComponent<Collider>());
        User = user;
        Weapon = weapon;
        OnFinish = onFinish;
    }
}
