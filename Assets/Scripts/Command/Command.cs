using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    [SerializeField] private CommandData data;
    public CommandData Data { get => data; private set => data = value; }

    public override string ToString()
    {
        return $"{Data.Name}: {Actor} => {Tile}";
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
        ApplyCosts();
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
