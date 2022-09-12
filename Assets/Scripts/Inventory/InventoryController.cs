using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class InventoryController : AbstractSingleton<InventoryController>
{
    [Header("Runtime")]
    [SerializeField] private Character current;
    public Character Current { get => current; private set => current = value; }

    private void Update()
    {
        UpdateInput();
    }

    public bool HasCurrent()
    {
        return Current;
    }

    public void ToggleWindow()
    {
        Character actor = SelectionController.Instance.Get();
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
