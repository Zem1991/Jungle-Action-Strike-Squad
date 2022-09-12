using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AbstractSingleton<PlayerController>//, IReadableForUI
{
    [Header("Awake")]
    [SerializeField] private LocalPlayer local;
    [SerializeField] private EnemyPlayer enemy;
    public LocalPlayer Local { get => local; private set => local = value; }
    public EnemyPlayer Enemy { get => enemy; private set => enemy = value; }

    protected override void Awake()
    {
        base.Awake();
        Local = GetComponentInChildren<LocalPlayer>();
        Enemy = GetComponentInChildren<EnemyPlayer>();
    }

    public bool OwnedByLocalPlayer(Character character)
    {
        if (!character) return false;
        return Local && Local == character.Owner;
    }

    public bool OwnedByEnemyPlayer(Character character)
    {
        if (!character) return false;
        return Enemy && Enemy == character.Owner;
    }
}
