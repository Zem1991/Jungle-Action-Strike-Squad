using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JASS Data/Command/Reload Command")]
public class ReloadCommandData : CommandData
{
    [Header("ReloadCommandData")]
    [SerializeField] private bool sidearm;
    public bool Sidearm { get => sidearm; private set => sidearm = value; }

    public override bool NeedsPathToTarget()
    {
        return false;
    }
}
