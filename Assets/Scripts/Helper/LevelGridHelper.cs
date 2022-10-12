using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelGridHelper
{
    public static List<LevelTile> GetFromRadius(LevelGrid levelGrid, Vector3Int center, int radius)
    {
        if (radius < 0) radius = 0;
        List<Vector3Int> offsets = Vector3IntHelper.GetFromRadius(radius);
        List<LevelTile> result = new List<LevelTile>();
        foreach (Vector3Int offset in offsets)
        {
            Vector3Int gridPosition = center + offset;
            LevelTile tile = levelGrid.GetSlot(gridPosition);
            result.Add(tile);
        }
        return result;
    }
}
