using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    public const int STRAIGHT = 4;//10;
    public const int DIAGONAL = 6;//15;

    private PathfindingGrid grid;
    public PathfindingGrid Grid { get => grid; private set => grid = value; }

    public Pathfinding(PathfindingGrid grid)//, int width, int height)
    {
        Grid = grid;
    }

    public List<PathfindingNode> FindArea(Vector3Int startPos, int maxCost)
    {
        AStarArea<PathfindingNode> aStar = new AStarArea<PathfindingNode>();
        PathfindingNode startNode = Grid.GetSlot(startPos);
        return aStar.Run(startNode, maxCost, CalculateDistance);
    }

    public List<PathfindingNode> FindPath(Vector3Int startPos, Vector3Int endPos)
    {
        AStarPath<PathfindingNode> aStar = new AStarPath<PathfindingNode>();
        PathfindingNode startNode = Grid.GetSlot(startPos);
        PathfindingNode endNode = Grid.GetSlot(endPos);
        return aStar.Run(startNode, endNode, CalculateDistance, CalculateDistance);
    }

    private int CalculateDistance(PathfindingNode from, PathfindingNode to)
    {
        int xDist = Mathf.Abs(from.GridPosition.x - to.GridPosition.x);
        int yDist = Mathf.Abs(from.GridPosition.y - to.GridPosition.y);
        int remaining = Mathf.Abs(xDist - yDist);
        int diagonalCost = DIAGONAL * Mathf.Min(xDist, yDist);
        int straightCost = STRAIGHT * remaining;
        return diagonalCost + straightCost;
    }
}
