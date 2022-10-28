using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : AbstractSingleton<SelectionController>
{
    //[Header("Runtime")]
    //[SerializeField] private List<Character> selectionList = new List<Character>();
    //public List<Character> SelectionList { get => selectionList; private set => selectionList = value; }

    //private void Update()
    //{
    //    CommandController actionController = CommandController.Instance;
    //    if (actionController.HasCurrent()) return;
    //    //UpdateInput();
    //}

    public void Clear()
    {
        LocalPlayer localPlayer = PlayerController.Instance.Local;
        localPlayer.SetSelection(null);
    }
    
    public Character Get()
    {
        LocalPlayer localPlayer = PlayerController.Instance.Local;
        List<Character> selectionList = localPlayer.SelectionList;
        if (selectionList.Count > 0) return selectionList[0];
        return null;
    }

    public void Set(Character character)
    {
        List<Character> selectionList = new List<Character>();
        if (character) selectionList.Add(character);

        LocalPlayer localPlayer = PlayerController.Instance.Local;
        localPlayer.SetSelection(selectionList);
    }
    
    //public void Cursor()
    //{
    //    CursorSelectionProcessor processor = new CursorSelectionProcessor();
    //    processor.Process();

    //    if (CancelAbilityInstead()) return;

    //    LevelTile levelTile = CursorController.Instance.LevelTile;
    //    Character character = levelTile?.Character;

    //    List<Character> selectionList = new List<Character>();
    //    if (character) selectionList.Add(character);

    //    LocalPlayer localPlayer = PlayerController.Instance.Local;
    //    localPlayer.SetSelection(selectionList);
    //}

    //public void Cycle(bool reverse)
    //{
    //    if (CancelAbilityInstead()) return;

    //    Character selected = Get();
    //    if (!selected) return;

    //    LocalPlayer localPlayer = PlayerController.Instance.Local;
    //    int index = localPlayer.GetIndex(selected);
    //    if (index < 0) return;

    //    int maxValue = localPlayer.CharacterList.Count - 1;
    //    if (reverse) index--;
    //    else index++;

    //    if (index < 0) index = maxValue;
    //    else if (index > maxValue) index = 0;
    //    Shortcut(index);
    //}

    //public void Shortcut(int index)
    //{
    //    if (CancelAbilityInstead()) return;

    //    LocalPlayer localPlayer = PlayerController.Instance.Local;
    //    bool selectionChanged = localPlayer.SetSelection(index);
    //    if (!selectionChanged && localPlayer.HasSelection())
    //    {
    //        CenterCamera();
    //    }
    //}

    private void CenterCamera()
    {
        CameraController cameraController = CameraController.Instance;
        Vector3 position = Get().GetPosition();
        cameraController.Position(position);
    }

    //public bool CanAbility()
    //{
    //    if (!HasSelection()) return false;
    //    Character character = GetSelection();
    //    bool result = PlayerController.Instance.OwnedByLocalPlayer(character);
    //    return result;
    //}
}
