using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    private static readonly int terrainSortingLayer = SortingLayer.GetLayerValueFromName("Terrain");
    private static readonly int waterSortingLayer = SortingLayer.GetLayerValueFromName("Water");
    private static readonly int obstacleSortingLayer = SortingLayer.GetLayerValueFromName("Obstacle");
    public static int TerrainSortingLayer => terrainSortingLayer;
    public static int WaterSortingLayer => waterSortingLayer;
    public static int ObstacleSortingLayer => obstacleSortingLayer;

    private static readonly LayerMask interactableMask = LayerMask.GetMask("Interactable");
    private static readonly LayerMask itemMask = LayerMask.GetMask("Item");
    private static readonly LayerMask characterMask = LayerMask.GetMask("Character");
    public static LayerMask InteractableMask => interactableMask;
    public static LayerMask ItemMask => itemMask;
    public static LayerMask CharacterMask => characterMask;
}
