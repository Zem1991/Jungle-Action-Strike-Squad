using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : UIPanel
{
    [Header("Prefabs")]
    [SerializeField] private CharacterButtonUI characterButtonPrefab;

    [Header("Scene")]
    [SerializeField] private RectTransform characterHolder;

    [Header("Runtime")]
    [SerializeField] private List<CharacterButtonUI> characterList = new List<CharacterButtonUI>();

    public override void Refresh()
    {
        throw new System.NotImplementedException();
    }

    public void Refresh(Player player)
    {
        PlayerType playerType = player.GetPlayerType();
        ChangeBackgroundColor(playerType);

        Clear();
        List<Character> characterList = player.CharacterList;
        List<Character> selectionList = player.SelectionList;
        foreach (Character character in characterList)
        {
            CharacterButtonUI characterButton = Instantiate(characterButtonPrefab, characterHolder);
            this.characterList.Add(characterButton);
            bool isSelected = selectionList.Contains(character);
            characterButton.Initialize(character, isSelected);
        }
    }

    private void Clear()
    {
        foreach (CharacterButtonUI characterButton in characterList)
        {
            characterButton.Dispose();
            Destroy(characterButton.gameObject);
        }
        characterList.Clear();
    }
}
