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

    public CommandData GetHotkeyCommand(CommandHotkey hotkey, bool modeToggle)
    {
        return Commands.GetHotkeyCommand(hotkey, modeToggle);
    }

    public CommandData GetAttackCommand()
    {
        //TODO: this but properly
        Weapon weapon = GetMainWeapon();
        CommandData result = weapon?.ItemData.Command1;
        //TODO: default back to melee
        //if (!result) result = CommandController.Instance.MeleeAttack;
        return result;
    }
}
