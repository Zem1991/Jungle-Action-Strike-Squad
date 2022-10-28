using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInputProcessor
{
    public void Read(CombatInputReader reader)
    {
        bool endTurnDown = reader.EndTurnDown();
        if (endTurnDown) EndTurnInput();
    }

    private void EndTurnInput()
    {
        CombatController.Instance.EndTurn();
    }
}
