using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class LevelTile : MonoBehaviour
{
    private TextMesh textMesh;

    [Header("Start")]
    [SerializeField] private LevelMap grid;
    [SerializeField] private Vector3Int gridPosition;
    public LevelMap Grid { get => grid; private set => grid = value; }
    public Vector3Int GridPosition { get => gridPosition; private set => gridPosition = value; }
    
    [Header("Runtime")]
    [SerializeField] private Character character;
    [SerializeField] private List<ItemPickup> itemPickups = new List<ItemPickup>();
    public Character Character { get => character; private set => character = value; }
    public List<ItemPickup> ItemPickups { get => itemPickups; private set => itemPickups = value; }

    private void Awake()
    {
        textMesh = GetComponentInChildren<TextMesh>();
    }

    public void Setup(LevelMap grid, Vector3Int gridPosition)
    {
        Grid = grid;
        GridPosition = gridPosition;
        RefreshTextMesh();
    }

    public void RefreshTextMesh()
    {
        string positionString = GridPosition.ToString();
        name = positionString;
        textMesh.text = positionString;
    }

    //public string Read()
    public override string ToString()
    {
        string result = $"{GridPosition}";
        if (Character) result += $"({Character})";
        return result;
    }

    public bool Add(Character character)
    {
        if (!character) return false;
        if (Character) return false;
        Character = character;
        return true;
    }

    public bool Remove(Character character)
    {
        if (!character) return false;
        if (!Character) return false;
        if (Character != character) return false;
        Character = null;
        return true;
    }

    public bool Add(ItemPickup item)
    {
        if (!item) return false;
        if (ItemPickups.Contains(item)) return false;
        ItemPickups.Add(item);
        return true;
    }

    public bool Remove(ItemPickup item)
    {
        if (!item) return false;
        if (!ItemPickups.Contains(item)) return false;
        ItemPickups.Remove(item);
        return true;
    }
}
