using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CameraController : AbstractSingleton<CameraController>
{
    [Header("Input - Axes")]
    [SerializeField] private string moveAxisX = "Horizontal";
    [SerializeField] private string moveAxisZ = "Vertical";
    [SerializeField] private string zoomAxisZ = "Mouse ScrollWheel";
    public string MoveAxisX { get => moveAxisX; private set => moveAxisX = value; }
    public string MoveAxisZ { get => moveAxisZ; private set => moveAxisZ = value; }
    public string ZoomAxisZ { get => zoomAxisZ; private set => zoomAxisZ = value; }

    [Header("Input - Keys")]
    [SerializeField] private KeyCode mainModifier = KeyCode.LeftShift;
    [SerializeField] private KeyCode lookModifier = KeyCode.LeftControl;
    [SerializeField] private KeyCode centerCamera = KeyCode.Space;
    [SerializeField] private KeyCode cameraDefaults = KeyCode.Home;
    public KeyCode MainModifier { get => mainModifier; private set => mainModifier = value; }
    public KeyCode LookModifier { get => lookModifier; private set => lookModifier = value; }
    public KeyCode CenterCamera { get => centerCamera; private set => centerCamera = value; }
    public KeyCode CameraDefaults { get => cameraDefaults; private set => cameraDefaults = value; }

    private void UpdateInput()
    {
        ActionController actionController = ActionController.Instance;
        if (actionController.HasCurrent()) return;

        MoveInput();
        RotateInput();
        ZoomInput();
        LookInput();
        CenterOverSelectedInput();
        CenterOverTargetedInput();
        CameraDefaultsInput();
    }

    private bool MoveInput()
    {
        bool mainModifier = Input.GetKey(MainModifier);
        bool lookModifier = Input.GetKey(LookModifier);
        if (mainModifier || lookModifier) return false;

        float axisX = Input.GetAxisRaw(MoveAxisX);
        float axisZ = Input.GetAxisRaw(MoveAxisZ);
        Vector3 input = new Vector3(axisX, 0, axisZ);
        Move(input);
        return input != Vector3.zero;
    }

    private bool RotateInput()
    {
        bool mainModifier = Input.GetKey(MainModifier);
        bool lookModifier = Input.GetKey(LookModifier);
        if (!mainModifier || lookModifier) return false;

        float input = Input.GetAxisRaw(MoveAxisX);
        Rotate(input);
        return input != 0;
    }

    private bool ZoomInput()
    {
        bool mainModifier = Input.GetKey(MainModifier);
        bool lookModifier = Input.GetKey(LookModifier);
        if (!mainModifier || lookModifier) return false;

        float input = Input.GetAxisRaw(MoveAxisZ);
        Zoom(input);
        return input != 0;
    }

    private bool LookInput()
    {
        bool mainModifier = Input.GetKey(MainModifier);
        bool lookModifier = Input.GetKey(LookModifier);
        if (mainModifier || !lookModifier) return false;

        float axisX = Input.GetAxisRaw(MoveAxisX);
        float axisZ = Input.GetAxisRaw(MoveAxisZ);
        Vector3 input = new Vector3(axisX, 0, axisZ);
        Look(input);
        return input != Vector3.zero;
    }

    private bool CenterOverSelectedInput()
    {
        bool mainModifier = Input.GetKey(MainModifier);
        bool input = Input.GetKeyDown(CenterCamera);
        if (!mainModifier && input)
        {
            CenterOverSelected();
            return true;
        }
        return false;
    }

    private bool CenterOverTargetedInput()
    {
        bool mainModifier = Input.GetKey(MainModifier);
        bool input = Input.GetKeyDown(CenterCamera);
        if (mainModifier && input)
        {
            CenterOverTargeted();
            return true;
        }
        return false;
    }

    private bool CameraDefaultsInput()
    {
        bool input = Input.GetKeyDown(CameraDefaults);
        if (input) UseDefaults();
        return input;
    }
}
