using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Item : MonoBehaviour
{
    [Header("Identification")]
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private string itemName;
    public Sprite ItemSprite { get => itemSprite; private set => itemSprite = value; }
    public string ItemName { get => itemName; private set => itemName = value; }
}
