using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : MonoBehaviour
{
    [Header("Command Initialization")]
    [SerializeField] protected CommandData commandData;
    public CommandData CommandData { get => commandData; private set => commandData = value; }

    public void Initialize(CommandData commandData)
    {
        CommandData = commandData;
    }

    [Header("Command Setup")]
    [SerializeField] private Character actor;
    [SerializeField] private LevelTile tile;
    [SerializeField] private List<PathfindingNode> path;
    [SerializeField] private Action onStart;
    [SerializeField] private Action onFinish;
    public Character Actor { get => actor; private set => actor = value; }
    public LevelTile Tile { get => tile; private set => tile = value; }
    public List<PathfindingNode> Path { get => path; private set => path = value; }
    private Action OnStart { get => onStart; set => onStart = value; }
    private Action OnFinish { get => onFinish; set => onFinish = value; }

    private void Setup(Character actor, LevelTile slot, List<PathfindingNode> path, Action onStart, Action onFinish)
    {
        Actor = actor;
        Tile = slot;
        Path = path;
        OnStart = onStart;
        OnFinish = onFinish;
    }

    public override string ToString()
    {
        return $"{CommandData.Name}: {Actor} => {Tile}";
    }

    public bool TryToExecute(Character actor, LevelTile slot, List<PathfindingNode> path, Action onStart, Action onFinish)
    {
        bool canExecute = CanExecute(actor, slot, path);
        if (canExecute) StartExecution(actor, slot, path, onStart, onFinish);
        return canExecute;
    }

    protected virtual bool CanExecute(Character actor, LevelTile slot, List<PathfindingNode> path)
    {
        return true;
    }

    protected virtual void StartExecution(Character actor, LevelTile slot, List<PathfindingNode> path, Action onStart, Action onFinish)
    {
        Setup(actor, slot, path, onStart, onFinish);
        CostHelper.ApplyCosts(CommandData, actor);
        if (OnStart != null) OnStart();
    }

    public virtual void UpdateExecution()
    {
        FinishExecution();
    }

    protected virtual void FinishExecution()
    {
        if (OnFinish != null) OnFinish();
    }
}
