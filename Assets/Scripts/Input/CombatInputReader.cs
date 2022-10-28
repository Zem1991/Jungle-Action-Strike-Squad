using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInputReader
{
    [SerializeField] private KeyCode endTurn1 = KeyCode.Backspace;
    [SerializeField] private KeyCode endTurn2 = KeyCode.End;
    public KeyCode EndTurn1 { get => endTurn1; private set => endTurn1 = value; }
    public KeyCode EndTurn2 { get => endTurn2; private set => endTurn2 = value; }

    public bool EndTurnDown()
    {
        bool endTurn = Input.GetKeyDown(EndTurn1) || Input.GetKeyDown(EndTurn2);
        return endTurn;
    }
}
