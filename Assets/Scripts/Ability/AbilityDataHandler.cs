using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDataHandler : AbstractSingleton<AbilityDataHandler>
{
    [Header("Generic")]
    [SerializeField] private SpinAbilityData spin;
    [SerializeField] private AttackAbilityData attack;
    public SpinAbilityData Spin { get => spin; private set => spin = value; }
    public AttackAbilityData Attack { get => attack; private set => attack = value; }

    [Header("Movement")]
    [SerializeField] private MoveAbilityData move;
    [SerializeField] private MoveAbilityData sneak;
    public MoveAbilityData Move { get => move; private set => move = value; }
    public MoveAbilityData Sneak { get => sneak; private set => sneak = value; }

    [Header("Melee")]
    [SerializeField] private AttackAbilityData unarmedAttack;
    [SerializeField] private AbilityData takedown;
    public AttackAbilityData UnarmedAttack { get => unarmedAttack; private set => unarmedAttack = value; }
    public AbilityData Takedown { get => takedown; private set => takedown = value; }

    [Header("Primary Weapon")]
    [SerializeField] private ReloadAbilityData primaryReload;
    [SerializeField] private AbilityData primaryThrow;
    [SerializeField] private AbilityData overwatch;
    public ReloadAbilityData PrimaryReload { get => primaryReload; private set => primaryReload = value; }
    public AbilityData PrimaryThrow { get => primaryThrow; private set => primaryThrow = value; }
    public AbilityData Overwatch { get => overwatch; private set => overwatch = value; }

    [Header("Sidearm")]
    [SerializeField] private ReloadAbilityData sidearmReload;
    [SerializeField] private AbilityData sidearmThrow;
    public ReloadAbilityData SidearmReload { get => sidearmReload; private set => sidearmReload = value; }
    public AbilityData SidearmThrow { get => sidearmThrow; private set => sidearmThrow = value; }

    public AbilityData FromContext(Character actor, LevelTile targetSlot, out Item item, out List<PathfindingNode> path)
    {
        PlayerController playerController = PlayerController.Instance;
        Character target = targetSlot.Character;
        item = actor.GetPrimaryItem();

        bool characterFromPlayer = playerController.OwnedByLocalPlayer(target);
        bool characterFromEnemy = playerController.OwnedByEnemyPlayer(target);
        bool isReachable = actor.Pathfind(targetSlot, out path);

        if (characterFromPlayer) return Spin;
        if (characterFromEnemy) return Attack;
        if (isReachable) return Move;
        return null;
    }
}
