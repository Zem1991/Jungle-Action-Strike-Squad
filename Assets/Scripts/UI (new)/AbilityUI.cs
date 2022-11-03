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

    [Header("Runtime")]
    [SerializeField] private AbilityInstance ability = null;

    protected override void Awake()
    {
        base.Awake();

        //Fix for Serialization creating empty objects instead of null objects
        ability = null;
    }

    public override void Refresh()
    {
        if (ability == null)
        {
            Hide();
            return;
        }

        abilitySprite.Refresh(ability);
        abilityName.text = ability.AbilityData.Name;
        Show();
    }

    public void Initialize(AbilityInstance abilityInstance)
    {
        ability = abilityInstance;
        Refresh();
    }
}
