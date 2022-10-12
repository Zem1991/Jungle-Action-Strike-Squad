using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPrefabs : AbstractSingleton<CommandPrefabs>
{
    [SerializeField] private SpinCommand spin;
    [SerializeField] private MoveCommand move;
    [SerializeField] private AttackCommand attack;

    public Command InstantiateCommand(CommandData commandData)
    {
        SpinCommandData spinD = commandData as SpinCommandData;
        MoveCommandData moveD = commandData as MoveCommandData;
        AttackCommandData attackD = commandData as AttackCommandData;

        Command prefab = null;
        if (spinD) prefab = spin;
        else if (moveD) prefab = move;
        else if (attackD) prefab = attack;

        Command result = Instantiate(prefab, transform);
        result.Initialize(commandData);
        return result;
    }
}
