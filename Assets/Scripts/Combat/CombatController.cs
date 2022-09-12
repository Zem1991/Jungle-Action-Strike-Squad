using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CombatController : AbstractSingleton<CombatController>//, IReadableForUI
{
    [Header("Runtime")]
    [SerializeField] private bool inCombat;
    [SerializeField] private int turnNumber;
    [SerializeField] private PlayerType turnPhase;
    public bool InCombat { get => inCombat; private set => inCombat = value; }
    public int TurnNumber { get => turnNumber; private set => turnNumber = value; }
    public PlayerType TurnPhase { get => turnPhase; private set => turnPhase = value; }

    //public string ReadForUI()
    //{
    //    if (!InCombat) return null;
    //    return $"Turn {TurnNumber} - {TurnPhase} Phase";
    //}

    private void Start()
    {
        StartCombat();
    }

    private void Update()
    {
        UpdateInput();
    }

    public void StartCombat()
    {
        InCombat = true;
        TurnNumber = 1;
        TurnPhase = PlayerType.LOCAL;

        PlayerController playerController = PlayerController.Instance;
        playerController.Local.NewTurn();
        playerController.Enemy.NewTurn();
    }

    public void EndCombat()
    {
        InCombat = false;
        TurnNumber = 0;
        TurnPhase = PlayerType.LOCAL;
    }

    public void EndTurn()
    {
        if (!InCombat) return;

        //TODO: one player can only end its own turn - check it before

        SelectionController.Instance.Clear();
        CommandController.Instance.Clear();

        if (TurnPhase == PlayerType.LOCAL)
        {
            TurnPhase = PlayerType.ENEMY;
            PlayerController.Instance.Enemy.NewTurn();
        }
        else
        {
            TurnNumber++;
            TurnPhase = PlayerType.LOCAL;
            PlayerController.Instance.Local.NewTurn();
        }
    }
}
