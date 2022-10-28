using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class HighlightController : AbstractSingleton<HighlightController>
{
    [Header("Prefabs")]
    [SerializeField] private CharacterHighlight characterPrefab;

    [Header("Resources")]
    [SerializeField] private Sprite moveAreaSprite;
    public Sprite MoveAreaSprite { get => moveAreaSprite; private set => moveAreaSprite = value; }

    [Header("Awake")]
    [SerializeField] private CursorTileHighlight cursorTile;
    [SerializeField] private SelectionTileHighlight selectionTile;
    [SerializeField] private TargetTileHighlight targetTile;
    [SerializeField] private MoveAreaHighlight moveArea;
    [SerializeField] private MovePathHighlight movePath;
    [SerializeField] private FullAimHighlight fullAim;
    [SerializeField] private EffectiveAimHighlight effectiveAim;

    [Header("Runtime")]
    [SerializeField] private bool usingAlternatives;
    [SerializeField] private List<CharacterHighlight> characterList;

    protected override void Awake()
    {
        base.Awake();
        cursorTile = GetComponentInChildren<CursorTileHighlight>();
        selectionTile = GetComponentInChildren<SelectionTileHighlight>();
        targetTile = GetComponentInChildren<TargetTileHighlight>();
        moveArea = GetComponentInChildren<MoveAreaHighlight>();
        movePath = GetComponentInChildren<MovePathHighlight>();
        fullAim = GetComponentInChildren<FullAimHighlight>();
        effectiveAim = GetComponentInChildren<EffectiveAimHighlight>();
    }

    private void Start()
    {
        CursorController.Instance.AddOnTileChangeAction(CreateCharacterHighlights);
    }

    private void LateUpdate()
    {
        cursorTile.Refresh();
        selectionTile.Refresh();
        targetTile.Refresh();
        moveArea.Refresh();
        movePath.Refresh();
        fullAim.Refresh();
        effectiveAim.Refresh();

        foreach (CharacterHighlight character in characterList)
        {
            character.Refresh();
        }
    }

    public void ToggleAlternatives(bool toggle)
    {
        if (usingAlternatives == toggle) return;
        usingAlternatives = toggle;
        CreateCharacterHighlights();
    }
}
