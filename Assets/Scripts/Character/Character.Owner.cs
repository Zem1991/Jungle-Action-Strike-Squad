using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public partial class Character : MonoBehaviour
{
    [Header("Owner")]
    [SerializeField] private Player owner;
    public Player Owner { get => owner; private set => owner = value; }

    public bool ChangeOwner(Player player)
    {
        PlayerType playerType = player.GetPlayerType();
        Color color = PlayerColors.GetPanelBackground(playerType);
        PlayerColorTag playerColorTag = new(color);
        playerColorTag.Apply(gameObject);
        Owner = player;
        return true;
    }
}
