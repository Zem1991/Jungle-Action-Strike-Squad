using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandUI : UIPanel
{
    [Header("Scene")]
    [SerializeField] private CommandSpriteUI commandSprite;
    [SerializeField] private Text commandName;
    [SerializeField] private Text targetType;
    [SerializeField] private Text itemRange;
    [SerializeField] private Text apCost;
    [SerializeField] private Text skillAccuracy;
    [SerializeField] private Text itemAccuracy;

    public override void Refresh()
    {
        CommandController commandController = CommandController.Instance;
        Command command = commandController.GetCommand();
        string commandNameText = commandController.ReadForUI();
        if (!command)
        {
            Hide();
            return;
        }

        commandSprite.Refresh(command);
        commandName.text = commandNameText;
        Show();
    }
}
