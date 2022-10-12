using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RotationHelper
{
    [Header("Rotation")]
    private const float rotationSpeed = 10F;
    public static float RotationSpeed { get => rotationSpeed; }
    public static float RotationFrame { get => RotationSpeed * Time.deltaTime; }

    public static void RotateTo(Character character, Vector3 position)
    {
        Vector3 myPos = character.GetPosition();
        if (myPos == position) return;

        Vector3 myDir = character.GetDirection();
        Vector3 direction = (position - myPos).normalized;
        character.RotateAt(direction);

        float angle = Vector3.Angle(myDir, direction);
        float allowedAngle = RotationFrame;
        //if (Vector3.Angle(myDir, direction) >= 0.1F)
        if (angle > allowedAngle)
        {
            direction = Vector3.Lerp(myDir, direction, allowedAngle);
        }
        character.transform.forward = direction;
    }

    public static void RotateAt(Character character, Vector3 direction)
    {
        if (direction.magnitude <= 0F) return;
        Vector3 myDir = character.GetDirection();

        float angle = Vector3.Angle(myDir, direction);
        float allowedAngle = RotationFrame;
        //if (Vector3.Angle(myDir, direction) >= 0.1F)
        //if (angle > 5F && angle > allowedAngle)
        //if (angle != 0 && angle > allowedAngle)
        if (angle > allowedAngle)
        {
            direction = Vector3.Lerp(myDir, direction, RotationFrame);
        }
        character.transform.forward = direction;
    }
}
