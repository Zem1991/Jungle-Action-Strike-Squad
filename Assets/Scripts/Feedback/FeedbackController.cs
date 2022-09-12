using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class FeedbackController : AbstractSingleton<FeedbackController>
{
    [Header("Prefabs")]
    [SerializeField] private TextPopup textPopupPrefab;

    private void Update()
    {
        if (HasMessage())
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            Timer = 0F;
        }
    }
}
