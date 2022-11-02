using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCharacterAbilitiesUI : SelectionSectionUI
{
    public override void Refresh()
    {
        base.Refresh();
    }

    protected override AbilitySet GetAbilitySet()
    {
        return Character.CharacterAS;
    }
}
