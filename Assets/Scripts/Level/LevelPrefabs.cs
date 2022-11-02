using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPrefabs : AbstractSingleton<LevelPrefabs>
{
    [Header("Item prefabs")]
    [SerializeField] private Ammunition ammunition;
    [SerializeField] private Consumable consumable;
    [SerializeField] private RangedWeapon rangedWeapon;
    [SerializeField] private Tool tool;
    //[SerializeField] private Wearable wearable;

    [Header("Pickup prefab")]
    [SerializeField] private ItemPickup itemPickup;

    public Item InstantiateItem(ItemData itemData, Transform transform)
    {
        if (!itemData) return null;

        AmmunitionData ammunitionD = itemData as AmmunitionData;
        ConsumableData consumableD = itemData as ConsumableData;
        RangedWeaponData rangedWeaponD = itemData as RangedWeaponData;
        ToolData toolD = itemData as ToolData;
        //WearableData wearableD = itemData as WearableData;

        Item prefab = null;
        if (ammunitionD) prefab = ammunition;
        else if (consumableD) prefab = consumable;
        else if (rangedWeaponD) prefab = rangedWeapon;
        else if (toolD) prefab = tool;
        //else if (wearableD) prefab = wearable;

        Item result = Instantiate(prefab, transform);
        result.Initialize(itemData);
        return result;
    }
}
