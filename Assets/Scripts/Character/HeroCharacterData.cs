using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JASS Data/Character/Hero Character")]
public class HeroCharacterData : CharacterData
{
    [Header("HeroCharacterData")]
    [SerializeField][Min(1)] private int level;
}
