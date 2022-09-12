using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SelectionController : AbstractSingleton<SelectionController>
{
    [Header("Input - Keys")]
    [SerializeField] private KeyCode cursorDecision = KeyCode.Mouse0;
    [SerializeField] private KeyCode cycleCharacter = KeyCode.Tab;
    [SerializeField] private KeyCode modifier = KeyCode.LeftShift;
    public KeyCode CursorDecision { get => cursorDecision; private set => cursorDecision = value; }
    public KeyCode CycleCharacter { get => cycleCharacter; private set => cycleCharacter = value; }
    public KeyCode Modifier { get => modifier; private set => modifier = value; }
    
    [Header("Input - Shortcuts")]
    [SerializeField] private KeyCode shortcut1 = KeyCode.Alpha1;
    [SerializeField] private KeyCode shortcut2 = KeyCode.Alpha2;
    [SerializeField] private KeyCode shortcut3 = KeyCode.Alpha3;
    [SerializeField] private KeyCode shortcut4 = KeyCode.Alpha4;
    [SerializeField] private KeyCode shortcut5 = KeyCode.Alpha5;
    [SerializeField] private KeyCode shortcut6 = KeyCode.Alpha6;
    [SerializeField] private KeyCode shortcut7 = KeyCode.Alpha7;
    [SerializeField] private KeyCode shortcut8 = KeyCode.Alpha8;
    public KeyCode Shortcut1 { get => shortcut1; private set => shortcut1 = value; }
    public KeyCode Shortcut2 { get => shortcut2; private set => shortcut2 = value; }
    public KeyCode Shortcut3 { get => shortcut3; private set => shortcut3 = value; }
    public KeyCode Shortcut4 { get => shortcut4; private set => shortcut4 = value; }
    public KeyCode Shortcut5 { get => shortcut5; private set => shortcut5 = value; }
    public KeyCode Shortcut6 { get => shortcut6; private set => shortcut6 = value; }
    public KeyCode Shortcut7 { get => shortcut7; private set => shortcut7 = value; }
    public KeyCode Shortcut8 { get => shortcut8; private set => shortcut8 = value; }
    
    private void UpdateInput()
    {
        CursorDecisionInput();
        CycleCharacterInput();
        ShortcutInput();
    }

    private bool CursorDecisionInput()
    {
        bool cursorOverUI = MouseUtils.IsPointerOverUI();
        if (cursorOverUI) return false;

        bool input = Input.GetKeyDown(CursorDecision);
        if (input) Cursor();
        return input;
    }

    private bool CycleCharacterInput()
    {
        bool input = Input.GetKeyDown(CycleCharacter);
        if (input)
        {
            bool modifier = Input.GetKeyDown(Modifier);
            Cycle(modifier);
        }
        return input;
    }

    private bool ShortcutInput()
    {
        int input = -1;
        if (Input.GetKeyDown(Shortcut1)) input = 0;
        if (Input.GetKeyDown(Shortcut2)) input = 1;
        if (Input.GetKeyDown(Shortcut3)) input = 2;
        if (Input.GetKeyDown(Shortcut4)) input = 3;
        if (Input.GetKeyDown(Shortcut5)) input = 4;
        if (Input.GetKeyDown(Shortcut6)) input = 5;
        if (Input.GetKeyDown(Shortcut7)) input = 6;
        if (Input.GetKeyDown(Shortcut8)) input = 7;

        if (input >= 0)
        {
            Shortcut(input);
            return true;
        }
        return false;
    }
}
