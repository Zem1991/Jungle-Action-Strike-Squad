using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class InventoryController : AbstractSingleton<InventoryController>
{
    [Header("Runtime")]
    [SerializeField] private Character current;
    public Character Current { get => current; private set => current = value; }

    public bool HasCurrent()
    {
        return Current;
    }

    public void ToggleWindow(Character actor)
    {
        if (!actor) Close();
        else if (Current == actor) Close();
        else Open(actor);
    }

    private void Close()
    {
        if (InventoryItemBeginDrag) return;
        Current = null;
    }

    private void Open(Character actor)
    {
        Current = actor;
    }
}
