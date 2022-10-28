using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInputProcessor
{
    public bool Read(InventoryInputReader reader)
    {
        bool windowDown = reader.WindowDown();
        WindowInput(windowDown);
        return windowDown;
    }

    private void WindowInput(bool input)
    {
        if (input)
        {
            Character character = SelectionController.Instance.Get();
            InventoryController.Instance.ToggleWindow(character);
        }
    }
}
