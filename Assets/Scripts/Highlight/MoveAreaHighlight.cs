using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveAreaHighlight : Highlight
{
    [Header("Runtime")]
    [SerializeField] private List<Vector3Int> moveAreaPositions;
    public List<Vector3Int> MoveAreaPositions { get => moveAreaPositions; private set => moveAreaPositions = value; }

    public override void Refresh()
    {
        CommandController actionController = CommandController.Instance;
        if (actionController.HasCurrent())
        {
            TilemapGrid tilemapGrid = GetTilemapGrid();
            tilemapGrid.ClearMoveArea();
            Hide();
            return;
        }

        Character character = SelectionController.Instance.Get();
        if (character)
        {
            PathfindingGrid pathfindingGrid = LevelController.Instance.LevelMap.GetPathfindingGrid();
            Pathfinding pathfinding = new Pathfinding(pathfindingGrid);
            List<PathfindingNode> positions = pathfinding.FindArea(character.LevelGridSlot.GridPosition, character.ActionPoints.Current);
            List<Vector3Int> gridPositions = PathfindingHelper.GetGridPositions(positions);

            TilemapGrid tilemapGrid = GetTilemapGrid();
            tilemapGrid.RenderMoveArea(gridPositions);
            Show();
        }
        else
        {
            TilemapGrid tilemapGrid = GetTilemapGrid();
            tilemapGrid.ClearMoveArea();
            Hide();
        }
    }

    private TilemapGrid GetTilemapGrid()
    {
        TilemapGrid result = LevelController.Instance.LevelMap.TilemapGrid;
        return result;
    }
}
