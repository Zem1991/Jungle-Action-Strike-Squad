using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Character : MonoBehaviour
{
    [Header("Skills")]
    [SerializeField] private SkillSet skillSet;
    public SkillSet SkillSet { get => skillSet; private set => skillSet = value; }
}
