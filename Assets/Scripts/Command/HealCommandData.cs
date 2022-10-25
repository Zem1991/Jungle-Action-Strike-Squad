using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JASS Data/Command/Heal Command")]
public class HealCommandData : CommandData
{
    public override bool NeedsPathToTarget()
    {
        return true;
    }
}
