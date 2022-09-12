using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayer : Player
{
    public override PlayerType GetPlayerType() => PlayerType.LOCAL;
    
    protected override void RefreshUI()
    {
        UIController.Instance.RefreshLocalPlayer(this);
    }
}
