using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBasicsUI : UIPanel
{
    [Header("PlayerUI Awake")]
    [SerializeField] private GridLayoutGroup characterHolder;

    [Header("PlayerUI Runtime")]
    [SerializeField] private List<PlayerCharacterUI> characterList = new List<PlayerCharacterUI>();

    protected override void Awake()
    {
        base.Awake();

        characterHolder = GetComponentInChildren<GridLayoutGroup>();
    }

    public override void Refresh()
    {
        throw new System.NotImplementedException();
    }

    public void Refresh(Player player)
    {
        Color color = player.PlayerColorsData.GetUI();
        ChangeBackgroundColor(color);

        Clear();
        List<Character> characterList = player.CharacterList;
        //List<Character> selectionList = player.SelectionList;
        foreach (Character character in characterList)
        {
            PlayerCharacterUI pcui = UIPrefabs.Instance.Instantiate(character, characterHolder.transform);
            this.characterList.Add(pcui);
            //bool isSelected = selectionList.Contains(character);
            //pcui.Initialize(character, isSelected);
        }
    }

    private void Clear()
    {
        foreach (PlayerCharacterUI characterButton in characterList)
        {
            characterButton.Dispose();
            Destroy(characterButton.gameObject);
        }
        characterList.Clear();
    }
}
