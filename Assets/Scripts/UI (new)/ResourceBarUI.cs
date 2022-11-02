using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResourceBarUI : FillBarUI<Resource>
{
    protected override float GetFillAmount(Resource thing)
    {
        return thing.GetFillAmount();
    }

    protected override string GetTextAmount(Resource thing)
    {
        return thing.GetTextAmount();
    }
}
