using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : AbstractSingleton<UIController>
{
    private Canvas canvas;

    [Header("Awake: Main")]
    [SerializeField] private PlayerUI localPlayerUI;
    [SerializeField] private PlayerUI enemyPlayerUI;

    [Header("Awake: Extra")]
    [SerializeField] private SelectionUI selectionUI;
    [SerializeField] private AbilityUI abilityUI;
    [SerializeField] private ActionUI actionUI;
    [SerializeField] private FeedbackUI feedbackUI;
    [SerializeField] private CombatUI combatUI;
    
    [Header("Awake: Window")]
    [SerializeField] private InventoryUI inventoryUI;

    [Header("Awake: Debug")]
    [SerializeField] private CameraUI cameraUI;
    [SerializeField] private CursorUI cursorUI;
    [SerializeField] private LevelUI levelUI;

    [Header("Runtime")]
    [SerializeField] private bool hidingAll;
    [SerializeField] private bool usingAlternatives;
    public bool HidingAll { get => hidingAll; set => hidingAll = value; }
    public bool UsingAlternatives { get => usingAlternatives; set => usingAlternatives = value; }

    protected override void Awake()
    {
        base.Awake();

        canvas = GetComponent<Canvas>();

        PlayerUI[] playerUIs = GetComponentsInChildren<PlayerUI>();
        localPlayerUI = playerUIs[0];
        enemyPlayerUI = playerUIs[1];

        combatUI = GetComponentInChildren<CombatUI>();
        selectionUI = GetComponentInChildren<SelectionUI>();
        abilityUI = GetComponentInChildren<AbilityUI>();
        actionUI = GetComponentInChildren<ActionUI>();
        feedbackUI = GetComponentInChildren<FeedbackUI>();

        inventoryUI = GetComponentInChildren<InventoryUI>();

        cameraUI = GetComponentInChildren<CameraUI>();
        cursorUI = GetComponentInChildren<CursorUI>();
        levelUI = GetComponentInChildren<LevelUI>();
    }

    private void LateUpdate()
    {
        canvas.gameObject.SetActive(!HidingAll);

        combatUI.Refresh();
        selectionUI.Refresh();
        abilityUI.Refresh();
        actionUI.Refresh();
        feedbackUI.Refresh();

        inventoryUI.Refresh();

        cameraUI.Refresh();
        cursorUI.Refresh();
        levelUI.Refresh();
    }

    public void RefreshLocalPlayer(LocalPlayer player)
    {
        localPlayerUI.Refresh(player);
    }

    public void RefreshEnemyPlayer(EnemyPlayer player)
    {
        enemyPlayerUI.Refresh(player);
    }
}
