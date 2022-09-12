using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DiceRoll
{
    [SerializeField][Min(1)] private int diceAmount = 1;
    [SerializeField][Min(1)] private int diceSides = 1;
    [SerializeField][Min(0)] private int addedValue = 0;

    public int Roll()
    {
        int result = 0;
        for (int i = 0; i < diceAmount; i++)
        {
            result += Random.Range(0, diceSides) + 1;
        }
        result += addedValue;
        return result;
    }
}
