using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CursorDecisionProcessor
{
    public void Process()
    {
        Character selectedCharacter = SelectionController.Instance.Get();
        if (selectedCharacter) ProcessWithSelection(selectedCharacter);
        else ProcessNoSelection();
    }

    private void ProcessWithSelection(Character selectedCharacter)
    {
        AbilityDecisionProcessor abilityDecisionProcessor = new();
        abilityDecisionProcessor.Process(selectedCharacter);
    }

    private void ProcessNoSelection()
    {
        //TODO?
    }
}
