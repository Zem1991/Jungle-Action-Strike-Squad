using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : UIPanel
{
    [Header("Scene")]
    [SerializeField] private AbilitySpriteUI abilitySprite;
    [SerializeField] private Text abilityName;
    [SerializeField] private Text targetType;
    [SerializeField] private Text itemRange;
    [SerializeField] private Text apCost;
    [SerializeField] private Text skillAccuracy;
    [SerializeField] private Text itemAccuracy;

    public override void Refresh()
    {
        AbilityController abilityController = AbilityController.Instance;
        AbilityInstance ability = abilityController.Current;
        string abilityNameText = abilityController.ReadForUI();
        if (ability == null)
        {
            Hide();
            return;
        }

        abilitySprite.Refresh(ability);
        abilityName.text = abilityNameText;
        Show();
    }
}
