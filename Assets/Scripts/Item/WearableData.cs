using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WearableData : ItemData
{
    [Header("WearableData")]
    [SerializeField] private bool isHead;
    public bool IsHead { get => isHead; private set => isHead = value; }
}
