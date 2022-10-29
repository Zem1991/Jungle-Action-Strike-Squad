using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityInstanceUI : UIPanel
{
    [Header("Scene")]
    [SerializeField] private AbilitySpriteUI abilitySprite;
    [SerializeField] private Text abilityName;
    [SerializeField] private Text targetType;
    [SerializeField] private Text itemRange;
    [SerializeField] private Text apCost;
    [SerializeField] private Text skillAccuracy;
    [SerializeField] private Text itemAccuracy;

    [Header("Runtime")]
    [SerializeField] private AbilityInstance ability;

    public override void Refresh()
    {
        AbilityController abilityController = AbilityController.Instance;
        ability = abilityController.Current;

        if (ability == null)
        {
            Hide();
            return;
        }

        string abilityNameText = abilityController.ReadForUI();
        abilitySprite.Refresh(ability);
        abilityName.text = abilityNameText;
        Show();
    }
}
