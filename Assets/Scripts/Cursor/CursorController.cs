using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CursorController : AbstractSingleton<CursorController>, IReadableForUI
{
    private Action OnTileChange;

    [Header("Awake")]
    [SerializeField] private CursorHolder cursorHolder;

    [Header("Runtime Screen")]
    [SerializeField] private bool allowBorderCameraScroll = true;
    [SerializeField] private bool usingCursorCamera;

    [Header("Runtime Screen")]
    [SerializeField] private Vector2 screenPosition;
    [SerializeField] private Vector2 screenDragPosition;
    [SerializeField] private Vector3Int borderChecks;
    public Vector2 ScreenPosition { get => screenPosition; private set => screenPosition = value; }
    public Vector2 ScreenDragPosition { get => screenDragPosition; set => screenDragPosition = value; }
    public Vector3Int BorderChecks { get => borderChecks; private set => borderChecks = value; }

    [Header("Runtime World")]
    [SerializeField] private Vector3 worldPosition;
    [SerializeField] private Vector3Int gridPosition;
    [SerializeField] private LevelTile levelTile;
    public Vector3 WorldPosition { get => worldPosition; private set => worldPosition = value; }
    public Vector3Int GridPosition { get => gridPosition; private set => gridPosition = value; }
    public LevelTile LevelTile
    {
        get => levelTile;
        private set
        {
            levelTile = value;
            if (OnTileChange != null) OnTileChange();
        }
    }
    
    protected override void Awake()
    {
        base.Awake();
        cursorHolder = GetComponentInChildren<CursorHolder>();
    }

    private void Update()
    {
        UpdateInput();
        BorderCamera();
    }

    private void LateUpdate()
    {
        LateUpdateScreen();
        LateUpdateWorld();
    }
    
    private void LateUpdateScreen()
    {
        ScreenPosition = Input.mousePosition;
        ScreenDragPosition = usingCursorCamera ? ScreenDragPosition : ScreenPosition;

        Vector3Int borderChecks = Vector3Int.zero;
        if (ScreenPosition.x <= 0) borderChecks.x--;
        if (ScreenPosition.y <= 0) borderChecks.y--;
        if (ScreenPosition.x >= Screen.width - 1) borderChecks.x++;
        if (ScreenPosition.y >= Screen.height - 1) borderChecks.y++;
        BorderChecks = borderChecks;
    }

    private void LateUpdateWorld()
    {
        LevelGrid levelGrid = LevelController.Instance.GetLevelGrid();
        WorldPosition = MouseUtils.GetMouseWorldPosition();
        GridPosition = levelGrid.GetGridPosition(WorldPosition);
        LevelTile = levelGrid.GetSlot(GridPosition);

        cursorHolder.transform.position = WorldPosition;
    }

    public string ReadForUI()
    {
        if (!LevelTile) return null;
        return $"{LevelTile}";
        //return $"{LevelGridSlot.Read()}";
    }

    public void AddOnTileChangeAction(Action action)
    {
        OnTileChange += action;
        Debug.Log("OnTileChange.GetInvocationList() count = " + OnTileChange.GetInvocationList().Length);
    }

    public void RemoveOnTileChangeAction(Action action)
    {
        OnTileChange -= action;
        if (OnTileChange == null) Debug.Log("OnTileChange.GetInvocationList() = null");
        else Debug.Log("OnTileChange.GetInvocationList() count = " + OnTileChange.GetInvocationList().Length);
    }

    private void BorderCamera()
    {
        if (!allowBorderCameraScroll) return;
        if (BorderChecks == Vector3Int.zero) return;
        Vector3 input = new Vector3
        {
            x = BorderChecks.x,
            z = BorderChecks.y
        };
        MoveCamera(input);
    }

    private void DragCamera()
    {
        Vector2 direction = (ScreenPosition - ScreenDragPosition) / 100F;
        Vector3 input = new Vector3
        {
            x = direction.x,
            z = direction.y
        };
        MoveCamera(input);
    }

    private void MoveCamera(Vector3 input)
    {
        CameraController.Instance.Move(input);
    }
}
