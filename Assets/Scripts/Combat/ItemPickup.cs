using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 8F;
    [SerializeField] private bool isMoving;
    public float MovementSpeed { get => movementSpeed; private set => movementSpeed = value; }
    public bool IsMoving { get => isMoving; private set => isMoving = value; }

    [Header("Thrown")]
    [SerializeField] private Character thrower;
    [SerializeField] private Vector2 thrownPos;
    [SerializeField] private Vector2 thrownDir;
    [SerializeField] private Action onLand;
    public Character Thrower { get => thrower; private set => thrower = value; }
    public Vector2 ThrownPos { get => thrownPos; private set => thrownPos = value; }
    public Vector2 ThrownDir { get => thrownDir; private set => thrownDir = value; }
    public Action OnLand { get => onLand; private set => onLand = value; }

    public bool Throw(Character thrower, Vector2 targetPos)
    {
        Vector2 adjustedTargetPos = targetPos;
        Vector2 position = thrower.GetPosition();
        IsMoving = true;
        Thrower = thrower;
        ThrownPos = adjustedTargetPos;
        ThrownDir = (adjustedTargetPos - position).normalized;
        //Level.Instance.AddItem(this); //TODO: this again
        return IsMoving;
    }

    private void Update()
    {
        UpdateMovement();
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void UpdateMovement()
    {
        if (!IsMoving) return;
        Vector2 position = GetPosition();
        if (position == ThrownPos) OnLand();
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
        ThrownPos = point;
    }

    private void PerformMovement()
    {
        Vector3 translation = ThrownDir * MovementSpeed;
        translation *= Time.deltaTime;
        transform.Translate(translation, Space.World);
    }
}
