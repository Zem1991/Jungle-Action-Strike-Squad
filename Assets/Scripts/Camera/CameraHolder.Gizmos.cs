using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CameraHolder : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        LevelMap levelMap = LevelController.Instance?.LevelMap;
        LevelGrid levelGrid = LevelController.Instance?.GetLevelGrid();
        float cellSize = levelMap ? levelGrid.CellSize : 0.5F;

        Vector3 size = Vector3.one * cellSize;
        size.y = 0;
        Vector3 center = transform.position;
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(center, size);
        Gizmos.DrawWireCube(center, size * 0.9F);
    }
}
