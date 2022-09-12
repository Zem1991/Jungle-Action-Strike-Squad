using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommandHelper
{
    public static Command FromContext(Character actor, LevelTile targetSlot, out List<PathfindingNode> path)
    {
        PlayerController playerController = PlayerController.Instance;
        Character target = targetSlot.Character;
        bool characterFromPlayer = playerController.OwnedByLocalPlayer(target);
        bool characterFromEnemy = playerController.OwnedByEnemyPlayer(target);
        bool isReachable = actor.Pathfind(targetSlot, out path);

        if (characterFromPlayer) return CommandPrefabs.Instance.Spin;
        if (characterFromEnemy) return CommandPrefabs.Instance.Attack;
        if (isReachable) return CommandPrefabs.Instance.Move;
        return CommandPrefabs.Instance.Spin;
    }

    //public static Command FromGrabber(Character actor, int index)
    //{
    //    Command result = actor.Commands.Get(index);
    //    return result;
    //}

    //public static Command FromWheel(Character actor, int index)
    //{
    //    Command result = actor.CommandWheel.Commands[index];
    //    return result;
    //}
}
