using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract partial class Character : MonoBehaviour
{
    [Header("Owner")]
    [SerializeField] private Player owner;
    public Player Owner { get => owner; private set => owner = value; }

    public bool ChangeOwner(Player player)
    {
        Color color = player.PlayerColorsData.GetUI();
        PlayerColorTag playerColorTag = new(color);
        playerColorTag.Apply(gameObject);
        Owner = player;
        return true;
    }
}
