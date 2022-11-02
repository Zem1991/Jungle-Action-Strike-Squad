using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JASS Data/Player/Colors")]
public class PlayerColorsData : ScriptableObject
{
    [SerializeField] private Color main = Color.blue;

    public Color GetMain()
    {
        Color result = main;
        result.a = 1F;
        return result;
    }

    public Color GetHighlight()
    {
        Color result = main;
        result.a = 0.5F;
        return result;
    }

    public Color GetUI()
    {
        Color result = main;
        result.a = 0.75F;
        return result;
    }
}
