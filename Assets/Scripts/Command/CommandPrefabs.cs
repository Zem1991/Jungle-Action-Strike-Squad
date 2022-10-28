using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPrefabs : AbstractSingleton<CommandPrefabs>
{
    [SerializeField] private SpinCommand spin;
    [SerializeField] private MoveCommand move;
    [SerializeField] private AttackCommand attack;
    [SerializeField] private ReloadCommand reload;

    public Command Instantiate(AbilityInstance abilityInstance)
    {
        if (abilityInstance == null) return null;

        AbilityData abilityData = abilityInstance.AbilityData;
        Transform transform = abilityInstance.Actor.transform;

        SpinAbilityData spinD = abilityData as SpinAbilityData;
        MoveAbilityData moveD = abilityData as MoveAbilityData;
        AttackAbilityData attackD = abilityData as AttackAbilityData;

        Command prefab = null;
        if (spinD) prefab = spin;
        else if (moveD) prefab = move;
        else if (attackD) prefab = attack;

        Command result = Instantiate(prefab, transform);
        result.Initialize(abilityInstance.AbilityData, abilityInstance.Actor, abilityInstance.Item);
        return result;
    }
}
