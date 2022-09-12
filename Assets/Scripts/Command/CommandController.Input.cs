using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CommandController : AbstractSingleton<CommandController>, IReadableForUI
{
    [Header("Input - Keys")]
    [SerializeField] private KeyCode cursorDecision = KeyCode.Mouse1;
    [SerializeField] private KeyCode cycleTarget = KeyCode.Tab;
    [SerializeField] private KeyCode confirmTarget = KeyCode.Space;
    [SerializeField] private KeyCode modifier = KeyCode.LeftShift;
    public KeyCode CursorDecision { get => cursorDecision; private set => cursorDecision = value; }
    public KeyCode CycleTarget { get => cycleTarget; private set => cycleTarget = value; }
    public KeyCode ConfirmTarget { get => confirmTarget; set => confirmTarget = value; }
    public KeyCode Modifier { get => modifier; private set => modifier = value; }

    [Header("Input - Shortcuts")]
    [SerializeField] private KeyCode moveCommand = KeyCode.G;
    [SerializeField] private KeyCode meleeCommand = KeyCode.F;
    [SerializeField] private KeyCode context1Command = KeyCode.Q;
    [SerializeField] private KeyCode context2Command = KeyCode.E;
    [SerializeField] private KeyCode reloadCommand = KeyCode.R;
    [SerializeField] private KeyCode throwCommand = KeyCode.T;
    public KeyCode MoveCommand { get => moveCommand; private set => moveCommand = value; }
    public KeyCode MeleeCommand { get => meleeCommand; private set => meleeCommand = value; }
    public KeyCode Context1Command { get => context1Command; private set => context1Command = value; }
    public KeyCode Context2Command { get => context2Command; private set => context2Command = value; }
    public KeyCode ReloadCommand { get => reloadCommand; private set => reloadCommand = value; }
    public KeyCode ThrowCommand { get => throwCommand; private set => throwCommand = value; }
    
    private void UpdateInput()
    {
        CursorDecisionInput();
        CycleTargetInput();
        ConfirmTargetInput();
        ShortcutInput();
    }

    private bool CursorDecisionInput()
    {
        bool cursorOverUI = MouseUtils.IsPointerOverUI();
        if (cursorOverUI) return false;

        bool input = Input.GetKeyDown(CursorDecision);
        if (input) ContextRequest();
        return input;
    }

    private bool CycleTargetInput()
    {
        bool input = Input.GetKeyDown(CycleTarget);
        if (input)
        {
            bool modifier = Input.GetKeyDown(Modifier);
            Debug.Log("TODO");
            //Cycle(modifier);
        }
        return input;
    }

    private bool ConfirmTargetInput()
    {
        bool input = Input.GetKeyDown(ConfirmTarget);
        if (input) Request();
        return input;
    }

    private bool ShortcutInput()
    {
        CommandHotkey input = CommandHotkey.NONE;
        if (Input.GetKeyDown(MoveCommand)) input = CommandHotkey.MOVE;
        if (Input.GetKeyDown(MeleeCommand)) input = CommandHotkey.MELEE;
        if (Input.GetKeyDown(Context1Command)) input = CommandHotkey.CONTEXT1;
        if (Input.GetKeyDown(Context2Command)) input = CommandHotkey.CONTEXT2;
        if (Input.GetKeyDown(ReloadCommand)) input = CommandHotkey.RELOAD;
        if (Input.GetKeyDown(ThrowCommand)) input = CommandHotkey.THROW;

        if (input != CommandHotkey.NONE)
        {
            bool modifier = Input.GetKeyDown(Modifier);
            HotkeyRequest(input, modifier);
            return true;
        }
        return false;
    }
}
