using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CursorController : AbstractSingleton<CursorController>, IReadableForUI
{
    [Header("Input - Axes")]
    [SerializeField] private string moveAxisX = "Mouse X";
    [SerializeField] private string moveAxisZ = "Mouse Y";
    public string MoveAxisX { get => moveAxisX; private set => moveAxisX = value; }
    public string MoveAxisZ { get => moveAxisZ; private set => moveAxisZ = value; }

    [Header("Input - Keys")]
    [SerializeField] private KeyCode cameraDrag = KeyCode.Mouse2;
    public KeyCode CameraDrag { get => cameraDrag; private set => cameraDrag = value; }

    private void UpdateInput()
    {
        ActionController actionController = ActionController.Instance;
        if (actionController.HasCurrent()) return;

        //MoveInput();
        CameraDragInput();
    }

    //private bool MoveInput()
    //{
    //    float axisX = Input.GetAxisRaw(MoveAxisX);
    //    float axisZ = Input.GetAxisRaw(MoveAxisZ);
    //    Vector3 input = new Vector3(axisX, 0, axisZ);
    //    Move(input);
    //    return input != Vector3.zero;
    //}

    private bool CameraDragInput()
    {
        bool useCameraDrag = Input.GetKey(CameraDrag);
        usingCursorCamera = useCameraDrag;
        if (useCameraDrag) DragCamera();
        return useCameraDrag;
    }
}
