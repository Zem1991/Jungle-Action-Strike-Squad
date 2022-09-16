using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "JASS/Effect/")]
public abstract class Effect : ScriptableObject//MonoBehaviour
{
    //[Header("Abstract Effect")]
    //[SerializeField][Range(0F, 2F)] private float skillInfluence = 1F;
    //public float SkillInfluence { get => skillInfluence; private set => skillInfluence = value; }

    public abstract bool Apply(Character actor, Item item, Vector3 position, Character target);
}
