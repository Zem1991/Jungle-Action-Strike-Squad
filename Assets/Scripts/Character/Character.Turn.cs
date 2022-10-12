using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Character : MonoBehaviour
{
    public void NewTurn()
    {
        Debug.Log($"NewTurn() for {CharacterData.Name}");
        ActionPoints.MakeFull();
    }
}
