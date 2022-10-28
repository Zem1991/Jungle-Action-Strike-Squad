using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CameraInputProcessor
{
    public void Read(CameraInputReader reader)
    {
        Vector3 moveInput = reader.MoveInput();
        float rotateInput = reader.RotateInput();
        float zoomInput = reader.ZoomInput();
        Vector3 lookInput = reader.LookInput();

        MoveInput(moveInput);
        RotateInput(rotateInput);
        ZoomInput(zoomInput);
        LookInput(lookInput);

        bool centerOverSelectedInput = reader.CenterOverSelectedInput();
        bool centerOverTargetedInput = reader.CenterOverTargetedInput();
        bool cameraDefaultsInput = reader.CameraDefaultsInput();

        if (centerOverSelectedInput) CenterOverSelectedInput();
        else if (centerOverTargetedInput) CenterOverTargetedInput();
        else if (cameraDefaultsInput) CameraDefaultsInput();
    }

    private void MoveInput(Vector3 input)
    {
        CameraController.Instance.Move(input);
    }

    private void RotateInput(float input)
    {
        CameraController.Instance.Rotate(input);
    }

    private void ZoomInput(float input)
    {
        CameraController.Instance.Zoom(input);
    }

    private void LookInput(Vector3 input)
    {
        CameraController.Instance.Look(input);
    }

    private void CenterOverSelectedInput()
    {
        CameraController.Instance.CenterOverSelected();
    }

    private void CenterOverTargetedInput()
    {
        CameraController.Instance.CenterOverTargeted();
    }

    private void CameraDefaultsInput()
    {
        CameraController.Instance.UseDefaults();
    }
}
