using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class PathfindingHelper
{
    public static List<Vector3> GetWorldPositions(List<PathfindingNode> pathNodes)
    {
        List<Vector3> result = new List<Vector3>();
        if (pathNodes != null)
        {
            List<Vector3> values = pathNodes.Select(pos => pos.WorldPosition).ToList();
            result.AddRange(values);
        }
        return result;
    }

    public static List<Vector3Int> GetGridPositions(List<PathfindingNode> pathNodes)
    {
        List<Vector3Int> result = new List<Vector3Int>();
        if (pathNodes != null)
        {
            List<Vector3Int> values = pathNodes.Select(pos => pos.GridPosition).ToList();
            result.AddRange(values);
        }
        return result;
    }
}
