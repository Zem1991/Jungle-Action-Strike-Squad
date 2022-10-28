using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : MonoBehaviour
{
    //[Header("Ability Instance")]
    //[SerializeField] protected AbilityInstance abilityInstance;
    //public AbilityInstance AbilityInstance { get => abilityInstance; private set => abilityInstance = value; }
    //public AbilityData AbilityData { get => AbilityInstance.AbilityData; }
    //public Character Actor { get => AbilityInstance.Character; }
    //public Item Item { get => AbilityInstance.Item; }

    [Header("Ability Instance")]
    [SerializeField] protected AbilityData abilityData;
    [SerializeField] private Character actor;
    [SerializeField] private Item item;
    public AbilityData AbilityData { get => abilityData; private set => abilityData = value; }
    public Character Actor { get => actor; private set => actor = value; }
    public Item Item { get => item; private set => item = value; }

    [Header("Targeting")]
    [SerializeField] private LevelTile targetTile;
    [SerializeField] private List<PathfindingNode> targetPath;
    public LevelTile TargetTile { get => targetTile; private set => targetTile = value; }
    public List<PathfindingNode> TargetPath { get => targetPath; private set => targetPath = value; }

    [Header("Callbacks")]
    [SerializeField] private Action onStart;
    [SerializeField] private Action onFinish;
    public Action OnStart { get => onStart; private set => onStart = value; }
    public Action OnFinish { get => onFinish; private set => onFinish = value; }

    public void Initialize(AbilityData abilityData, Character actor, Item item)
    {
        AbilityData = abilityData;
        Actor = actor;
        Item = item;
    }

    //public abstract void Initialize(AbilityInstance abilityInstance);

    public void SetTarget(LevelTile targetTile, List<PathfindingNode> targetPath)
    {
        TargetTile = targetTile;
        TargetPath = targetPath;
    }

    public void SetCallbacks(Action onStart, Action onFinish)
    {
        OnStart = onStart;
        OnFinish = onFinish;
    }

    public virtual bool CanExecute()
    {
        //Check costs before
        return true;
    }

    public bool TryToStartExecution()
    {
        bool canExecute = CanExecute();
        if (canExecute) StartExecution();
        return canExecute;
    }

    protected virtual void StartExecution()
    {
        CostHelper.ApplyCosts(AbilityData, Actor);
        Actor.SetCommand(this);
        if (OnStart != null) OnStart();
    }

    public virtual void UpdateExecution()
    {
        FinishExecution();
    }

    protected virtual void FinishExecution()
    {
        Actor.SetCommand(null);
        if (OnFinish != null) OnFinish();
    }
}
