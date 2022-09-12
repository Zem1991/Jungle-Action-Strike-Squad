using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingNode : AStarNode
{
    //Source of all nodes and positions
    private PathfindingGrid grid;
    public PathfindingGrid Grid { get => grid; private set => grid = value; }

    //Position within the Grid (horizontal, vertical, layer)
    private Vector3Int gridPosition;
    public Vector3Int GridPosition { get => gridPosition; private set => gridPosition = value; }

    //Position within the Scene
    public Vector3 WorldPosition { get => Grid.GetWorldPosition(GridPosition); }

    //If the tile is blocked for everything and everyone
    private bool isBlocked;
    public bool IsBlocked { get => isBlocked; private set => isBlocked = value; }

    //Walking Cost from the Previous Node
    public int WalkingCost
    {
        get
        {
            if (Previous == null) return GCost;
            else return GCost - Previous.GCost;
        }
    }

    public PathfindingNode(PathfindingGrid grid, Vector3Int gridPosition, bool isBlocked)
    {
        Grid = grid;
        GridPosition = gridPosition;
        IsBlocked = isBlocked;
    }

    public override string ToString()
    {
        return GridPosition.ToString();
    }

    public override List<AStarNode> GetNeighbors()
    {
        List<PathfindingNode> neighbours = Grid.GetSlotNeighbors(GridPosition);
        return new List<AStarNode>(neighbours);
    }

    public override bool SkipThis()
    {
        return IsBlocked;
    }
}
