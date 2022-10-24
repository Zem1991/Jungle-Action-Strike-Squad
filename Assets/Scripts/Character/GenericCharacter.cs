using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericCharacter : Character
{
    public new GenericCharacterData CharacterData { get => characterData as GenericCharacterData; }

    public void Initialize(GenericCharacterData characterData)
    {
        base.Initialize(characterData);
    }
}
