using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JASS/Command Data")]
public class CommandData : ScriptableObject
{
    [Header("Identification")]
    [SerializeField] private Sprite sprite;
    [SerializeField] private new string name;
    public Sprite Sprite { get => sprite; private set => sprite = value; }
    public string Name { get => name; private set => name = value; }

    [Header("Settings")]
    [SerializeField] private bool needsPathHighlight;// = true;
    [SerializeField][Range(0, 100)] private int accuracy;
    public bool NeedsPathHighlight { get => needsPathHighlight; private set => needsPathHighlight = value; }
    public int Accuracy { get => accuracy; private set => accuracy = value; }

    [Header("Cost")]
    [SerializeField][Min(0)] private int ammoCost;
    [SerializeField][Range(0, 100)] private int actionCostPercent;
    public int AmmoCost { get => ammoCost; private set => ammoCost = value; }
    public int ActionCostPercent { get => actionCostPercent; private set => actionCostPercent = value; }
}
