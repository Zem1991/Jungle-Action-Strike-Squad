using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Item : ScriptableObject
{
    [Header("Thrown")]
    [SerializeField] private bool isThrowable = true;
    public bool IsThrowable { get => isThrowable; private set => isThrowable = value; }

    //public bool Throw(Character thrower, Vector2 targetPos)
    //{
    //    Vector2 adjustedTargetPos = targetPos;
    //    Vector2 position = thrower.GetPosition();
    //    IsMoving = true;
    //    Thrower = thrower;
    //    ThrownPos = adjustedTargetPos;
    //    ThrownDir = (adjustedTargetPos - position).normalized;
    //    //Level.Instance.AddItem(this); //TODO: this again
    //    return IsMoving;
    //}

    //protected virtual void AfterThrown()
    //{
    //    IsMoving = false;
    //}
}
