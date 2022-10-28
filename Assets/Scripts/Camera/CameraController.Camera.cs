using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CameraController : AbstractSingleton<CameraController>
{
    public void Position(Vector3 position, float lerpRatio = 1F)
    {
        cameraHolder.Position(position, lerpRatio);
    }

    public void Move(Vector3 input)
    {
        cameraHolder.Move(input);
    }

    public void Rotate(float input)
    {
        cameraHolder.Rotate(input);
    }

    public void Zoom(float input)
    {
        cameraHolder.Zoom(input);
    }

    public void Look(Vector3 input)
    {
        cameraHolder.Look(input);
    }

    public void CenterOverSelected()
    {
        Character selected = SelectionController.Instance.Get();
        if (!selected) return;
        Vector3 position = selected.GetPosition();
        cameraHolder.Position(position, 1F);
    }

    public void CenterOverTargeted()
    {
        LevelTile tile = AbilityController.Instance.Tile;
        if (!tile) return;
        Vector3 position = tile.transform.position;
        cameraHolder.Position(position, 1F);
    }

    public void UseDefaults()
    {
        cameraHolder.UseDefaults();
    }
}
