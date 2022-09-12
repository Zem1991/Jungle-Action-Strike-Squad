using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class FeedbackController : AbstractSingleton<FeedbackController>
{
    public TextPopup CreateDamagePopup(Vector3 position, int amount, Transform followTarget)
    {
        TextPopup result = CreateTextPopup(position);
        float size = Mathf.Clamp(amount / 20F, 1F, 5F);
        Vector3 scale = Vector3.one * size;
        result.Initialize(amount.ToString(), Color.red, scale, followTarget);
        return result;
    }

    public TextPopup CreateHealingPopup(Vector3 position, int amount, Transform followTarget)
    {
        TextPopup result = CreateTextPopup(position);
        result.Initialize(amount.ToString(), Color.green, Vector3.one, followTarget);
        return result;
    }

    private TextPopup CreateTextPopup(Vector3 position)
    {
        return Instantiate(textPopupPrefab, position, Quaternion.identity);
    }
}
