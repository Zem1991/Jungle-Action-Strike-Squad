using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : Item
{
    [Header("Ammunition General")]
    [SerializeField] private AmmunitionType type;
    [SerializeField] private Resource amount;
    public AmmunitionType Type { get => type; private set => type = value; }
    public Resource Amount { get => amount; private set => amount = value; }
    
    [Header("Ammunition Projectile")]
    [SerializeField] private Projectile projectile;
    [SerializeField] private int pelletAmount = 1;
    [SerializeField] private int pelletSpread = 0;
    public Projectile Projectile { get => projectile; private set => projectile = value; }
    public int PelletAmount { get => pelletAmount; private set => pelletAmount = value; }
    public int PelletSpread { get => pelletSpread; private set => pelletSpread = value; }

    //public void Shoot(Character actor, Weapon2 weapon, Vector3 direction)
    //{
    //    if (current <= 0)
    //    {
    //        return;
    //    }

    //    int amount = Mathf.Max(pelletAmount, 1);
    //    Vector3 position = actor.GetPosition();
    //    Transform parent = null;

    //    List<Vector3> pelletDirectionList = new List<Vector3>();
    //    for (int i = 0; i < amount; i++)
    //    {
    //        pelletDirectionList.Add(direction);
    //    }

    //    for (int i = 0; i < amount; i++)
    //    {
    //        Vector3 pelletDirection = pelletDirectionList[i];
    //        Quaternion rotation = Quaternion.LookRotation(pelletDirection, Vector3.up);

    //        Projectile2 proj = Instantiate(projectile, position, rotation, parent);
    //        proj.Initialize(actor, weapon);
    //    }

    //    current--;
    //}
}
