using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBasicsUI : MonoBehaviour
{
    [Header("CharacterBasicsUI Awake")]
    [SerializeField] private ItemSpriteUI itemSprite;
    [SerializeField] private RangedWeaponAmmunitionBarUI rangedWeaponAmmunitionBar;

    private void Awake()
    {
        itemSprite = GetComponentInChildren<ItemSpriteUI>();
        rangedWeaponAmmunitionBar = GetComponentInChildren<RangedWeaponAmmunitionBarUI>();
    }

    public void Refresh(Item item)
    {
        RangedWeapon rangedWeapon = item as RangedWeapon;

        itemSprite.Refresh(item);
        rangedWeaponAmmunitionBar.Refresh(rangedWeapon);
    }
}
