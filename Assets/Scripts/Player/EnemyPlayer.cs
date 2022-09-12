using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayer : Player
{
    public override PlayerType GetPlayerType() => PlayerType.ENEMY;
    
    protected override void RefreshUI()
    {
        UIController.Instance.RefreshEnemyPlayer(this);
    }
}
