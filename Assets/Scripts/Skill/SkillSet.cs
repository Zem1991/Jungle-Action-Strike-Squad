using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSet : MonoBehaviour
{
    [SerializeField] private Resource combatSkill;
    [SerializeField] private Resource survivalSkill;
    [SerializeField] private Resource explosivesSkill;
    [SerializeField] private Resource medicalSkill;
    [SerializeField] private Resource toolsAndTrapsSkill;
    [SerializeField] private Resource leadershipSkill;
    public Resource CombatSkill { get => combatSkill; private set => combatSkill = value; }
    public Resource SurvivalSkill { get => survivalSkill; private set => survivalSkill = value; }
    public Resource ExplosivesSkill { get => explosivesSkill; private set => explosivesSkill = value; }
    public Resource MedicalSkill { get => medicalSkill; private set => medicalSkill = value; }
    public Resource ToolsAndTrapsSkill { get => toolsAndTrapsSkill; private set => toolsAndTrapsSkill = value; }
    public Resource LeadershipSkill { get => leadershipSkill; private set => leadershipSkill = value; }

    //TODO: two methods for this - one for name and another for current value
    public string GetSkillText(SkillType skillType)
    {
        string name = null;
        Resource skill = null;
        switch (skillType)
        {
            case SkillType.COMBAT:
                name = "CBT";
                skill = CombatSkill;
                break;
            case SkillType.SURVIVAL:
                name = "SUR";
                skill = SurvivalSkill;
                break;
            case SkillType.EXPLOSIVES:
                name = "EXS";
                skill = ExplosivesSkill;
                break;
            case SkillType.MEDICAL:
                name = "MED";
                skill = MedicalSkill;
                break;
            case SkillType.TOOLS_TRAPS:
                name = "T&T";
                skill = ToolsAndTrapsSkill;
                break;
            case SkillType.LEADERSHIP:
                name = "LDR";
                skill = LeadershipSkill;
                break;
        }
        return $"{name} {skill.Current}";
    }
}
