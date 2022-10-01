using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JASS/Item/Wearable")]
public class Wearable : Item
{
    [Header("Wearable")]
    [SerializeField] private bool isHead;
    [SerializeField] private int armorPoints;
    public bool IsHead { get => isHead; private set => isHead = value; }
    public int ArmorPoints { get => armorPoints; private set => armorPoints = value; }
}
