using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class InventoryUI : UIPanel
{
    [Header("Data: manual references")]
    [SerializeField] private Image charSprite;
    [SerializeField] private Text charName;
    [SerializeField] private Text charHealth;
    [SerializeField] private Text charAction;
    [SerializeField] private Text skillCombat;
    [SerializeField] private Text skillSurvival;
    [SerializeField] private Text skillExplosives;
    [SerializeField] private Text skillMedical;
    [SerializeField] private Text skillToolsAndTraps;
    [SerializeField] private Text skillLeadership;

    private void RefreshData(Character character)
    {
        charSprite.sprite = character.CharacterData.Sprite;
        charName.text = character.CharacterData.Name;
        charHealth.text = $"HP {character.HealthPoints}";
        charAction.text = $"AP {character.ActionPoints}";

        skillCombat.text = SkillType.RangedCombat.Name();
        skillSurvival.text = SkillType.BruteForce.Name();
        skillExplosives.text = SkillType.Explosives.Name();
        skillMedical.text = SkillType.Survival.Name();
        skillToolsAndTraps.text = SkillType.Paramedicine.Name();
        skillLeadership.text = SkillType.Mechanics.Name();
    }
}
