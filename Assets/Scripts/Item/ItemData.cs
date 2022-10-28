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

    [Header("ItemData Abilitys")]
    [SerializeField] private AbilityData ability1;
    [SerializeField] private AbilityData ability2;
    public AbilityData Ability1 { get => ability1; private set => ability1 = value; }
    public AbilityData Ability2 { get => ability2; private set => ability2 = value; }
}
