using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SpriteUI<T> : MonoBehaviour
{
    [Header("SpriteUI Awake")]
    [SerializeField] private Image spriteBack;
    [SerializeField] private Image spriteFront;

    private void Awake()
    {
        List<Image> sprites = new List<Image>(GetComponentsInChildren<Image>());
        spriteBack = sprites[0];
        spriteFront = sprites[1];
    }

    public void Refresh(T thing)
    {
        if (thing != null)
        {
            spriteBack.enabled = true;
            spriteFront.enabled = true;
            spriteFront.sprite = GetSprite(thing);
        }
        else
        {
            spriteBack.enabled = false;
            spriteFront.enabled = false;
            spriteFront.sprite = null;
        }
    }

    protected abstract Sprite GetSprite(T thing);
}
