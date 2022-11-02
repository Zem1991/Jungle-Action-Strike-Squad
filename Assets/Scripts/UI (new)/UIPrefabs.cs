using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrefabs : AbstractSingleton<UIPrefabs>
{
    [Header("Ability")]
    [SerializeField] private AbilityInstanceUI abilityInstance;

    [Header("Player")]
    [SerializeField] private PlayerCharacterUI playerCharacter;

    public AbilityInstanceUI Instantiate(AbilityInstance source, Transform transform)
    {
        AbilityInstanceUI result = Instantiate(abilityInstance, transform);
        result.Initialize(source);
        return result;
    }

    public PlayerCharacterUI Instantiate(Character character, Transform transform)
    {
        PlayerCharacterUI result = Instantiate(playerCharacter, transform);
        result.Initialize(character);
        return result;
    }
}
