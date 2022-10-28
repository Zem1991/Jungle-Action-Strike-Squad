using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CursorInputReader
{
    [SerializeField] private KeyCode selection = KeyCode.Mouse0;
    [SerializeField] private KeyCode decision = KeyCode.Mouse1;
    [SerializeField] private KeyCode cameraDrag = KeyCode.Mouse2;
    public KeyCode Selection { get => selection; private set => selection = value; }
    public KeyCode Decision { get => decision; private set => decision = value; }
    public KeyCode CameraDrag { get => cameraDrag; private set => cameraDrag = value; }

    public bool SelectionDown()
    {
        return Input.GetKeyDown(Selection);
    }

    public bool DecisionDown()
    {
        return Input.GetKeyDown(Decision);
    }

    public bool CameraDragPress()
    {
        return Input.GetKey(CameraDrag);
    }
}
