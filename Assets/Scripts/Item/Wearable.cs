using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Wearable : Item
{
    public new WearableData ItemData { get => itemData as WearableData; }

    public void Initialize(WearableData itemData)
    {
        base.Initialize(itemData);
    }
}
