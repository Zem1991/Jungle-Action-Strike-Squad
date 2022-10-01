using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JASS/Effect/DamageEffect")]
public class DamageEffect : Effect
{
    [Header("DamageEffect")]
    [SerializeField] private DiceRoll damage;
    public DiceRoll Damage { get => damage; private set => damage = value; }

    public override bool Apply(Character actor, Item item, Vector3 position, Character target)
    {
        int amount = Damage.Roll();
        return target.TakeDamage(amount);
    }
}
