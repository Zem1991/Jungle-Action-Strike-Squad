using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteUI : SpriteUI<Character>
{
    protected override Sprite GetSprite(Character thing)
    {
        return thing.CharacterData.Sprite;
    }
}
