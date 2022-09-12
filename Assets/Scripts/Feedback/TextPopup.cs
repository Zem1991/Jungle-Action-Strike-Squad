using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPopup : MonoBehaviour
{
    [Header("Manual references")]
    [SerializeField] private TextMeshPro textMesh;

    [Header("Runtime")]
    [SerializeField] private Transform followTarget;

    private void Start()
    {
        Destroy(gameObject, 1F);
    }

    private void LateUpdate()
    {
        Vector3 position = Vector3.up * Time.deltaTime;
        textMesh.rectTransform.Translate(position);
        if (followTarget) transform.position = followTarget.transform.position;
    }

    public void Initialize(string text, Color color, Vector3 scale, Transform followTarget)
    {
        textMesh.SetText(text);
        textMesh.color = color;
        textMesh.rectTransform.localScale = scale;
        this.followTarget = followTarget;
    }
}
