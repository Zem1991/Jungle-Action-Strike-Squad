using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthPointsBarUI : ResourceBarUI
{
    public void Refresh(Character character)
    {
        if (!character) return;
        Refresh(character.HealthPoints);
    }
}
