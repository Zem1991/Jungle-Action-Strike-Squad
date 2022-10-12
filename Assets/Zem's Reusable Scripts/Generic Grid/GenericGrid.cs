using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericGrid<T>
{
    public Vector3 Origin { get => Transform.position; }
    public Vector3 WorldSize { get => new Vector3(Width, 0, Height) * CellSize; }
    public T[,] Slots { get; protected set; }

    [Header("Setup")]
    [SerializeField] private Transform transform;
    [SerializeField] private Vector3 offset;
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float cellSize;
    public Transform Transform { get => transform; private set => transform = value; }
    public Vector3 Offset { get => offset; private set => offset = value; }
    public int Width { get => width; private set => width = value; }
    public int Height { get => height; private set => height = value; }
    public float CellSize { get => cellSize; private set => cellSize = value; }

    protected void Setup(Transform transform, Vector3 offset, int width, int height, float cellSize, Func<Vector3Int, Vector3, Transform, T> createSlot)
    {
        Transform = transform;
        Offset = offset;
        Width = width;
        Height = height;
        CellSize = cellSize;

        Slots = new T[width, height];
        for (int y = 0; y < Slots.GetLength(1); y++)
        {
            for (int x = 0; x < Slots.GetLength(0); x++)
            {
                Vector3Int gridPosition = new Vector3Int(x, y, 0);
                Vector3 worldPosition = GetWorldPosition(gridPosition);
                Slots[x, y] = createSlot(gridPosition, worldPosition, transform);
            }
        }
    }

    public Vector3 SnapPosition(Vector3 worldPosition)
    {
        Vector3 levelSize = WorldSize;
        Vector3 result = new Vector3
        {
            x = Mathf.Clamp(worldPosition.x, 0, levelSize.x - CellSize),
            z = Mathf.Clamp(worldPosition.z, 0, levelSize.z - CellSize)
            //x = Mathf.Clamp(worldPosition.x, 0 + Offset.x, levelSize.x - Offset.x),
            //z = Mathf.Clamp(worldPosition.z, 0 + Offset.z, levelSize.z - Offset.z)
        };
        return result;
    }

    //TODO: check where this is really needed, because nodes can have a WorldPosition
    public Vector3 GetWorldPosition(Vector3Int gridPosition)
    {
        return new Vector3(gridPosition.x, 0, gridPosition.y) * CellSize + Origin;
    }

    public Vector3Int GetGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.RoundToInt((worldPosition - Origin).x / CellSize);
        int y = Mathf.RoundToInt((worldPosition - Origin).z / CellSize);
        return new Vector3Int(x, y, 0);
    }

    public bool IsInsideGrid(Vector3Int gridPosition)
    {
        if (gridPosition.x < 0) return false;
        if (gridPosition.y < 0) return false;
        if (gridPosition.x >= Width) return false;
        if (gridPosition.y >= Height) return false;
        return true;
    }

    public T GetSlot(Vector3Int gridPosition)
    {
        if (!IsInsideGrid(gridPosition)) return default(T);
        return Slots[gridPosition.x, gridPosition.y];
    }

    public List<T> GetSlotNeighbors(Vector3Int gridPosition)
    {
        //TODO: have pre-calculated neighbors to increase performance
        //TODO: diagonals as an option
        if (!IsInsideGrid(gridPosition)) return null;
        List<T> result = new List<T>();
        for (int y = gridPosition.y - 1; y <= gridPosition.y + 1; y++)
        {
            for (int x = gridPosition.x - 1; x <= gridPosition.x + 1; x++)
            {
                Vector3Int current = new Vector3Int(x, y, 0);
                if (current == gridPosition) continue;
                if (!IsInsideGrid(current)) continue;
                result.Add(Slots[x, y]);
            }
        }
        return result;
    }
}
