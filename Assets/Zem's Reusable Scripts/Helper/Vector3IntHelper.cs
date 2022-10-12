using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3IntHelper
{
    public static List<Vector3Int> GetFromRadius(int radius)
    {
        List<Vector3Int> result = new List<Vector3Int>();
        if (radius < 0) return result;
        for (int z = -radius; z <= radius; z++)
        {
            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    Vector3Int current = new Vector3Int(x, y, z);
                    float distance = Vector3Int.Distance(Vector3Int.zero, current);
                    if (distance > radius) continue;
                    result.Add(current);
                }
            }
        }
        return result;
    }
}
