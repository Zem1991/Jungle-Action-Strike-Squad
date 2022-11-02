using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActionPointsBarUI : ResourceBarUI
{
    public void Refresh(Character character)
    {
        if (character) return;
        Refresh(character.ActionPoints);
    }
}
