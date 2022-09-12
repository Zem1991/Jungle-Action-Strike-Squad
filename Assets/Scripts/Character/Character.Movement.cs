using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 5F;
    public float MovementSpeed { get => movementSpeed; private set => movementSpeed = value; }
    public float MovementFrame { get => MovementSpeed * Time.deltaTime; }

    public void MoveTo(Vector3 position)
    {
        Vector3 myPos = GetPosition();
        if (myPos == position) return;

        float distance = Vector3.Distance(myPos, position);
        float allowedDistance = MovementFrame;
        if (distance > allowedDistance)
        {
            Vector3 direction = (position - myPos).normalized;
            MoveAt(direction);
            //Vector3 positionDelta = direction * allowedDistance;
            //transform.position += positionDelta;
        }
        else
        {
            transform.position = position;
        }
    }

    public void MoveAt(Vector3 direction)
    {
        if (direction.magnitude <= 0F) return;
        Vector3 positionDelta = direction * MovementFrame;
        transform.position += positionDelta;
    }
}
