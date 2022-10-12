using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : Item
{
    public new ToolData ItemData { get => itemData as ToolData; }

    public void Initialize(ToolData itemData)
    {
        base.Initialize(itemData);
    }

    public override void AfterUse()
    {
        throw new System.NotImplementedException();
    }
}
