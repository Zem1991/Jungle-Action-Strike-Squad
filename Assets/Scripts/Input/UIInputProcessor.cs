using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputProcessor
{
    public void Read(UIInputReader reader)
    {
        bool hideAllPress = reader.HideAllPress();
        bool toggleAltsPress = reader.ToggleAltsPress();

        HideAllInput(hideAllPress);
        ToggleAltsInput(toggleAltsPress);
    }

    private void HideAllInput(bool input)
    {
        UIController.Instance.HidingAll = input;
    }

    private void ToggleAltsInput(bool input)
    {
        bool toggleChange = input != UIController.Instance.UsingAlternatives;
        if (toggleChange) UIController.Instance.UsingAlternatives = input;
    }
}
