using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CommandGrabber
{
    [Header("Movement")]
    [SerializeField] private CommandData move;
    [SerializeField] private CommandData sneak;
    public CommandData Move { get => move; private set => move = value; }
    public CommandData Sneak { get => sneak; private set => sneak = value; }

    [Header("Melee")]
    [SerializeField] private CommandData unarmedAttack;
    [SerializeField] private CommandData takedown;
    public CommandData UnarmedAttack { get => unarmedAttack; private set => unarmedAttack = value; }
    public CommandData Takedown { get => takedown; private set => takedown = value; }

    [Header("Primary Item")]
    [SerializeField] private CommandData primaryItem1;
    [SerializeField] private CommandData primaryItem2;
    [SerializeField] private CommandData primaryReload;
    [SerializeField] private CommandData primaryThrow;
    [SerializeField] private CommandData overwatch;
    public CommandData PrimaryItem1 { get => primaryItem1; private set => primaryItem1 = value; }
    public CommandData PrimaryItem2 { get => primaryItem2; private set => primaryItem2 = value; }
    public CommandData PrimaryReload { get => primaryReload; private set => primaryReload = value; }
    public CommandData PrimaryThrow { get => primaryThrow; private set => primaryThrow = value; }
    public CommandData Overwatch { get => overwatch; private set => overwatch = value; }

    [Header("Sidearm")]
    [SerializeField] private CommandData sidearmAttack;
    [SerializeField] private CommandData sidearmReload;
    [SerializeField] private CommandData sidearmThrow;
    public CommandData SidearmAttack { get => sidearmAttack; private set => sidearmAttack = value; }
    public CommandData SidearmReload { get => sidearmReload; private set => sidearmReload = value; }
    public CommandData SidearmThrow { get => sidearmThrow; private set => sidearmThrow = value; }

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
        CommandDataHandler prefabs = CommandDataHandler.Instance;
        Move = prefabs.Move;
        Sneak = prefabs.Sneak;
    }

    private void GenerateMelee()
    {
        CommandDataHandler prefabs = CommandDataHandler.Instance;
        UnarmedAttack = prefabs.UnarmedAttack;
        Takedown = prefabs.Takedown;
    }

    private void GeneratePrimaryItem(Item primaryItem)
    {
        if (!primaryItem) return;
        CommandDataHandler prefabs = CommandDataHandler.Instance;
        bool isWeapon = primaryItem as Weapon;
        bool isThrowable = true;//primaryItem.IsThrowable;
        bool canOverwatch = isWeapon;
        PrimaryItem1 = primaryItem.ItemData.Command1;
        PrimaryItem2 = primaryItem.ItemData.Command2;
        PrimaryReload = isWeapon ? prefabs.PrimaryReload : null;
        PrimaryThrow = isThrowable ? prefabs.PrimaryThrow : null;
        Overwatch = canOverwatch ? prefabs.Overwatch : null;
    }

    private void GenerateSidearm(Weapon sidearm)
    {
        if (!sidearm || !sidearm.ItemData.IsSidearm) return;
        CommandDataHandler prefabs = CommandDataHandler.Instance;
        bool isThrowable = true;//sidearm.IsThrowable;
        SidearmAttack = sidearm.ItemData.Command1;
        SidearmReload = prefabs.SidearmReload;
        SidearmThrow = isThrowable ? prefabs.SidearmThrow : null;
    }
    
    public CommandData GetHotkeyCommand(CommandHotkey hotkey, bool modeToggle)
    {
        CommandData result = null;
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
