using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraUI : UIPanel
{
    [SerializeField] private Text text;

    public override void Refresh()
    {
        string refreshText = CameraController.Instance.ReadForUI();
        if (refreshText == null)
        {
            Hide();
        }
        else
        {
            text.text = $"Camera: {refreshText}";
            Show();
        }
    }
}
