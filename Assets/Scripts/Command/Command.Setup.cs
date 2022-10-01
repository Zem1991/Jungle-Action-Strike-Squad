using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    [Header("Setup: Parameters")]
    [SerializeField] private Character actor;
    [SerializeField] private LevelTile tile;
    [SerializeField] private List<PathfindingNode> path;
    public Character Actor { get => actor; private set => actor = value; }
    public LevelTile Tile { get => tile; private set => tile = value; }
    public List<PathfindingNode> Path { get => path; private set => path = value; }

    [Header("Setup: Actions")]
    [SerializeField] private Action onStart;
    [SerializeField] private Action onFinish;
    private Action OnStart { get => onStart; set => onStart = value; }
    private Action OnFinish { get => onFinish; set => onFinish = value; }

    private void Setup(Character actor, LevelTile slot, List<PathfindingNode> path, Action onStart, Action onFinish)
    {
        Actor = actor;
        Tile = slot;
        Path = path;
        OnStart = onStart;
        OnFinish = onFinish;
    }
}
