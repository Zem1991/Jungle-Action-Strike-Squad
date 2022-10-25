using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [Header("Item Initialization")]
    [SerializeField] protected ItemData itemData;
    [SerializeField] protected Resource stack;
    public ItemData ItemData { get => itemData; private set => itemData = value; }
    public Resource Stack { get => stack; protected set => stack = value; }
    
    public void Initialize(ItemData itemData)
    {
        ItemData = itemData;
        Stack = new(itemData.StackStart, itemData.StackLimit);
    }

    public abstract void AfterUse();
}
