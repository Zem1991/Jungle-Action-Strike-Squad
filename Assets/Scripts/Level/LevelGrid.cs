using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGrid : GenericGrid<LevelTile>
{
    [Header("LevelGrid Scene")]
    [SerializeField] private LevelMap levelMap;
    public LevelMap LevelMap { get => levelMap; private set => levelMap = value; }

    public void Setup(LevelMap levelMap, LevelTile tilePrefab)
    {
        LevelMap = levelMap;
        Func<Vector3Int, Vector3, Transform, LevelTile> createSlot = (Vector3Int gridPosition, Vector3 worldPosition, Transform transform) =>
        {
            LevelTile gridSlot = UnityEngine.Object.Instantiate(tilePrefab, worldPosition, Quaternion.identity, transform);
            gridSlot.Setup(levelMap, gridPosition);
            return gridSlot;
        };
        Setup(levelMap.transform, levelMap.Offset, levelMap.Width, levelMap.Height, levelMap.CellSize, createSlot);
    }

    public bool CheckPathBlock(Vector3Int gridPosition)
    {
        Tilemap[] tilemaps = LevelMap.TilemapGrid.GetComponentsInChildren<Tilemap>();
        List<Tilemap> tilemapList = new List<Tilemap>(tilemaps);

        Vector3 worldPosition = GetWorldPosition(gridPosition);
        int noTileCount = 0;
        foreach (Tilemap tilemap in tilemapList)
        {
            Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
            bool hasTile = tilemap.HasTile(cellPosition);
            if (!hasTile)
            {
                noTileCount++;
                continue;
            }

            TilemapRenderer tilemapRenderer = tilemap.GetComponent<TilemapRenderer>();
            if (tilemapRenderer.sortingLayerID == Constants.WaterSortingLayer) return true;
            if (tilemapRenderer.sortingLayerID == Constants.ObstacleSortingLayer) return true;

            Tile tile = tilemap.GetTile<Tile>(cellPosition);
            bool hasCollider = tile.colliderType != Tile.ColliderType.None;
            if (hasCollider) return true;
        }
        return noTileCount >= tilemapList.Count;
    }
}
