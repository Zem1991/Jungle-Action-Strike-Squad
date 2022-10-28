using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightInputProcessor
{
    public void Read(HighlightInputReader reader)
    {
        bool toggleAltsPress = reader.ToggleAltsPress();
        ToggleAltsInput(toggleAltsPress);
    }

    private void ToggleAltsInput(bool input)
    {
        HighlightController.Instance.ToggleAlternatives(input);
    }
}
