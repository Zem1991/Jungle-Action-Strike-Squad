using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrefabs : AbstractSingleton<UIPrefabs>
{
    [Header("Selection")]
    [SerializeField] private AbilityInstanceUI abilityInstance;

    public AbilityInstanceUI Instantiate(AbilityInstance source)
    {
        AbilityInstanceUI result = Instantiate(abilityInstance, transform);
        result.Initialize(source);
        return result;
    }
}
