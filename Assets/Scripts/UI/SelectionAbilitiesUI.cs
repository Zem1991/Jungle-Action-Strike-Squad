using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionAbilitiesUI : UIPanel
{
    [Header("SelectionAbilitysUI Awake")]
    [SerializeField] private List<AbilityButtonUI> abilityButtons;

    protected override void Awake()
    {
        base.Awake();
        abilityButtons = new List<AbilityButtonUI>(GetComponentsInChildren<AbilityButtonUI>());
    }

    public override void Refresh()
    {
        throw new System.NotImplementedException();
    }

    public void Refresh(Character character)
    {
        AbilityController abilityController = AbilityController.Instance;
        AbilityInstance abilityInstance = abilityController.Current;
        if (abilityInstance != null)
        {
            Hide();
            return;
        }

        ChangeBackgroundColor(character);

        bool canControl = PlayerController.Instance.OwnedByLocalPlayer(character);
        if (canControl)
        {
            for (int index = 0; index < abilityButtons.Count; index++)
            {
                //Ability ability = AbilityHelper.FromGrabber(character, index);
                //AbilityHotkey hotkey = (AbilityHotkey)index;
                //bool modeToggle = false;
                
                //TODO??
                //AbilityInstance ability = character.GetHotkeyAbility(hotkey, modeToggle);
                //abilityButtons[index].Refresh(ability);
            }
            Show();
        }
        else
        {
            Hide();
        }
    }
}
