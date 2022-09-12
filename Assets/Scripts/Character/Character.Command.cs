using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Command")]
    [SerializeField] private CommandGrabber commands;
    //[SerializeField] private CommandWheel commandWheel;
    public CommandGrabber Commands { get => commands; private set => commands = value; }
    //public CommandWheel CommandWheel { get => commandWheel; private set => commandWheel = value; }

    public void RefreshCommands()
    {
        Commands = new CommandGrabber(this);
        //CommandWheel = GenerateCommandWheel(CommandContext.CHARACTER);
    }

    //public CommandWheel GenerateCommandWheel(CommandContext commandContext)
    //{
    //    return new CommandWheel(Commands, commandContext);
    //}

    public Command GetHotkeyCommand(CommandHotkey hotkey, bool modeToggle)
    {
        return Commands.GetHotkeyCommand(hotkey, modeToggle);
    }

    public Command GetAttackCommand()
    {
        //TODO: this but properly
        Weapon weapon = GetMainWeapon();
        Command result = weapon?.Command1;
        //TODO: default back to melee
        //if (!result) result = CommandController.Instance.MeleeAttack;
        return result;
    }
}
