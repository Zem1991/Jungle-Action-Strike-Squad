using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIPanel : MonoBehaviour
{
    [Header("UIPanel Awake")]
    [SerializeField] protected Image background;

    protected virtual void Awake()
    {
        background = GetComponent<Image>();
    }

    protected void Hide()
    {
        gameObject.SetActive(false);
    }

    protected void Show()
    {
        gameObject.SetActive(true);
    }

    //public bool Toggle()
    //{
    //    bool result = !gameObject.activeSelf;
    //    gameObject.SetActive(result);
    //    return result;
    //}

    //public void ChangeBackgroundColor(Character character)
    //{
    //    if (!character) return;
    //    PlayerType playerType = character.Owner.GetPlayerType();
    //    ChangeBackgroundColor(playerType);
    //}

    //public void ChangeBackgroundColor(PlayerType playerType)
    //{
    //    Color color = PlayerColors.GetPanelBackground(playerType);
    //    ChangeBackgroundColor(color);
    //}

    protected void ChangeBackgroundColor(Color color)
    {
        if (!background) return;
        background.color = color;
    }

    public abstract void Refresh();
}
