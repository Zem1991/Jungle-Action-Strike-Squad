using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Item : MonoBehaviour
{
    [Header("Thrown")]
    [SerializeField] private bool isThrowable = true;
    [SerializeField] private Character thrower;
    [SerializeField] private Vector2 thrownPos;
    [SerializeField] private Vector2 thrownDir;
    public bool IsThrowable { get => isThrowable; private set => isThrowable = value; }
    public Character Thrower { get => thrower; private set => thrower = value; }
    public Vector2 ThrownPos { get => thrownPos; private set => thrownPos = value; }
    public Vector2 ThrownDir { get => thrownDir; private set => thrownDir = value; }

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

    protected virtual void AfterThrown()
    {
        IsMoving = false;
    }
}
