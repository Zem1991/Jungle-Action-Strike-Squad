using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandData : ScriptableObject
{
    [Header("CommandData Identification")]
    [SerializeField] private Sprite sprite;
    [SerializeField] private new string name;
    public Sprite Sprite { get => sprite; private set => sprite = value; }
    public string Name { get => name; private set => name = value; }

    [Header("CommandData Cost")]
    //[SerializeField][Min(0)] private int ammoCost;
    [SerializeField] private Percent actionCostPercent;
    //public int AmmoCost { get => ammoCost; private set => ammoCost = value; }
    public Percent ActionCostPercent { get => actionCostPercent; private set => actionCostPercent = value; }

    public abstract bool NeedsPathToTarget();
}
