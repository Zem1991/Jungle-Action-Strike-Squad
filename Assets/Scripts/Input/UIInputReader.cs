using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputReader
{
    [SerializeField] private KeyCode hideAll = KeyCode.LeftControl;
    [SerializeField] private KeyCode toggleAlts = KeyCode.LeftShift;
    public KeyCode HideAll { get => hideAll; private set => hideAll = value; }
    public KeyCode ToggleAlts { get => toggleAlts; private set => toggleAlts = value; }

    public bool HideAllPress()
    {
        return Input.GetKey(HideAll);
    }

    public bool ToggleAltsPress()
    {
        return Input.GetKey(ToggleAlts);
    }
}
