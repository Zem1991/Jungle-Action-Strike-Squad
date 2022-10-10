using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JASS Data/Effect/Damage Effect")]
public class DamageEffectData : EffectData
{
    [Header("DamageEffectData")]
    [SerializeField] private DiceRoll damage;
    public DiceRoll Damage { get => damage; private set => damage = value; }

    public override bool Apply(Character actor, Item item, Vector3 position, Character target)
    {
        //int amount = Damage.Roll();
        //return target.TakeDamage(amount);
        return true;
    }
}
