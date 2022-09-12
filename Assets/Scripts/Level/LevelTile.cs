using System.Collections;
using System.Collections.Generic;
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
    public Character Character { get => character; private set => character = value; }
    
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

    public bool AddCharacter(Character character)
    {
        if (Character) return false;
        Character = character;
        return true;
    }

    public bool RemoveCharacter(Character character)
    {
        if (!Character) return false;
        if (Character != character) return false;
        Character = null;
        return true;
    }
}
