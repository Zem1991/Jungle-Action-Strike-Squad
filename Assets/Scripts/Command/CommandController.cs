using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandController : AbstractSingleton<CommandController>, IReadableForUI
{
    //TODO: calling this Action is weird because of default C#/Unity stuff
    //TODO: maybe I should make an Ability Executor Prefab and have the AbilityController instantiate and use it

    [Header("Runtime")]
    [SerializeField] private Command current;
    [SerializeField] private float runtime;
    public Command Current { get => current; private set => current = value; }
    public float Runtime { get => runtime; private set => runtime = value; }

    private void Update()
    {
        if (HasCurrent())
        {
            Runtime += Time.deltaTime;
            float lerpRatio = Mathf.Clamp01(Runtime);
            CameraPosition(lerpRatio);
            Current.UpdateExecution();
        }
    }

    public string ReadForUI()
    {
        return Current?.ToString();
    }

    public bool HasCurrent()
    {
        return Current;
    }

    public bool SetCurrent(AbilityInstance abilityInstance, LevelTile slot, List<PathfindingNode> path)
    {
        if (HasCurrent()) return false;

        Command newCommand = CommandPrefabs.Instance.Instantiate(abilityInstance);
        newCommand.SetTarget(slot, path);
        newCommand.SetCallbacks(null, FinishCurrent);
        bool started = newCommand.TryToStartExecution();
        if (!started) return false;

        Current = newCommand;
        Runtime = 0F;
        return true;
    }

    private void FinishCurrent()
    {
        CameraPosition();
        Character actor = Current.Actor;
        //Destroy(Current.gameObject);
        Current = null;
        Runtime = -1F;
        actor.SetCommand(null);
    }

    private void CameraPosition(float lerpRatio = 1F)
    {
        Vector3 position = Current.Actor.GetPosition();
        CameraController.Instance.Position(position, lerpRatio);
    }
}
