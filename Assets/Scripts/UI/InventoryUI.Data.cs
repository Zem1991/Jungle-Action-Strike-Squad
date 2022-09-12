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
        charSprite.sprite = character.CharacterSprite;
        charName.text = character.CharacterName;
        charHealth.text = $"HP {character.HealthPoints}";
        charAction.text = $"AP {character.ActionPoints}";

        skillCombat.text = character.GetSkillText(SkillType.COMBAT);
        skillSurvival.text = character.GetSkillText(SkillType.SURVIVAL);
        skillExplosives.text = character.GetSkillText(SkillType.EXPLOSIVES);
        skillMedical.text = character.GetSkillText(SkillType.MEDICAL);
        skillToolsAndTraps.text = character.GetSkillText(SkillType.TOOLS_TRAPS);
        skillLeadership.text = character.GetSkillText(SkillType.LEADERSHIP);
    }
}
