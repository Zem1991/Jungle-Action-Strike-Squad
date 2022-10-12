using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarPath<T> where T : AStarNode
{
    public List<T> Run(T start, T goal, Func<T, T, int> heuristic, Func<T, T, int> distance)
    {
        List<T> openList = new List<T> { start };
        //List<T> closedList = new List<T>();

        int hCostStart = heuristic(start, goal);
        start.Set(0, hCostStart, null);

        while (openList.Count > 0)
        {
            T currentNode = GetLowestF(openList);
            if (currentNode == goal)
            {
                return ReconstructPath(goal);
            }
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

                int hCostCurrent = heuristic(forNeighbor, goal);
                forNeighbor.Set(tentativeG, hCostCurrent, currentNode);
                if (!openList.Contains(forNeighbor)) openList.Add(forNeighbor);
            }
        }
        return null;
    }

    private T GetLowestF(List<T> nodeList)
    {
        //TODO: have a binary tree to increase performance
        T result = nodeList[0];
        foreach (T item in nodeList)
        {
            if (item.FCost < result.FCost)
                result = item;
        }
        return result;
    }

    private List<T> ReconstructPath(T endNode)
    {
        List<T> result = new List<T> { endNode };
        T current = endNode;
        while (current.Previous != null)
        {
            T preivous = (T)current.Previous;
            result.Add(preivous);
            current = preivous;
        }
        result.Reverse();
        return result;
    }
}
