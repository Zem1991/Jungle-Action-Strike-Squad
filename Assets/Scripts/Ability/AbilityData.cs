using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityData : ScriptableObject
{
    [Header("AbilityData Identification")]
    [SerializeField] private Sprite sprite;
    [SerializeField] private new string name;
    public Sprite Sprite { get => sprite; private set => sprite = value; }
    public string Name { get => name; private set => name = value; }

    [Header("AbilityData Settings")]
    [SerializeField] private RangeType rangeType;
    [SerializeField] private TargetType targetType;
    [SerializeField] private Percent actionCost;
    public RangeType RangeType { get => rangeType; private set => rangeType = value; }
    public TargetType TargetType { get => targetType; private set => targetType = value; }
    public Percent ActionCost { get => actionCost; private set => actionCost = value; }

    public bool NeedsPathToTarget()
    {
        return RangeType == RangeType.MELEE;
    }
}
