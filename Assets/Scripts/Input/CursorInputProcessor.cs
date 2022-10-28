using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CursorInputProcessor
{
    public bool Read(CursorInputReader reader)
    {
        bool cursorOverUI = MouseUtils.IsPointerOverUI();
        if (cursorOverUI) return false;

        bool selection = reader.SelectionDown();
        bool decision = reader.DecisionDown();

        if (selection) Selection();
        else if (decision) Decision();

        bool cameraDrag = reader.CameraDragPress();
        CameraDrag(cameraDrag);

        return selection || decision || cameraDrag;
    }

    private void Selection()
    {
        CursorSelectionProcessor processor = new CursorSelectionProcessor();
        processor.Process();
    }

    private void Decision()
    {
        CursorDecisionProcessor processor = new CursorDecisionProcessor();
        processor.Process();
    }

    private void CameraDrag(bool input)
    {
        CursorController cursorController = CursorController.Instance;
        cursorController.UsingCursorCamera = input;
    }
}
