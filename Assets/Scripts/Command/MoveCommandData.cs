using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JASS Data/Command/Move Command")]
public class MoveCommandData : CommandData
{
    public override bool NeedsPathToTarget()
    {
        return true;
    }
}
