using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityInputProcessor
{
    public void Read(AbilityInputReader reader)
    {
        int newIndex = reader.KeyToIndex();
        AbilitySetType newSetType = IndexToAbilitySetType(newIndex);

        if (newSetType == AbilitySetType.NONE) DoWhenWithoutSet(newSetType);
        else DoWhenSetSelected(newIndex);
    }

    private AbilitySetType IndexToAbilitySetType(int index)
    {
        return (AbilitySetType)index;
    }

    private void DoWhenWithoutSet(AbilitySetType newSetType)
    {
        AbilityController abilityController = AbilityController.Instance;
        abilityController.Set(newSetType);
    }

    private void DoWhenSetSelected(int index)
    {
        AbilityController abilityController = AbilityController.Instance;
        AbilitySetType abilitySetType = abilityController.AbilitySetType;
        if (abilitySetType == AbilitySetType.NONE) return;

        Character actor = SelectionController.Instance.Get();
        AbilityInstance abilityInstance = actor.GetHotkeyAbility(abilitySetType, index);
        if (abilityInstance == null) return;

        abilityController.Set(abilityInstance, false);
    }
}
