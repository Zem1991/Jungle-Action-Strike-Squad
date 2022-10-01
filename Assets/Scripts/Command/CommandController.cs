using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CommandController : AbstractSingleton<CommandController>, IReadableForUI
{
    [Header("Runtime")]
    [SerializeField] private Command button;
    [SerializeField] private Command current;
    [SerializeField] private Character actor;
    [SerializeField] private LevelTile slot;
    [SerializeField] private List<PathfindingNode> path;
    //[SerializeField] private Vector2Int gridPos;
    //[SerializeField] private Vector3 worldPos;
    //[SerializeField] private Item item;
    //[SerializeField] private GameObject item;
    //[SerializeField] private Character target;
    public Command Button { get => button; private set => button = value; }
    public Command Current { get => current; private set => current = value; }
    public Character Actor { get => actor; private set => actor = value; }
    public LevelTile Slot { get => slot; private set => slot = value; }
    public List<PathfindingNode> Path { get => path; private set => path = value; }
    //public Vector2Int GridPos { get => gridPos; private set => gridPos = value; }
    //public Vector3 WorldPos { get => worldPos; private set => worldPos = value; }
    //public Item Item { get => item; private set => item = value; }
    //public GameObject Item { get => item; private set => item = value; }
    //public Character Target { get => target; private set => target = value; }

    private void Update()
    {
        ActionController actionController = ActionController.Instance;
        if (actionController.HasCurrent()) return;

        UpdateInput();
    }

    public string ReadForUI()
    {
        if (TargetingMode()) return $"Select target for {Button.Data.Name}";
        if (ConfirmationMode()) return $"Confirm command {Current.Data.Name}: {Actor} => {Slot}";
        if (ContextMode()) return $"Quick command {Current.Data.Name}: {Actor} => {Slot}";
        return "???";
    }

    public Command GetCommand()
    {
        if (TargetingMode()) return Button;
        if (ConfirmationMode()) return Current;
        if (ContextMode()) return Current;
        return null;
    }

    public bool InUse()
    {
        return Button || Current;
    }

    public bool TargetingMode()
    {
        return Button && !Current;
    }

    public bool ConfirmationMode()
    {
        return Button && Current;
    }
    public bool ContextMode()
    {
        return !Button && Current;
    }

    public void Cancel()
    {
        Clear();
    }

    public void ContextRequest()
    {
        Character actor = SelectionController.Instance.Get();
        if (!actor) return;
        LevelTile slot = CursorController.Instance.LevelTile;
        if (!slot) return;

        Command command = CommandHelper.FromContext(actor, slot, out List<PathfindingNode> path);
        //TODO: make a separate function to get if it's reachable and the resulting path.
        //With this I won't need to override 'command' like this.
        if (Button) command = Button;
        Request(command, actor, slot, path);
    }

    public void DirectRequest(Command command)
    {
        Character actor = SelectionController.Instance.Get();
        if (!command || !actor) return;
        Clear();
        Button = command;
    }

    private void HotkeyRequest(CommandHotkey hotkey, bool modeToggle)
    {
        Character actor = SelectionController.Instance.Get();
        if (!actor) return;
        Command command = actor.GetHotkeyCommand(hotkey, modeToggle);
        DirectRequest(command);
    }

    private void Request()
    {
        if (!ConfirmationMode()) return;
        Request(Current, Actor, Slot, Path);
    }

    private void Request(Command command, Character actor, LevelTile slot, List<PathfindingNode> path)
    {
        if (!command)
        {
            Clear();
        }
        else if (!Compare(command, actor, slot, path))
        {
            Write(command, actor, slot, path);
        }
        else
        {
            Execute();
        }
    }

    public void Clear()
    {
        Button = null;
        Current = null;
        Actor = null;
        Slot = null;
        Path = null;
        //GridPos = default;
        //WorldPos = default;
        //Item = null;
        //Target = null;
    }

    private bool Compare(Command command, Character actor, LevelTile slot, List<PathfindingNode> path)
    {
        if (Current != command) return false;
        if (Actor != actor) return false;
        if (Slot != slot) return false;
        //TODO: compare if paths changed
        //if (Path != path) return false;
        return true;
    }

    private void Write(Command command, Character actor, LevelTile slot, List<PathfindingNode> path)
    {
        Current = command;
        Actor = actor;
        Slot = slot;
        Path = path;
    }

    private void Execute()
    {
        if (!Current.CheckActionPoints(Actor))
        {
            string message = FeedbackMessages.Instance.notEnoughActionPoints;
            FeedbackController.Instance.SetMessage(message);
        }
        else
        {
            ActionController actionController = ActionController.Instance;
            actionController.SetCurrent(Current, Actor, Slot, Path);
            Clear();
        }
    }
}
