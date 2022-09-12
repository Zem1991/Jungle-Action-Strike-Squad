using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class LevelMap : MonoBehaviour
{
    public Vector3 Offset { get => new Vector3(1, 0, 1) * CellSize / 2F; }

    [Header("Prefabs")]
    [SerializeField] private LevelTile tilePrefab;

    [Header("Scene")]
    [SerializeField] private TilemapGrid tilemapGrid;
    [SerializeField] private Transform itemHolder;
    [SerializeField] private Transform localPlayerHolder;
    [SerializeField] private Transform enemyPlayerHolder;
    public TilemapGrid TilemapGrid { get => tilemapGrid; private set => tilemapGrid = value; }
    public Transform ItemHolder { get => itemHolder; private set => itemHolder = value; }
    public Transform LocalPlayerHolder { get => localPlayerHolder; private set => localPlayerHolder = value; }
    public Transform EnemyPlayerHolder { get => enemyPlayerHolder; private set => enemyPlayerHolder = value; }

    [Header("Setup")]
    [SerializeField] private Vector3 origin = Vector3.zero;
    [SerializeField] private int width = 40;
    [SerializeField] private int height = 40;
    [SerializeField] private float cellSize = 2F;
    public Vector3 Origin { get => origin; private set => origin = value; }
    public int Width { get => width; private set => width = value; }
    public int Height { get => height; private set => height = value; }
    public float CellSize { get => cellSize; private set => cellSize = value; }

    [Header("Awake")]
    [SerializeField] private LevelGrid tileGrid;
    public LevelGrid TileGrid { get => tileGrid; set => tileGrid = value; }

    private void Awake()
    {
        TileGrid = new LevelGrid();
        TileGrid.Setup(this, tilePrefab);
    }

    public PathfindingGrid GetPathfindingGrid()
    {
        PathfindingGrid grid = new PathfindingGrid();
        grid.Setup(this);
        return grid;
    }
}
