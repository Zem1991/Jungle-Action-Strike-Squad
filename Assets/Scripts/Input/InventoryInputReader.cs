using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInputReader
{
    [SerializeField] private KeyCode window = KeyCode.I;
    public KeyCode Window { get => window; private set => window = value; }

    public bool WindowDown()
    {
        return Input.GetKeyDown(Window);
    }
}
