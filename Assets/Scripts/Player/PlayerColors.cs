using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerColors
{
    public static readonly Color localPLayer = Color.blue;
    public static readonly Color enemyPLayer = Color.red;
    
    public static Color GetPanelBackground(PlayerType playerType)
    {
        Color result = localPLayer;
        if (playerType == PlayerType.ENEMY) result = Color.red;
        result.a = 0.5F;
        return result;
    }
}
