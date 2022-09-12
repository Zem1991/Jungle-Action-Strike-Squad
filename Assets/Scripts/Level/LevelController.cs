using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : AbstractSingleton<LevelController>, IReadableForUI
{
    [Header("Awake")]
    [SerializeField] private LevelMap levelMap;
    public LevelMap LevelMap { get => levelMap; private set => levelMap = value; }
    
    [Header("Setup")]
    [SerializeField] private string levelName = "Unnamed Level";
    public string LevelName { get => levelName; private set => levelName = value; }

    protected override void Awake()
    {
        base.Awake();
        LevelMap = FindObjectOfType<LevelMap>();
    }

    public string ReadForUI()
    {
        return LevelName;
    }

    public LevelGrid GetLevelGrid()
    {
        return LevelMap.TileGrid;
    }
}
