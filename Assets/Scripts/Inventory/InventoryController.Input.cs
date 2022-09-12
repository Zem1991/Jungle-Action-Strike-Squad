using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class InventoryController : AbstractSingleton<InventoryController>
{
    [Header("Input")]
    [SerializeField] private KeyCode window = KeyCode.I;
    public KeyCode Window { get => window; private set => window = value; }

    private void UpdateInput()
    {
        WindowInput();
    }

    private bool WindowInput()
    {
        bool toggleWindow = Input.GetKeyDown(Window);
        if (toggleWindow)
        {
            ToggleWindow();
        }
        return toggleWindow;
    }
}
