using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCommand : Command
{
    public new SpinAbilityData AbilityData { get => AbilityData; }

    public void Initialize(SpinAbilityData abilityData, Character actor, Item item)
    {
        base.Initialize(abilityData, actor, item);
    }

    [Header("SpinAbility")]
    private float timer = 1F;
    private Quaternion startingRotation;

    protected override void StartExecution()
    {
        startingRotation = Actor.transform.rotation;
        base.StartExecution();
    }

    public override void UpdateExecution()
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
