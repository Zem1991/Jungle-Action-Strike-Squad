using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    private void UpdateLifespan()
    {
        LevelGrid levelGrid = LevelController.Instance.GetLevelGrid();
        Vector3Int gridPosition = levelGrid.GetGridPosition(transform.position);
        bool isInside = levelGrid.IsInsideGrid(gridPosition);
        if (!isInside) Destroy();
    }
}
