using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNameUI : TextUI<Character>
{
    protected override string GetText(Character thing)
    {
        return thing.CharacterData.Name;
    }
}
