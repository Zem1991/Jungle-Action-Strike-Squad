using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 20F;
    public float MovementSpeed { get => movementSpeed; private set => movementSpeed = value; }

    private void UpdateMovement()
    {
        Vector3 position = GetPosition();
        Vector3 direction = GetDirection();
        float distance = MovementSpeed * Time.deltaTime;
        Physics.Raycast(position, direction, out RaycastHit raycastHit, distance);
        Collider collider = raycastHit.collider;
        if (!collider)
        {
            PerformMovement();
            return;
        }
        Character character = collider.GetComponent<Character>();
        if (user && user == character)
        {
            PerformMovement();
            return;
        }
        Vector3 point = raycastHit.point;
        transform.position = point;
        colliderHit = collider;
    }

    private void PerformMovement()
    {
        Vector3 direction = GetDirection();
        Vector3 translation = direction * MovementSpeed;
        translation *= Time.deltaTime;
        transform.Translate(translation, Space.World);
    }
}
