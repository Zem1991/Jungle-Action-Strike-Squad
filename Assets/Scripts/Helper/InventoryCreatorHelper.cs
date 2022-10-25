using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryCreatorHelper
{
    public static void FromCharacterData(Character character, CharacterData characterData)
    {
        FromItemData(character, characterData.MainItem);
        FromItemData(character, characterData.Sidearm);
        FromItemData(character, characterData.HeadWearable);
        FromItemData(character, characterData.TorsoWearable);
        FromItemData(character, characterData.Backpack1);
        FromItemData(character, characterData.Backpack2);
        FromItemData(character, characterData.Backpack3);
        FromItemData(character, characterData.Backpack4);
    }

    public static void FromItemData(Character character, ItemData itemData)
    {
        LevelPrefabs levelPrefabs = LevelPrefabs.Instance;
        Transform transform = character.transform;
        Inventory inventory = character.Inventory;

        Item item = levelPrefabs.InstantiateItem(itemData, transform);
        SendToInventory(item, inventory);
    }

    private static void SendToInventory(Item item, Inventory inventory)
    {
        if (!item) return;
        inventory.Add(item);
        FillAmmunition(item);
    }

    private static void FillAmmunition(Item item)
    {
        RangedWeapon rangedWeapon = item as RangedWeapon;
        if (!rangedWeapon) return;

        LevelPrefabs levelPrefabs = LevelPrefabs.Instance;
        Transform transform = item.transform;

        RangedWeaponData rangedWeaponData = rangedWeapon.ItemData;
        AmmunitionData ammunitionData = rangedWeaponData.DefaultAmmo;

        Ammunition ammunition = levelPrefabs.InstantiateItem(ammunitionData, transform) as Ammunition;
        ammunition.Initialize(ammunitionData, rangedWeaponData.MagazineSize);
        rangedWeapon.Load(ammunition, out Ammunition unloaded);
    }
}
