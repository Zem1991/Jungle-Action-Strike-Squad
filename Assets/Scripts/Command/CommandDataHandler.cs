using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandDataHandler : AbstractSingleton<CommandDataHandler>
{
    [Header("Generic")]
    [SerializeField] private SpinCommandData spin;
    [SerializeField] private AttackCommandData attack;
    public SpinCommandData Spin { get => spin; private set => spin = value; }
    public AttackCommandData Attack { get => attack; private set => attack = value; }

    [Header("Movement")]
    [SerializeField] private MoveCommandData move;
    [SerializeField] private MoveCommandData sneak;
    public MoveCommandData Move { get => move; private set => move = value; }
    public MoveCommandData Sneak { get => sneak; private set => sneak = value; }

    [Header("Melee")]
    [SerializeField] private AttackCommandData unarmedAttack;
    [SerializeField] private CommandData takedown;
    public AttackCommandData UnarmedAttack { get => unarmedAttack; private set => unarmedAttack = value; }
    public CommandData Takedown { get => takedown; private set => takedown = value; }

    [Header("Primary Weapon")]
    [SerializeField] private ReloadCommandData primaryReload;
    [SerializeField] private CommandData primaryThrow;
    [SerializeField] private CommandData overwatch;
    public ReloadCommandData PrimaryReload { get => primaryReload; private set => primaryReload = value; }
    public CommandData PrimaryThrow { get => primaryThrow; private set => primaryThrow = value; }
    public CommandData Overwatch { get => overwatch; private set => overwatch = value; }

    [Header("Sidearm")]
    [SerializeField] private ReloadCommandData sidearmReload;
    [SerializeField] private CommandData sidearmThrow;
    public ReloadCommandData SidearmReload { get => sidearmReload; private set => sidearmReload = value; }
    public CommandData SidearmThrow { get => sidearmThrow; private set => sidearmThrow = value; }

    public CommandData FromContext(Character actor, LevelTile targetSlot, out List<PathfindingNode> path)
    {
        PlayerController playerController = PlayerController.Instance;
        Character target = targetSlot.Character;
        bool characterFromPlayer = playerController.OwnedByLocalPlayer(target);
        bool characterFromEnemy = playerController.OwnedByEnemyPlayer(target);
        bool isReachable = actor.Pathfind(targetSlot, out path);

        if (characterFromPlayer) return Spin;
        if (characterFromEnemy) return Attack;
        if (isReachable) return Move;
        return null;
    }
}
