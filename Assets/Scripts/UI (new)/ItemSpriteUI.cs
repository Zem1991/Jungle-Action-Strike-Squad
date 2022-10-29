using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpriteUI : SpriteUI<Item>
{
    protected override Sprite GetSprite(Item thing)
    {
        return thing.ItemData.Sprite;
    }
}
