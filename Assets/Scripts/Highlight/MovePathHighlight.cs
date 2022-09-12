using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePathHighlight : Highlight
{
    [SerializeField] private List<Vector3> positions;

    public override void Refresh()
    {
        ActionController actionController = ActionController.Instance;
        if (actionController.HasCurrent())
        {
            Hide();
            return;
        }

        CommandController commandController = CommandController.Instance;
        Command command = commandController.Current;
        if (command && command.NeedsPathHighlight)
        {
            positions = PathfindingHelper.GetWorldPositions(commandController.Path);
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
