using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Percent
{
    [SerializeField][Range(0, 100)] private int current = 1;
    public int Current { get => current; private set => current = value; }

    //public static int operator +(Percent p) => p.Current;

    public Percent(int current)
    {
        Current = current;
    }

    public override string ToString()
    {
        return $"{Current}%";
    }
}
