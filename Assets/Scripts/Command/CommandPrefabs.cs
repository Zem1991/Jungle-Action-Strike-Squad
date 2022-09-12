using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPrefabs : AbstractSingleton<CommandPrefabs>
{
    [Header("Generic")]
    [SerializeField] private SpinCommand spin;
    [SerializeField] private AttackCommand attack;
    public SpinCommand Spin { get => spin; private set => spin = value; }
    public AttackCommand Attack { get => attack; private set => attack = value; }

    [Header("Movement")]
    [SerializeField] private MoveCommand move;
    [SerializeField] private MoveCommand sneak;
    public MoveCommand Move { get => move; private set => move = value; }
    public MoveCommand Sneak { get => sneak; private set => sneak = value; }

    [Header("Melee")]
    [SerializeField] private AttackCommand unarmedAttack;
    [SerializeField] private Command takedown;
    public AttackCommand UnarmedAttack { get => unarmedAttack; private set => unarmedAttack = value; }
    public Command Takedown { get => takedown; private set => takedown = value; }

    [Header("Primary Weapon")]
    [SerializeField] private Command primaryReload;
    [SerializeField] private Command primaryThrow;
    [SerializeField] private Command overwatch;
    public Command PrimaryReload { get => primaryReload; private set => primaryReload = value; }
    public Command PrimaryThrow { get => primaryThrow; private set => primaryThrow = value; }
    public Command Overwatch { get => overwatch; private set => overwatch = value; }

    [Header("Sidearm")]
    [SerializeField] private Command sidearmReload;
    [SerializeField] private Command sidearmThrow;
    public Command SidearmReload { get => sidearmReload; private set => sidearmReload = value; }
    public Command SidearmThrow { get => sidearmThrow; private set => sidearmThrow = value; }
}
