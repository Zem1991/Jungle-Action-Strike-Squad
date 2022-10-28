using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CursorSelectionProcessor
{
    public void Process()
    {
        AbilityInstance currentAbilityInstance = AbilityController.Instance.Current;

        LevelTile levelTile = CursorController.Instance.LevelTile;
        Character foundCharacter = levelTile?.Character;

        if (currentAbilityInstance != null) CancelAbilityInstance();
        else SelectCharacter(foundCharacter);
    }

    private void CancelAbilityInstance()
    {
        AbilityController.Instance.Clear();
    }

    private void SelectCharacter(Character character)
    {
        SelectionController.Instance.Set(character);
    }
}
