using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CombatController : AbstractSingleton<CombatController>//, IReadableForUI
{
    [Header("Input")]
    [SerializeField] private KeyCode endTurn1 = KeyCode.Backspace;
    [SerializeField] private KeyCode endTurn2 = KeyCode.End;
    public KeyCode EndTurn1 { get => endTurn1; private set => endTurn1 = value; }
    public KeyCode EndTurn2 { get => endTurn2; private set => endTurn2 = value; }

    private void UpdateInput()
    {
        EndTurnInput();
    }

    private bool EndTurnInput()
    {
        bool endTurn = Input.GetKeyDown(EndTurn1) || Input.GetKeyDown(EndTurn2);
        if (endTurn)
        {
            EndTurn();
        }
        return endTurn;
    }
}
