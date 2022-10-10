using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    [Header("ItemData Identification")]
    [SerializeField] private Sprite sprite;
    [SerializeField] private new string name;
    public Sprite Sprite { get => sprite; private set => sprite = value; }
    public string Name { get => name; private set => name = value; }

    [Header("ItemData Stack")]
    [SerializeField][Min(1)] private int stackStart = 1;
    [SerializeField][Min(1)] private int stackLimit = 1;
    public int StackStart { get => stackStart; private set => stackStart = value; }
    public int StackLimit { get => stackLimit; private set => stackLimit = value; }

    [Header("ItemData Commands")]
    [SerializeField] private CommandData command1;
    [SerializeField] private CommandData command2;
    public CommandData Command1 { get => command1; private set => command1 = value; }
    public CommandData Command2 { get => command2; private set => command2 = value; }
}
