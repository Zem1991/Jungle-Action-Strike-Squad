using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBasicsUI : MonoBehaviour
{
    [Header("CharacterBasicsUI Awake")]
    [SerializeField] private CharacterSpriteUI characterSprite;
    [SerializeField] private CharacterNameUI characterName;
    [SerializeField] private CharacterHealthPointsBarUI healthPointsBar;
    [SerializeField] private CharacterActionPointsBarUI actionPointsBar;

    private void Awake()
    {
        characterSprite = GetComponentInChildren<CharacterSpriteUI>();
        characterName = GetComponentInChildren<CharacterNameUI>();
        healthPointsBar = GetComponentInChildren<CharacterHealthPointsBarUI>();
        actionPointsBar = GetComponentInChildren<CharacterActionPointsBarUI>();
    }

    public void Refresh(Character character)
    {
        characterSprite.Refresh(character);
        characterName.Refresh(character);
        healthPointsBar.Refresh(character);
        actionPointsBar.Refresh(character);
    }
}
