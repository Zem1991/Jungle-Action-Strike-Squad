using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class HighlightController : AbstractSingleton<HighlightController>
{
    [Header("Input")]
    [SerializeField] private KeyCode toggleAlts = KeyCode.LeftAlt;
    public KeyCode ToggleAlts { get => toggleAlts; private set => toggleAlts = value; }

    private void UpdateInput()
    {
        ToggleAltsInput();
    }

    private bool ToggleAltsInput()
    {
        bool toggleAlts = Input.GetKey(ToggleAlts);
        bool toggleChange = toggleAlts != usingAlternatives;
        if (toggleChange) ToggleAlternatives(toggleAlts);
        return toggleChange;
    }
}
