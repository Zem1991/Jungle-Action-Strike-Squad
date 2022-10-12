using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JASS Data/Effect/Heal Effect")]
public class HealEffectData : EffectData
{
    [Header("HealEffectData")]
    [SerializeField] private DiceRoll healing;
    public DiceRoll Healing { get => healing; private set => healing = value; }

    public override bool Apply(Character actor, Item item, Vector3 position, Character target)
    {
        int amount = Healing.Roll();
        return target.TakeHealing(amount);
    }
}
