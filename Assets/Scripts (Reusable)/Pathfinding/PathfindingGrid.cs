using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingGrid : GenericGrid<PathfindingNode>
{
    [Header("PathfindingGrid Scene")]
    [SerializeField] private LevelMap levelMap;
    public LevelMap LevelMap { get => levelMap; private set => levelMap = value; }

    public void Setup(LevelMap levelMap)
    {
        LevelMap = levelMap;
        Func<Vector3Int, Vector3, Transform, PathfindingNode> createSlot = (Vector3Int gridPosition, Vector3 worldPosition, Transform transform) =>
        {
            bool isBlocked = levelMap.TileGrid.CheckPathBlock(gridPosition);
            PathfindingNode pathNode = new PathfindingNode(this, gridPosition, isBlocked);
            return pathNode;
        };
        Setup(levelMap.transform, levelMap.Offset, levelMap.Width, levelMap.Height, levelMap.CellSize, createSlot);
    }
}
