using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGrid : MonoBehaviour
{
    [Header("Awake")]
    [SerializeField] private Grid grid;
    [SerializeField] private Tilemap terrain;
    [SerializeField] private Tilemap water;
    [SerializeField] private Tilemap moveArea;
    [SerializeField] private Tilemap obstacle;

    private void Awake()
    {
        grid = GetComponent<Grid>();
        Tilemap[] tilemaps = GetComponentsInChildren<Tilemap>();
        terrain = tilemaps[0];
        water = tilemaps[1];
        moveArea = tilemaps[2];
        obstacle = tilemaps[3];
    }

    public void RenderMoveArea(List<Vector3Int> moveAreaPositions)//, Character character)
    {
        ClearMoveArea();
        Tile tile = new Tile
        {
            colliderType = Tile.ColliderType.None,
            sprite = GetMoveAreaSprite()
        };
        foreach (Vector3Int forPos in moveAreaPositions)
        {
            moveArea.SetTile(forPos, tile);
        }
    }

    public void ClearMoveArea()
    {
        moveArea.ClearAllTiles();
    }

    private Sprite GetMoveAreaSprite()
    {
        return HighlightController.Instance.MoveAreaSprite;
    }
}
