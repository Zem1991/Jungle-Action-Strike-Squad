using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBasicsUI : MonoBehaviour
{
    [Header("AbilityBasicsUI Awake")]
    [SerializeField] private AbilitySpriteUI abilitySprite;
    [SerializeField] private AbilityNameUI abilityName;
    [SerializeField] private AbilityAccuracyUI abilityAccuracy;
    [SerializeField] private AbilityActionPointsCostUI abilityActionPointsCost;

    private void Awake()
    {
        abilitySprite = GetComponentInChildren<AbilitySpriteUI>();
        abilityName = GetComponentInChildren<AbilityNameUI>();
        abilityAccuracy = GetComponentInChildren<AbilityAccuracyUI>();
        abilityActionPointsCost = GetComponentInChildren<AbilityActionPointsCostUI>();
    }

    public void Refresh(AbilityInstance abilityInstance)
    {
        abilitySprite.Refresh(abilityInstance);
        abilityName.Refresh(abilityInstance);
        abilityAccuracy.Refresh(abilityInstance);
        abilityActionPointsCost.Refresh(abilityInstance);
    }
}
