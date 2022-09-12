using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CommandButtonUI : UIPanel, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("CommandButtonUI Awake")]
    [SerializeField] private CommandSpriteUI spriteUI;

    [Header("CommandButtonUI Runtime")]
    [SerializeField] private Command command;

    protected override void Awake()
    {
        base.Awake();
        spriteUI = GetComponentInChildren<CommandSpriteUI>();
    }

    public override void Refresh()
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = Vector3.one * 1.2F;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPointerExit(null);
        CommandController.Instance.DirectRequest(command);
    }

    public void Refresh(Command command)
    {
        this.command = command;
        spriteUI.Refresh(command);
        if (command)
            Show();
        else
            Hide();
    }
}
