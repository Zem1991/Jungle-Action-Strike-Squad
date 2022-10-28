using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightInputReader
{
    [SerializeField] private KeyCode toggleAlts = KeyCode.LeftAlt;
    public KeyCode ToggleAlts { get => toggleAlts; private set => toggleAlts = value; }

    public bool ToggleAltsPress()
    {
        return Input.GetKey(ToggleAlts);
    }
}
