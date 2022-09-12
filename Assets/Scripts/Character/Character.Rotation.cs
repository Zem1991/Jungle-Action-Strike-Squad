using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 10F;
    public float RotationSpeed { get => rotationSpeed; private set => rotationSpeed = value; }
    public float RotationFrame { get => RotationSpeed * Time.deltaTime; }

    public void RotateTo(Vector3 position)
    {
        Vector3 myPos = GetPosition();
        if (myPos == position) return;

        //Vector3 myDir = GetDirection();
        Vector3 direction = (position - myPos).normalized;
        RotateAt(direction);

        //float angle = Vector3.Angle(myDir, direction);
        //float allowedAngle = RotationFrame;
        ////if (Vector3.Angle(myDir, direction) >= 0.1F)
        //if (angle > allowedAngle)
        //{
        //    direction = Vector3.Lerp(myDir, direction, allowedAngle);
        //}
        //transform.forward = direction;
    }

    public void RotateAt(Vector3 direction)
    {
        if (direction.magnitude <= 0F) return;
        Vector3 myDir = GetDirection();

        float angle = Vector3.Angle(myDir, direction);
        float allowedAngle = RotationFrame;
        //if (Vector3.Angle(myDir, direction) >= 0.1F)
        //if (angle > 5F && angle > allowedAngle)
        //if (angle != 0 && angle > allowedAngle)
        if (angle > allowedAngle)
        {
            direction = Vector3.Lerp(myDir, direction, RotationFrame);
        }
        transform.forward = direction;
    }
}
