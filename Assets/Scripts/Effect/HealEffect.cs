using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : Effect
{
    [Header("Settings")]
    [SerializeField] private DiceRoll heal;
    public DiceRoll Heal { get => heal; private set => heal = value; }

    public override bool Apply(Character actor, Item item, Vector3 position, Character target)
    {
        int amount = Heal.Roll();
        return target.TakeHealing(amount);
    }
}
