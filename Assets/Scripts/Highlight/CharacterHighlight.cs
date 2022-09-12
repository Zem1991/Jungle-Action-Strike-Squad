using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHighlight : Highlight
{
    [Header("CharacterHighlight Scene")]
    [SerializeField] private Image background;
    [SerializeField] private Text charName;
    [SerializeField] private Text charHealth;
    [SerializeField] private Text charAction;

    [Header("CharacterHighlight Runtime")]
    [SerializeField] private Character character;
    public Character Character { get => character; private set => character = value; }

    public override void Refresh()
    {
        ActionController actionController = ActionController.Instance;
        if (actionController.HasCurrent())
        {
            Hide();
            return;
        }

        PlayerType playerType = character.Owner.GetPlayerType();
        Color color = PlayerColors.GetPanelBackground(playerType);
        background.color = color;

        charName.text = Character.CharacterName;
        charHealth.text = $"HP {Character.HealthPoints}";
        charAction.text = $"AP {Character.ActionPoints}";

        Show();
    }

    public void SetCharacter(Character character)
    {
        Character = character;
        Refresh();
    }
}
