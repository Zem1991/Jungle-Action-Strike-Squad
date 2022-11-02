using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterUI : UIPanel
{
    [Header("PlayerCharacterUI Awake")]
    [SerializeField] private CharacterBasicsUI characterBasics;

    [Header("PlayerCharacterUI Runtime")]
    [SerializeField] private Character character;
    [SerializeField] private bool isSelected;

    protected override void Awake()
    {
        base.Awake();

        characterBasics = GetComponentInChildren<CharacterBasicsUI>();
    }

    public override void Refresh()
    {
        characterBasics.Refresh(character);
    }

    public void Initialize(Character character)
    {
        if (!character) return;
        this.character = character;
        //this.isSelected = isSelected;

        Action action = Refresh;
        character.HealthPoints.AddOnChangeAction(action);
        character.ActionPoints.AddOnChangeAction(action);
        action.Invoke();
    }

    public void Dispose()
    {
        Action action = Refresh;
        character?.HealthPoints.RemoveOnChangeAction(action);
        character?.ActionPoints.RemoveOnChangeAction(action);
    }
}
