using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CursorHolder : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        LevelMap levelMap = LevelController.Instance?.LevelMap;
        LevelGrid levelGrid = LevelController.Instance?.GetLevelGrid();
        float cellSize = levelMap ? levelGrid.CellSize : 0.5F;

        Vector3 center = transform.position;
        Vector3 size = Vector3.one * cellSize;
        size.y = 0;

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(center, 0.2F);

        if (!levelMap) return;
        Vector3Int gridPos = levelGrid.GetGridPosition(center);
        bool drawSlot = levelGrid.IsInsideGrid(gridPos);
        if (!drawSlot) return;

        center = levelGrid.GetWorldPosition(gridPos);
        Gizmos.DrawWireCube(center, size * 0.95F);
    }
}
