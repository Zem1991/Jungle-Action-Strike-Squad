using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Item : ScriptableObject
{
    [Header("Stack")]
    //[SerializeField] private float weight = 1F;
    [SerializeField] private int amountCurrent = 1;
    [SerializeField] private int amountMaximum = 1;
    //public float Weight { get => weight; private set => weight = value; }
    public int AmountCurrent { get => amountCurrent; private set => amountCurrent = value; }
    public int AmountMaximum { get => amountMaximum; private set => amountMaximum = value; }
}
