using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePathHighlight : Highlight
{
    [SerializeField] private List<Vector3> positions;

    public override void Refresh()
    {
        CommandController actionController = CommandController.Instance;
        if (actionController.HasCurrent())
        {
            Hide();
            return;
        }

        AbilityController abilityController = AbilityController.Instance;
        AbilityData ability = abilityController.Current.AbilityData;
        if (ability && ability.NeedsPathToTarget())
        {
            positions = PathfindingHelper.GetWorldPositions(abilityController.Path);
            lineRenderer.positionCount = positions.Count;
            lineRenderer.SetPositions(positions.ToArray());
            Show();
        }
        else
        {
            Hide();
        }
    }
}
