using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Identification")]
    [SerializeField] private Sprite characterSprite;
    [SerializeField] private string characterName = "Character Name";
    public Sprite CharacterSprite { get => characterSprite; private set => characterSprite = value; }
    public string CharacterName { get => characterName; private set => characterName = value; }
}
