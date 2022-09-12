using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class HighlightController : AbstractSingleton<HighlightController>
{
    private void CreateCharacterHighlights()
    {
        ClearCharacters();

        bool dontRender = ActionController.Instance.HasCurrent();
        if (dontRender) return;

        if (usingAlternatives)
        {
            AllCharacters();
        }
        else
        {
            CursorCharacter();
        }
    }

    private void ClearCharacters()
    {
        foreach (CharacterHighlight item in characterList)
        {
            Destroy(item.gameObject);
        }
        characterList.Clear();
    }

    private void AllCharacters()
    {
        List<Character> characters = new List<Character>(FindObjectsOfType<Character>());
        foreach (Character item in characters)
        {
            SingleCharacter(item);
        }
    }

    private void CursorCharacter()
    {
        LevelTile tile = CursorController.Instance.LevelTile;
        if (!tile) return;
        Character character = tile.Character;
        SingleCharacter(character);
    }

    private void SingleCharacter(Character character)
    {
        if (!character) return;
        CharacterHighlight characterHighlight = Instantiate(characterPrefab, character.transform);
        characterHighlight.SetCharacter(character);
        characterList.Add(characterHighlight);
    }
}
