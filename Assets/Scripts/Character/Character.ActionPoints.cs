using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Character : MonoBehaviour
{
    [Header("Action Points")]
    [SerializeField] private Resource actionPoints;
    public Resource ActionPoints { get => actionPoints; private set => actionPoints = value; }

    public bool SpendActionPoints(int amount)
    {
        return ActionPoints.Subtract(amount);
    }
}
