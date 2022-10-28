using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInputReader
{
    [Header("Axes")]
    [SerializeField] private string moveAxisX = "Horizontal";
    [SerializeField] private string moveAxisZ = "Vertical";
    [SerializeField] private string zoomAxisZ = "Mouse ScrollWheel";
    public string MoveAxisX { get => moveAxisX; private set => moveAxisX = value; }
    public string MoveAxisZ { get => moveAxisZ; private set => moveAxisZ = value; }
    public string ZoomAxisZ { get => zoomAxisZ; private set => zoomAxisZ = value; }

    [Header("Keys")]
    [SerializeField] private KeyCode mainModifier = KeyCode.LeftShift;
    [SerializeField] private KeyCode lookModifier = KeyCode.LeftControl;
    [SerializeField] private KeyCode centerCamera = KeyCode.Space;
    [SerializeField] private KeyCode cameraDefaults = KeyCode.Home;
    public KeyCode MainModifier { get => mainModifier; private set => mainModifier = value; }
    public KeyCode LookModifier { get => lookModifier; private set => lookModifier = value; }
    public KeyCode CenterCamera { get => centerCamera; private set => centerCamera = value; }
    public KeyCode CameraDefaults { get => cameraDefaults; private set => cameraDefaults = value; }

    public Vector3 MoveInput()
    {
        bool mainModifier = Input.GetKey(MainModifier);
        bool lookModifier = Input.GetKey(LookModifier);
        if (mainModifier || lookModifier) return Vector3.zero;

        float axisX = Input.GetAxisRaw(MoveAxisX);
        float axisZ = Input.GetAxisRaw(MoveAxisZ);
        Vector3 input = new Vector3(axisX, 0, axisZ);
        input.Normalize();
        return input;
    }

    public float RotateInput()
    {
        bool mainModifier = Input.GetKey(MainModifier);
        bool lookModifier = Input.GetKey(LookModifier);
        if (!mainModifier || lookModifier) return 0;

        float input = Input.GetAxisRaw(MoveAxisX);
        return input;
    }

    public float ZoomInput()
    {
        bool mainModifier = Input.GetKey(MainModifier);
        bool lookModifier = Input.GetKey(LookModifier);
        if (!mainModifier || lookModifier) return 0;

        float input = Input.GetAxisRaw(MoveAxisZ);
        return input;
    }

    public Vector3 LookInput()
    {
        bool mainModifier = Input.GetKey(MainModifier);
        bool lookModifier = Input.GetKey(LookModifier);
        if (mainModifier || !lookModifier) return Vector3.zero;

        float axisX = Input.GetAxisRaw(MoveAxisX);
        float axisZ = Input.GetAxisRaw(MoveAxisZ);
        Vector3 input = new Vector3(axisX, 0, axisZ);
        input.Normalize();
        return input;
    }

    public bool CenterOverSelectedInput()
    {
        bool mainModifier = Input.GetKey(MainModifier);
        bool input = Input.GetKeyDown(CenterCamera);
        if (!mainModifier && input) return true;
        return false;
    }

    public bool CenterOverTargetedInput()
    {
        bool mainModifier = Input.GetKey(MainModifier);
        bool input = Input.GetKeyDown(CenterCamera);
        if (mainModifier && input) return true;
        return false;
    }

    public bool CameraDefaultsInput()
    {
        bool input = Input.GetKeyDown(CameraDefaults);
        return input;
    }
}
