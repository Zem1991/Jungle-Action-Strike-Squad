using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class LevelMap : MonoBehaviour
{
    [Header("GenericGrid Gizmos")]
    [SerializeField] private Color gridColor = new Color(1F, 1F, 1F, 1F);
    [SerializeField] private Color slotColor = new Color(1F, 1F, 1F, 0.25F);

    [Header("LevelGrid Gizmos")]
    [SerializeField] private Color hasCharacterColor = new Color(0F, 1F, 1F, 0.5F);
    [SerializeField] private Color hasItemColor = new Color(1F, 0F, 1F, 0.5F);

    private void OnDrawGizmos()
    {
        GridGizmos();
        SlotGizmosAll();
    }

    private void GridGizmos()
    {
        Vector3 size = new Vector3(Width, 0, Height);
        size *= CellSize;
        Vector3 center = size / 2F;
        center += Origin;
        Gizmos.color = gridColor;
        Gizmos.DrawWireCube(center - Offset, size + Offset);
    }

    private void SlotGizmosAll()
    {
        if (TileGrid?.Slots == null) return;
        for (int y = 0; y < TileGrid.Slots.GetLength(1); y++)
        {
            for (int x = 0; x < TileGrid.Slots.GetLength(0); x++)
            {
                SlotGizmos(x, y);
            }
        }
    }

    private void SlotGizmos(int x, int y)
    {
        if (TileGrid?.Slots == null) return;
        Vector3Int position = new Vector3Int(x, y, 0);
        Vector3 center = TileGrid.GetWorldPosition(position);
        Vector3 size = Vector3.one * CellSize;
        size.y = 0F;

        Gizmos.color = slotColor;
        Gizmos.DrawWireCube(center, size);

        LevelTile slot = TileGrid.Slots[x, y];
        if (slot?.Character)
        {
            Gizmos.color = hasCharacterColor;
            Gizmos.DrawCube(center, size * 0.6F);
        }
        if (slot?.ItemPickups.Count > 0)
        {
            Gizmos.color = hasItemColor;
            Gizmos.DrawCube(center, size * 0.4F);
        }
    }
}
