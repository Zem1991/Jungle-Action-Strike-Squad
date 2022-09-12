using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterButtonUI : UIPanel//, IPointerClickHandler
{
    [Header("Scene")]
    [SerializeField] private RectTransform stuffHolder;
    [SerializeField] private Image charSprite;
    [SerializeField] private Text charName;
    [SerializeField] private Text charHealth;
    [SerializeField] private Text charAction;

    [Header("Runtime")]
    [SerializeField] private Character character;
    [SerializeField] private bool flip;

    public override void Refresh()
    {
        ChangeBackgroundColor(character);

        if (stuffHolder)
        {
            Vector3 position = stuffHolder.transform.localPosition;
            float posX = flip ? -position.x : position.x;
            position.x = posX;
            stuffHolder.transform.localPosition = position;
        }

        charSprite.sprite = character.CharacterSprite;
        charName.text = character.CharacterName;
        charHealth.text = $"HP {character.HealthPoints}";
        charAction.text = $"AP {character.ActionPoints}";
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    //PlayerController.Instance.ToggleInventory();
    //}

    public void Initialize(Character character, bool flip = false)
    {
        if (!character) return;
        this.character = character;
        this.flip = flip;

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
