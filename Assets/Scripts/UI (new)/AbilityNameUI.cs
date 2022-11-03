using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityNameUI : TextUI<AbilityInstance>
{
    protected override string GetText(AbilityInstance thing)
    {
        return thing.AbilityData.Name;
    }
}
