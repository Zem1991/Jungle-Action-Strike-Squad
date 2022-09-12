using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Item : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 8F;
    [SerializeField] private bool isMoving;
    public float MovementSpeed { get => movementSpeed; private set => movementSpeed = value; }
    public bool IsMoving { get => isMoving; private set => isMoving = value; }

    private void UpdateMovement()
    {
        if (!IsMoving) return;
        Vector2 position = GetPosition();
        if (position == ThrownPos) AfterThrown();
        float distance = MovementSpeed * Time.deltaTime;
        RaycastHit2D raycastHit = Physics2D.Raycast(position, ThrownDir, distance);
        Collider2D collider = raycastHit.collider;
        if (!collider)
        {
            PerformMovement();
            return;
        }
        Vector2 point = raycastHit.point;
        transform.position = point;
        thrownPos = point;
    }

    private void PerformMovement()
    {
        Vector3 translation = ThrownDir * MovementSpeed;
        translation *= Time.deltaTime;
        transform.Translate(translation, Space.World);
    }
}
