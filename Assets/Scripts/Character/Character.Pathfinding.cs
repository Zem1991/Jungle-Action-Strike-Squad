using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Character : MonoBehaviour
{
    [Header("Pathfinding")]
    [SerializeField] private LevelTile levelGridSlot;
    public LevelTile LevelGridSlot { get => levelGridSlot; private set => levelGridSlot = value; }

    public bool Pathfind(LevelTile targetSlot, out List<PathfindingNode> path)
    {
        PathfindingGrid pathfindingGrid = LevelController.Instance.LevelMap.GetPathfindingGrid();
        Pathfinding pathfinding = new Pathfinding(pathfindingGrid);
        path = pathfinding.FindPath(LevelGridSlot.GridPosition, targetSlot.GridPosition);
        return path != null;
    }

    public void RefreshGridPosition()
    {
        LevelGrid levelGrid = LevelController.Instance.GetLevelGrid();
        Vector3Int gridPos = levelGrid.GetGridPosition(transform.position);
        LevelTile slot = levelGrid.GetSlot(gridPos);
        RefreshGridPosition(slot);
    }

    private void RefreshGridPosition(LevelTile nextSlot)
    {
        if (LevelGridSlot)
        {
            if (LevelGridSlot == nextSlot) return;
            LevelGridSlot.RemoveCharacter(this);
        }
        LevelGridSlot = nextSlot;
        LevelGridSlot.AddCharacter(this);
    }
}
