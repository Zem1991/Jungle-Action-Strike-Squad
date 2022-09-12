using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionTileHighlight : Highlight
{
    public override void Refresh()
    {
        ActionController actionController = ActionController.Instance;
        if (actionController.HasCurrent())
        {
            Hide();
            return;
        }

        SelectionController selectionController = SelectionController.Instance;
        Character selected = selectionController.Get();
        if (selected)
        {
            transform.position = selected.transform.position;
            Show();
        }
        else
        {
            Hide();
        }
    }
}
