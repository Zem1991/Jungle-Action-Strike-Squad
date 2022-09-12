using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCommandsUI : UIPanel
{
    [Header("SelectionCommandsUI Awake")]
    [SerializeField] private List<CommandButtonUI> commandButtons;

    protected override void Awake()
    {
        base.Awake();
        commandButtons = new List<CommandButtonUI>(GetComponentsInChildren<CommandButtonUI>());
    }

    public override void Refresh()
    {
        throw new System.NotImplementedException();
    }

    public void Refresh(Character character)
    {
        CommandController commandController = CommandController.Instance;
        Command ccCommand = commandController.GetCommand();
        if (ccCommand)
        {
            Hide();
            return;
        }

        ChangeBackgroundColor(character);

        bool canControl = PlayerController.Instance.OwnedByLocalPlayer(character);
        if (canControl)
        {
            for (int index = 0; index < commandButtons.Count; index++)
            {
                //Command command = CommandHelper.FromGrabber(character, index);
                CommandHotkey hotkey = (CommandHotkey)index;
                bool modeToggle = false;
                Command command = character.GetHotkeyCommand(hotkey, modeToggle);
                commandButtons[index].Refresh(command);
            }
            Show();
        }
        else
        {
            Hide();
        }
    }
}
