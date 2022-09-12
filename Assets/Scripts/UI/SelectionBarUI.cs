using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBarUI : UIPanel
{
    //[Header("SelectionBarUI Awake")]
    //[SerializeField] private CharacterButtonUI characterButton;

    protected override void Awake()
    {
        base.Awake();
        //characterButton = GetComponentInChildren<CharacterButtonUI>();
    }

    public override void Refresh()
    {
        throw new System.NotImplementedException();
    }

    public void Refresh(Character character)
    {
        ChangeBackgroundColor(character);
    }
}
