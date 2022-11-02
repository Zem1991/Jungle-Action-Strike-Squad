using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : AbstractSingleton<InputController>
{
    [SerializeField] private AbilityInputReader abilityInputReader;
    [SerializeField] private CameraInputReader cameraInputReader;
    [SerializeField] private CombatInputReader combatInputReader;
    [SerializeField] private CursorInputReader cursorInputReader;
    [SerializeField] private HighlightInputReader highlightInputReader;
    [SerializeField] private InventoryInputReader inventoryInputReader;
    [SerializeField] private UIInputReader uiInputReader;
    public AbilityInputReader AbilityInputReader { get => abilityInputReader; private set => abilityInputReader = value; }
    public CameraInputReader CameraInputReader { get => cameraInputReader; private set => cameraInputReader = value; }
    public CombatInputReader CombatInputReader { get => combatInputReader; private set => combatInputReader = value; }
    public CursorInputReader CursorInputReader { get => cursorInputReader; private set => cursorInputReader = value; }
    public HighlightInputReader HighlightInputReader { get => highlightInputReader; private set => highlightInputReader = value; }
    public InventoryInputReader InventoryInputReader { get => inventoryInputReader; private set => inventoryInputReader = value; }
    public UIInputReader UIInputReader { get => uiInputReader; private set => uiInputReader = value; }

    private void Start()
    {
        AbilityInputReader = new();
        CameraInputReader = new();
        CombatInputReader = new();
        CursorInputReader = new();
        HighlightInputReader = new();
        InventoryInputReader = new();
        UIInputReader = new();
    }

    private void Update()
    {
        AnyUpdate();
    }

    private void AnyUpdate()
    {
        Ability();
        Camera();
        Combat();
        if (Cursor()) return;
        Highlight();
        if (Inventory()) return;
        UI();
    }

    private void Ability()
    {
        AbilityInputProcessor processor = new();
        processor.Read(AbilityInputReader);
    }

    private void Camera()
    {
        CommandController actionController = CommandController.Instance;
        if (actionController.HasCurrent()) return;

        CameraInputProcessor processor = new();
        processor.Read(CameraInputReader);
    }

    private void Combat()
    {
        CombatInputProcessor processor = new();
        processor.Read(CombatInputReader);
    }

    private bool Cursor()
    {
        CursorInputProcessor processor = new();
        bool result = processor.Read(CursorInputReader);
        return result;
    }

    private void Highlight()
    {
        HighlightInputProcessor processor = new();
        processor.Read(HighlightInputReader);
    }

    private bool Inventory()
    {
        InventoryInputProcessor processor = new();
        bool result = processor.Read(InventoryInputReader);
        return result;
    }

    private void UI()
    {
        UIInputProcessor processor = new();
        processor.Read(UIInputReader);
    }
}
