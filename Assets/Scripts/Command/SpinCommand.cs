using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCommand : Command
{
    private float timer = 1F;
    private Quaternion startingRotation;

    protected override void StartExecution(Character actor, LevelTile slot, List<PathfindingNode> path, Action onStart, Action onFinish)
    {
        startingRotation = Actor.transform.rotation;
        base.StartExecution(actor, slot, path, onStart, onFinish);
    }

    protected override void UpdateExecution()
    {
        Transform actorTransform = Actor.transform;
        float deltaTime = Time.deltaTime;

        actorTransform.eulerAngles += new Vector3(0, 360 * deltaTime, 0);
        timer -= deltaTime;
        if (timer > 0f) return;

        actorTransform.rotation = startingRotation;
        FinishExecution();
    }
}
