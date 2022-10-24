using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacter : Character
{
    public new HeroCharacterData CharacterData { get => characterData as HeroCharacterData; }

    public void Initialize(HeroCharacterData characterData)
    {
        base.Initialize(characterData);
    }
}
