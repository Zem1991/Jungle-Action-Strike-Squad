using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UIController : AbstractSingleton<UIController>
{
    [Header("Input")]
    [SerializeField] private KeyCode hideAll = KeyCode.LeftControl;
    [SerializeField] private KeyCode toggleAlts = KeyCode.LeftShift;
    public KeyCode HideAll { get => hideAll; private set => hideAll = value; }
    public KeyCode ToggleAlts { get => toggleAlts; private set => toggleAlts = value; }

    private void UpdateInput()
    {
        HideAllInput();
        ToggleAltsInput();
    }

    private bool HideAllInput()
    {
        bool hideAll = Input.GetKey(HideAll);
        HidingAll = hideAll;
        return hideAll;
    }

    private bool ToggleAltsInput()
    {
        bool toggleAlts = Input.GetKey(ToggleAlts);
        bool toggleChange = toggleAlts != UsingAlternatives;
        if (toggleChange)
        {
            UsingAlternatives = toggleAlts;
        }
        return toggleAlts;
    }
}
