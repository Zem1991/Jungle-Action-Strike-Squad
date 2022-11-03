using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : AbstractSingleton<AbilityController>, IReadableForUI
{
    [Header("Selection")]
    [SerializeField] private AbilitySetType abilitySetType;
    public AbilitySetType AbilitySetType { get => abilitySetType; private set => abilitySetType = value; }

    [Header("Current")]
    [SerializeField] private AbilityInstance current = null;
    [SerializeField] private bool fromContext;
    public AbilityInstance Current { get => current; private set => current = value; }
    public bool FromContext { get => fromContext; private set => fromContext = value; }

    [Header("Target")]
    [SerializeField] private LevelTile tile;
    [SerializeField] private List<PathfindingNode> path;
    public LevelTile Tile { get => tile; private set => tile = value; }
    public List<PathfindingNode> Path { get => path; private set => path = value; }

    private void Update()
    {
        CommandController actionController = CommandController.Instance;
        if (actionController.HasCurrent()) return;

        if (Current == null) return;
        //TODO: update Tile and Path here
    }

    public string ReadForUI()
    {
        throw new System.NotImplementedException();
    }

    public void Set(AbilitySetType abilitySetType)
    {
        AbilitySetType = abilitySetType;
    }

    public void Clear()
    {
        Current = null;
        FromContext = false;
        Tile = null;
        Path = null;
    }

    public void Set(AbilityInstance abilityInstance, bool fromContext)
    {
        Current = abilityInstance;
        FromContext = fromContext;
    }

    public bool Compare(AbilityInstance abilityInstance)
    {
        if (abilityInstance.AbilityData != Current.AbilityData) return false;
        if (abilityInstance.Actor != Current.Actor) return false;
        if (abilityInstance.Item != Current.Item) return false;
        return true;
    }

    public void Execute()
    {
        if (!CostHelper.CheckActionPoints(Current.AbilityData, Current.Actor))
        {
            string message = FeedbackMessages.Instance.notEnoughActionPoints;
            FeedbackController.Instance.SetMessage(message);
            return;
        }

        CommandController commandController = CommandController.Instance;
        commandController.SetCurrent(Current, Tile, Path);
        Clear();
    }
}
