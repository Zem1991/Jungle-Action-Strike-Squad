using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : UIPanel
{
    [Header("CombatUI Scene")]
    [SerializeField] private Text turnText;
    [SerializeField] private Text phaseText;
    [SerializeField] private Button endTurnButton;

    public override void Refresh()
    {
        CombatController combatController = CombatController.Instance;
        PlayerType turnPhase = combatController.TurnPhase;
        ChangeBackgroundColor(turnPhase);

        turnText.text = $"Turn {combatController.TurnNumber}";
        phaseText.text = $"{turnPhase} phase";

        //string refreshText = CombatController.Instance.ReadForUI();
        //if (refreshText == null)
        //{
        //    Hide();
        //}
        //else
        //{
        //    text.text = $"Combat: {refreshText}";
        //    Show();
        //}

        CommandController actionController = CommandController.Instance;
        bool showEndTurnButton = !actionController.HasCurrent();
        endTurnButton.gameObject.SetActive(showEndTurnButton);
    }

    public void EndTurnButton()
    {
        CombatController combatController = CombatController.Instance;
        combatController.EndTurn();
    }
}
