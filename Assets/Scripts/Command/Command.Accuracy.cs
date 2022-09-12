using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Command : MonoBehaviour
{
    [Header("Accuracy")]
    [SerializeField] private int accuracy;
    public int Accuracy { get => accuracy; private set => accuracy = value; }
}
