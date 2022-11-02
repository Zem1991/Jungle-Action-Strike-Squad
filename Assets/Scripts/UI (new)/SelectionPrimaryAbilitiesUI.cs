using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPrimaryAbilitiesUI : SelectionSectionUI
{
    public override void Refresh()
    {
        base.Refresh();
    }

    protected override AbilitySet GetAbilitySet()
    {
        return Character.PrimaryAS;
    }
}
