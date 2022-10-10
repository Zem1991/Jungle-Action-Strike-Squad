using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillSet
{
    [SerializeField] private Percent rangedCombat;
    [SerializeField] private Percent bruteForce;
    [SerializeField] private Percent explosives;
    [SerializeField] private Percent survival;
    [SerializeField] private Percent paramedicine;
    [SerializeField] private Percent mechanics;
    [SerializeField] private Percent computers;
    [SerializeField] private Percent leadership;

    public Percent RangedCombat { get => rangedCombat; private set => rangedCombat = value; }
    public Percent BruteForce { get => bruteForce; private set => bruteForce = value; }
    public Percent Explosives { get => explosives; private set => explosives = value; }
    public Percent Survival { get => survival; private set => survival = value; }
    public Percent Paramedicine { get => paramedicine; private set => paramedicine = value; }
    public Percent Mechanics { get => mechanics; private set => mechanics = value; }
    public Percent Computers { get => computers; private set => computers = value; }
    public Percent Leadership { get => leadership; private set => leadership = value; }

    public SkillSet(CharacterData characterData)
    {
        RangedCombat = new Percent(characterData.RangedCombat);
        BruteForce = new Percent(characterData.BruteForce);
        Explosives = new Percent(characterData.Explosives);
        Survival = new Percent(characterData.Survival);
        Paramedicine = new Percent(characterData.Paramedicine);
        Mechanics = new Percent(characterData.Mechanics);
        Computers = new Percent(characterData.Computers);
        Leadership = new Percent(characterData.Leadership);
    }
}
