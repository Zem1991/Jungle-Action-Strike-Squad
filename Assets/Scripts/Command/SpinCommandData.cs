using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JASS Data/Command/Spin Command")]
public class SpinCommandData : CommandData
{
    public override bool NeedsPathToTarget()
    {
        return false;
    }
}
