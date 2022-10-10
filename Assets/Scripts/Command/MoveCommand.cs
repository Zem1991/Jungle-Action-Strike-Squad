using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    public new MoveCommandData CommandData { get => commandData as MoveCommandData; }

    public void Initialize(MoveCommandData commandData)
    {
        base.Initialize(commandData);
    }

    [Header("MoveCommand")]
    private PathfindingNode node;
    private Vector3 position;
    private Vector3 direction;
    private Vector3 finalDirection;

    protected override void StartExecution(Character actor, LevelTile slot, List<PathfindingNode> path, Action onStart, Action onFinish)
    {
        position = actor.GetPosition();
        direction = actor.GetDirection();
        finalDirection = direction;

        int pathCount = path.Count;
        if (pathCount > 1)
        {
            Vector3 finalPos = path[pathCount - 1].WorldPosition;
            Vector3 startPos = path[pathCount - 2].WorldPosition;
            finalDirection = (finalPos - startPos).normalized;
        }

        base.StartExecution(actor, slot, path, onStart, onFinish);
    }

    public override void UpdateExecution()
    {
        //LevelGrid levelGrid = LevelController.Instance.LevelGrid;
        Transform actorTransform = Actor.transform;

        if (PathCompleted())
        {
            MovementEnd();
            return;
        }

        if (!NextNode())
        {
            MovementInterrupted();
            return;
        }

        position = node.WorldPosition;
        direction = (position - actorTransform.position).normalized;

        float dot = Vector3.Dot(actorTransform.forward, direction);
        if (dot < 0)
        {
            if (dot <= -1)
            {
                //Rotation bug that happens when moving backwards.
                //To "fix" it we add some slight rotation to force real rotation.
                actorTransform.eulerAngles += new Vector3(0, 5F, 0);
            }

            //Rotate in place until at least sideways to the next position.
            Actor.RotateAt(direction);
            return;
        }

        Actor.MoveAt(direction);
        Actor.RotateAt(direction);

        //float reachedDistance = direction.magnitude * deltaTime;
        float brakingDistance = 0.1F;
        if (Vector3.Distance(actorTransform.position, position) < brakingDistance)
        {
            Actor.RefreshGridPosition();
            node = null;
        }
    }

    private bool PathCompleted()
    {
        return node == null && Path.Count <= 0;
    }

    private void MovementEnd()
    {
        Actor.MoveTo(position);
        Actor.RotateAt(finalDirection);

        bool positionOk = Actor.GetPosition() == position;
        bool directionOk = Actor.GetDirection() == finalDirection;

        if (positionOk && directionOk)
        {
            //actorTransform.position = position;
            //actorTransform.forward = finalDirection;
            FinishExecution();
        }
    }

    private void MovementInterrupted()
    {
        Actor.MoveTo(position);
        Actor.RotateAt(direction);

        bool positionOk = Actor.GetPosition() == position;
        bool directionOk = Actor.GetDirection() == direction;

        if (positionOk && directionOk)
        {
            //actorTransform.position = position;
            //actorTransform.forward = direction;
            FinishExecution();
        }
    }

    private bool NextNode()
    {
        if (node != null) return true;

        //TODO: Try changing Path to a Queue<PathNode>. Yes, AGAIN.
        PathfindingNode next = Path[0];
        Path.RemoveAt(0);

        int cost = next.WalkingCost;
        if (Actor.ActionPoints.CheckEnough(cost))
        {
            node = next;
            Actor.SpendActionPoints(cost);
            return true;
        }
        else
        {
            return false;
        }
    }
}
