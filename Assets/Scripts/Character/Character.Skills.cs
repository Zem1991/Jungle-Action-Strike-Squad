using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Skills")]
    [SerializeField] private SkillSet skillSet;
    public SkillSet SkillSet { get => skillSet; private set => skillSet = value; }

    public string GetSkillText(SkillType skillType)
    {
        return SkillSet.GetSkillText(skillType);
    }
}
