using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    public void NewTurn()
    {
        Debug.Log($"NewTurn() for {CharacterData.Name}");
        ActionPoints.MakeFull();
    }
}
