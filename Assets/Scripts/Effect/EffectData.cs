using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectData : ScriptableObject
{
    public abstract bool Apply(Character actor, Item item, Vector3 position, Character target);
}
