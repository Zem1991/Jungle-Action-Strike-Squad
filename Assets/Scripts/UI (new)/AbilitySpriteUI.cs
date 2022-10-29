using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySpriteUI : SpriteUI<AbilityInstance>
{
    protected override Sprite GetSprite(AbilityInstance thing)
    {
        return thing.AbilityData.Sprite;
    }
}
