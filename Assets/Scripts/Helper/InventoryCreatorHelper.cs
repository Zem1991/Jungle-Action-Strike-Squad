using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryCreatorHelper
{
    public static void FullInventory(Character character, CharacterData characterData)
    {
        LevelPrefabs levelPrefabs = LevelPrefabs.Instance;
        Transform transform = character.transform;
        Inventory inventory = character.Inventory;

        Item mainItem = levelPrefabs.InstantiateItem(characterData.MainItem, transform);
        Item sidearm = levelPrefabs.InstantiateItem(characterData.Sidearm, transform);
        Item headWearable = levelPrefabs.InstantiateItem(characterData.HeadWearable, transform);
        Item torsoWearable = levelPrefabs.InstantiateItem(characterData.TorsoWearable, transform);
        Item backpack1 = levelPrefabs.InstantiateItem(characterData.Backpack1, transform);
        Item backpack2 = levelPrefabs.InstantiateItem(characterData.Backpack2, transform);
        Item backpack3 = levelPrefabs.InstantiateItem(characterData.Backpack3, transform);
        Item backpack4 = levelPrefabs.InstantiateItem(characterData.Backpack4, transform);

        if (mainItem) inventory.Add(mainItem);
        if (sidearm) inventory.Add(sidearm);
        if (headWearable) inventory.Add(headWearable);
        if (torsoWearable) inventory.Add(torsoWearable);
        if (backpack1) inventory.Add(backpack1);
        if (backpack2) inventory.Add(backpack2);
        if (backpack3) inventory.Add(backpack3);
        if (backpack4) inventory.Add(backpack4);
    }
}
