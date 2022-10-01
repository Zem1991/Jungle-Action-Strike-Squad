using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorTag
{
    private Color color;
    public Color Color { get => color; set => color = value; }

    public PlayerColorTag(Color color)
    {
        Color = color;
    }

    public void Apply(GameObject target)
    {
        var sprites = target.GetComponentsInChildren<SpriteRenderer>();
        foreach (var item in sprites)
        {
            if (!item.CompareTag("Player")) continue;
            item.color = Color;
        }
    }

    public void Apply(List<GameObject> targetList)
    {
        foreach (var item in targetList)
        {
            Apply(item);
        }
    }
}
