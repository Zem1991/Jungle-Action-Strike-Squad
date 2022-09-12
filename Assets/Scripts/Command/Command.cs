using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Command : MonoBehaviour
{
    private void Update()
    {
        //UpdateCommand();
        UpdateExecution();
    }
    
    public override string ToString()
    {
        return $"{Name}: {Actor} => {Tile}";
    }

    //public void Initialize(Character actor, LevelTile slot, List<PathfindingNode> path)
    //{
    //    Actor = actor;
    //    Tile = slot;
    //    Path = path;
    //}

    //public virtual void StartCommand(Action onStart, Action onFinish)
    //{
    //    ApplyCosts();
    //    OnStart = onStart;
    //    OnFinish = onFinish;
    //    //IsRunning = true;
    //    if (OnStart != null) OnStart();
    //}

    //public virtual void FinishCommand()
    //{
    //    //IsRunning = false;
    //    if (OnFinish != null) OnFinish();
    //}

    //protected virtual void UpdateCommand()
    //{
    //    FinishCommand();
    //}

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

    protected virtual void UpdateExecution()
    {
        FinishExecution();
    }

    protected virtual void FinishExecution()
    {
        if (OnFinish != null) OnFinish();
    }
}
