using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Command : MonoBehaviour
{
    [Header("Path")]
    [SerializeField] private bool needsPathHighlight = true;
    public bool NeedsPathHighlight { get => needsPathHighlight; private set => needsPathHighlight = value; }
}
