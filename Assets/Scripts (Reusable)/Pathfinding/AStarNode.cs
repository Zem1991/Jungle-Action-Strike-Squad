using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AStarNode
{
    //From where this node was found before
    private AStarNode previous;
    public AStarNode Previous { get => previous; private set => previous = value; }

    //Walking Cost from the Start Node
    private int gCost;
    public int GCost { get => gCost; private set => gCost = value; }

    //Heuristic Cost to reach End Node
    private int hCost;
    public int HCost { get => hCost; private set => hCost = value; }

    //Best guess of cost for this Node (G + H)
    public int FCost { get => GCost + HCost; }

    //public void Clear()
    public AStarNode()
    {
        Set(int.MaxValue, 0, null);
    }

    public void Set(int g, int h, AStarNode previous)
    {
        GCost = g;
        HCost = h;
        Previous = previous;
    }

    public abstract List<AStarNode> GetNeighbors();
    public abstract bool SkipThis();
}
