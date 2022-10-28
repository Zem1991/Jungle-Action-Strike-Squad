using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CameraController : AbstractSingleton<CameraController>, IReadableForUI
{
    [Header("Awake")]
    [SerializeField] private CameraHolder cameraHolder;

    [Header("Runtime")]
    [SerializeField] private LevelTile levelGridSlot;
    public LevelTile LevelGridSlot { get => levelGridSlot; private set => levelGridSlot = value; }

    protected override void Awake()
    {
        base.Awake();
        cameraHolder = GetComponentInChildren<CameraHolder>();
    }

    private void LateUpdate()
    {
        LevelGrid levelGrid = LevelController.Instance.GetLevelGrid();
        Vector3 worldPos = cameraHolder.transform.position;
        Vector3Int GridPosition = levelGrid.GetGridPosition(worldPos);
        LevelGridSlot = levelGrid.GetSlot(GridPosition);
    }

    public string ReadForUI()
    {
        if (!LevelGridSlot) return null;
        return $"{LevelGridSlot}";
        //return $"{LevelGridSlot.Read()}";
    }
}
