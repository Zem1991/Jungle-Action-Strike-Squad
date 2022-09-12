using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Owner")]
    [SerializeField] private Player owner;
    public Player Owner { get => owner; private set => owner = value; }

    public bool ChangeOwner(Player player)
    {
        Owner = player;
        return true;
    }
}
