using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Command : MonoBehaviour
{
    [Header("Identification")]
    [SerializeField] private Sprite sprite;
    [SerializeField] private new string name;
    public Sprite Sprite { get => sprite; private set => sprite = value; }
    public string Name { get => name; private set => name = value; }
}
