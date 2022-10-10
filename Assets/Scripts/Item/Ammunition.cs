using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : Item
{
    public new AmmunitionData ItemData { get => itemData as AmmunitionData; }

    public void Initialize(AmmunitionData itemData)
    {
        base.Initialize(itemData);
    }
}
