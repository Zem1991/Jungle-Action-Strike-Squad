using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : AbstractSingleton<ActionController>, IReadableForUI
{
    //TODO: calling this Action is weird because of default C#/Unity stuff
    //TODO: maybe I should make an Command Executor Prefab and have the CommandController instantiate and use it

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

    public bool SetCurrent(CommandData command, Character actor, LevelTile slot, List<PathfindingNode> path)
    {
        if (HasCurrent()) return false;
        Current = CommandPrefabs.Instance.InstantiateCommand(command);
        Current.TryToExecute(actor, slot, path, null, FinishCurrent);
        Runtime = 0F;
        actor.SetAction(Current);
        return true;
    }

    private void FinishCurrent()
    {
        CameraPosition();
        Character actor = Current.Actor;
        //Destroy(Current.gameObject);
        Current = null;
        Runtime = -1F;
        actor.SetAction(null);
    }

    private void CameraPosition(float lerpRatio = 1F)
    {
        Vector3 position = Current.Actor.GetPosition();
        CameraController.Instance.Position(position, lerpRatio);
    }
}
