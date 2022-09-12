using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public abstract PlayerType GetPlayerType();

    [SerializeField] private List<Character> characterList = new List<Character>();
    [SerializeField] private List<Character> selectionList = new List<Character>();
    public List<Character> CharacterList { get => characterList; private set => characterList = value; }
    public List<Character> SelectionList { get => selectionList; private set => selectionList = value; }

    public void AddCharacters(List<Character> characterList)
    {
        foreach (Character forCharacter in characterList)
        {
            forCharacter.ChangeOwner(this);
            CharacterList.Add(forCharacter);
        }
        RefreshUI();
    }

    public void NewTurn()
    {
        foreach (Character character in CharacterList)
        {
            character.NewTurn();
        }
    }

    public bool HasSelection()
    {
        return SelectionList.Count > 0;
    }

    public bool SetSelection(List<Character> selectionList)
    {
        if (selectionList == null) selectionList = new List<Character>();
        bool sameList = ListUtils.CompareLists(SelectionList, selectionList);
        if (sameList) return false;
        SelectionList = selectionList;
        RefreshUI();
        return true;
    }

    public bool SetSelection(int index)
    {
        List<Character> selection = new List<Character>();
        if (index >= 0 && CharacterList.Count > index) selection.Add(CharacterList[index]);
        return SetSelection(selection);
    }

    public int GetIndex(Character character)
    {
        int index = CharacterList.IndexOf(character);
        return index;
    }

    protected abstract void RefreshUI();
}
