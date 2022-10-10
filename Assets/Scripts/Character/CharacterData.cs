using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterData : ScriptableObject
{
    [Header("CharacterData Identification")]
    [SerializeField] private Sprite sprite;
    [SerializeField] private new string name;
    public Sprite Sprite { get => sprite; private set => sprite = value; }
    public string Name { get => name; private set => name = value; }

    [Header("CharacterData Stats")]
    [SerializeField] private int healthPointsStart = 50;
    [SerializeField] private int actionPointsStart = 30;
    public int HealthPointsStart { get => healthPointsStart; private set => healthPointsStart = value; }
    public int ActionPointsStart { get => actionPointsStart; private set => actionPointsStart = value; }

    [Header("CharacterData Skills")]
    [SerializeField] private int rangedCombat = 50;
    [SerializeField] private int bruteForce = 50;
    [SerializeField] private int explosives = 50;
    [SerializeField] private int survival = 50;
    [SerializeField] private int paramedicine = 50;
    [SerializeField] private int mechanics = 50;
    [SerializeField] private int computers = 50;
    [SerializeField] private int leadership = 50;
    public int RangedCombat { get => rangedCombat; private set => rangedCombat = value; }
    public int BruteForce { get => bruteForce; private set => bruteForce = value; }
    public int Explosives { get => explosives; private set => explosives = value; }
    public int Survival { get => survival; private set => survival = value; }
    public int Paramedicine { get => paramedicine; private set => paramedicine = value; }
    public int Mechanics { get => mechanics; private set => mechanics = value; }
    public int Computers { get => computers; private set => computers = value; }
    public int Leadership { get => leadership; private set => leadership = value; }

    [Header("CharacterData Inventory")]
    [SerializeField] private ItemData mainItem;
    [SerializeField] private ItemData sidearm;
    [SerializeField] private ItemData headWearable;
    [SerializeField] private ItemData torsoWearable;
    [SerializeField] private ItemData backpack1;
    [SerializeField] private ItemData backpack2;
    [SerializeField] private ItemData backpack3;
    [SerializeField] private ItemData backpack4;
    public ItemData MainItem { get => mainItem; private set => mainItem = value; }
    public ItemData Sidearm { get => sidearm; private set => sidearm = value; }
    public ItemData HeadWearable { get => headWearable; private set => headWearable = value; }
    public ItemData TorsoWearable { get => torsoWearable; private set => torsoWearable = value; }
    public ItemData Backpack1 { get => backpack1; private set => backpack1 = value; }
    public ItemData Backpack2 { get => backpack2; private set => backpack2 = value; }
    public ItemData Backpack3 { get => backpack3; private set => backpack3 = value; }
    public ItemData Backpack4 { get => backpack4; private set => backpack4 = value; }
}
