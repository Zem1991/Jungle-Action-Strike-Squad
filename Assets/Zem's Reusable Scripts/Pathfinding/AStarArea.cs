using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarArea<T> where T : AStarNode
{
    public List<T> Run(T start, int maxCost, Func<T, T, int> distance)
    {
        List<T> openList = new List<T> { start };
        //List<T> closedList = new List<T>();

        start.Set(0, 0, null);

        List<T> result = new List<T> { start };
        while (openList.Count > 0)
        {
            T currentNode = openList[0];
            openList.Remove(currentNode);
            //closedList.Add(currentNode);

            List<AStarNode> neighbors = currentNode.GetNeighbors();
            foreach (T forNeighbor in neighbors)
            {
                //if (closedList.Contains(forNeighbor)) continue;

                if (forNeighbor.SkipThis())
                {
                    //closedList.Add(forNeighbor);
                    continue;
                }

                int tentativeG = currentNode.GCost + distance(currentNode, forNeighbor);
                if (tentativeG >= forNeighbor.GCost) continue;

                if (tentativeG > maxCost) continue;

                forNeighbor.Set(tentativeG, 0, currentNode);
                if (!result.Contains(forNeighbor))
                {
                    openList.Add(forNeighbor);
                    result.Add(forNeighbor);
                }
            }
        }

        return result;
    }

    //public List<PathfindingNode> FindArea(Vector2Int startPos, int maxCost)
    //{
    //    PathfindingNode startNode = grid.GetSlot(startPos);
    //    maxCost = 8;

    //    List<PathfindingNode> openList = new List<PathfindingNode>();
    //    List<PathfindingNode> closedList = new List<PathfindingNode>();
    //    List<PathfindingNode> result = new List<PathfindingNode>();

    //    openList.Add(startNode);
    //    result.Add(startNode);

    //    while (openList.Count > 0)
    //    {
    //        PathfindingNode currentNode = openList[0];
    //        openList.Remove(currentNode);
    //        closedList.Add(currentNode);

    //        List<PathfindingNode> neighbors = grid.GetSlotNeighbors(currentNode.GridPosition);
    //        foreach (PathfindingNode forNeighbor in neighbors)
    //        {
    //            if (closedList.Contains(forNeighbor)) continue;
    //            closedList.Add(forNeighbor);

    //            //if (forNeighbor.IsBlocked)
    //            //{
    //            //    closedList.Add(forNeighbor);
    //            //    continue;
    //            //}

    //            int cost = CalculateDistance(currentNode, forNeighbor);
    //            int gCost = currentNode.GCost + cost;
    //            forNeighbor.Set(cost, gCost, 0, currentNode);

    //            if (gCost > maxCost)
    //            {
    //                closedList.Add(forNeighbor);
    //                continue;
    //            }

    //            openList.Add(forNeighbor);
    //            result.Add(forNeighbor);
    //        }
    //    }
    //    return result;
    //}
}
