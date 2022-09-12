using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandSpriteUI : MonoBehaviour
{
    [Header("Awake")]
    [SerializeField] private Image spriteBack;
    [SerializeField] private Image spriteFront;

    private void Awake()
    {
        List<Image> sprites = new List<Image>(GetComponentsInChildren<Image>());
        spriteBack = sprites[0];
        spriteFront = sprites[1];
    }

    public void Refresh(Command command)
    {
        if (command)
        {
            spriteBack.enabled = true;
            spriteFront.enabled = true;
            spriteFront.sprite = command.Sprite;
        }
        else
        {
            spriteBack.enabled = false;
            spriteFront.enabled = false;
            spriteFront.sprite = null;
        }
    }
}
