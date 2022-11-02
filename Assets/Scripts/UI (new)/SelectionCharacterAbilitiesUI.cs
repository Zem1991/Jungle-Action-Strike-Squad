using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCharacterAbilitiesUI : SelectionSectionUI
{
    [Header("SelectionCharacterAbilitiesUI Awake")]
    [SerializeField] protected CharacterBasicsUI characterBasics;

    protected override void Awake()
    {
        base.Awake();
        characterBasics = GetComponentInChildren<CharacterBasicsUI>();
    }

    public override void Refresh()
    {
        base.Refresh();
        characterBasics.Refresh(Character);
    }

    protected override AbilitySet GetAbilitySet()
    {
        return Character.CharacterAS;
    }
}
