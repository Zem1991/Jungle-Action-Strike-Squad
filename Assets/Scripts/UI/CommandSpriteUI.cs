using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySpriteUI : MonoBehaviour
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

    public void Refresh(AbilityInstance ability)
    {
        if (ability != null)
        {
            spriteBack.enabled = true;
            spriteFront.enabled = true;
            spriteFront.sprite = ability.AbilityData.Sprite;
        }
        else
        {
            spriteBack.enabled = false;
            spriteFront.enabled = false;
            spriteFront.sprite = null;
        }
    }
}
