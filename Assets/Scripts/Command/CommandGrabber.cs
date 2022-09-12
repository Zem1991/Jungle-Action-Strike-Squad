using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CommandGrabber
{
    [Header("Movement")]
    [SerializeField] private Command move;
    [SerializeField] private Command sneak;
    public Command Move { get => move; private set => move = value; }
    public Command Sneak { get => sneak; private set => sneak = value; }

    [Header("Melee")]
    [SerializeField] private Command unarmedAttack;
    [SerializeField] private Command takedown;
    public Command UnarmedAttack { get => unarmedAttack; private set => unarmedAttack = value; }
    public Command Takedown { get => takedown; private set => takedown = value; }

    [Header("Primary Item")]
    [SerializeField] private Command primaryItem1;
    [SerializeField] private Command primaryItem2;
    [SerializeField] private Command primaryReload;
    [SerializeField] private Command primaryThrow;
    [SerializeField] private Command overwatch;
    public Command PrimaryItem1 { get => primaryItem1; private set => primaryItem1 = value; }
    public Command PrimaryItem2 { get => primaryItem2; private set => primaryItem2 = value; }
    public Command PrimaryReload { get => primaryReload; private set => primaryReload = value; }
    public Command PrimaryThrow { get => primaryThrow; private set => primaryThrow = value; }
    public Command Overwatch { get => overwatch; private set => overwatch = value; }

    [Header("Sidearm")]
    [SerializeField] private Command sidearmAttack;
    [SerializeField] private Command sidearmReload;
    [SerializeField] private Command sidearmThrow;
    public Command SidearmAttack { get => sidearmAttack; private set => sidearmAttack = value; }
    public Command SidearmReload { get => sidearmReload; private set => sidearmReload = value; }
    public Command SidearmThrow { get => sidearmThrow; private set => sidearmThrow = value; }

    public CommandGrabber(Character actor)
    {
        Item primaryItem = actor.GetPrimaryItem();
        Weapon sidearm = actor.GetSidearm();
        GenerateMovement();
        GenerateMelee();
        GeneratePrimaryItem(primaryItem);
        GenerateSidearm(sidearm);
    }
    
    private void GenerateMovement()
    {
        CommandPrefabs prefabs = CommandPrefabs.Instance;
        Move = prefabs.Move;
        Sneak = prefabs.Sneak;
    }

    private void GenerateMelee()
    {
        CommandPrefabs prefabs = CommandPrefabs.Instance;
        UnarmedAttack = prefabs.UnarmedAttack;
        Takedown = prefabs.Takedown;
    }

    private void GeneratePrimaryItem(Item primaryItem)
    {
        if (!primaryItem) return;
        CommandPrefabs prefabs = CommandPrefabs.Instance;
        bool isWeapon = primaryItem as Weapon;
        bool isThrowable = primaryItem.IsThrowable;
        bool canOverwatch = isWeapon;
        PrimaryItem1 = primaryItem.Command1;
        PrimaryItem2 = primaryItem.Command2;
        PrimaryReload = isWeapon ? prefabs.PrimaryReload : null;
        PrimaryThrow = isThrowable ? prefabs.PrimaryThrow : null;
        Overwatch = canOverwatch ? prefabs.Overwatch : null;
    }

    private void GenerateSidearm(Weapon sidearm)
    {
        if (!sidearm || !sidearm.IsSidearm) return;
        CommandPrefabs prefabs = CommandPrefabs.Instance;
        bool isThrowable = sidearm.IsThrowable;
        SidearmAttack = sidearm.Command1;
        SidearmReload = prefabs.SidearmReload;
        SidearmThrow = isThrowable ? prefabs.SidearmThrow : null;
    }
    
    public Command GetHotkeyCommand(CommandHotkey hotkey, bool modeToggle)
    {
        Command result = null;
        switch (hotkey)
        {
            case CommandHotkey.MOVE:
                result = modeToggle ? Sneak : Move;
                break;
            case CommandHotkey.MELEE:
                result = modeToggle ? Takedown : UnarmedAttack;
                break;
            case CommandHotkey.CONTEXT1:
                result = modeToggle ? Overwatch : PrimaryItem1;
                break;
            case CommandHotkey.CONTEXT2:
                result = modeToggle ? SidearmAttack : PrimaryItem2;
                break;
            case CommandHotkey.RELOAD:
                result = modeToggle ? SidearmReload : PrimaryReload;
                break;
            case CommandHotkey.THROW:
                result = modeToggle ? SidearmThrow : PrimaryThrow;
                break;
        }
        return result;
    }
}
