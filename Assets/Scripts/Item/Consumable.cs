using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public new ConsumableData ItemData { get => itemData as ConsumableData; }

    public void Initialize(ConsumableData itemData)
    {
        base.Initialize(itemData);
    }

    public override void AfterUse()
    {
        throw new System.NotImplementedException();
    }
}
