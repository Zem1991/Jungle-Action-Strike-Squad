using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Highlight : MonoBehaviour
{
    [Header("Awake")]
    [SerializeField] protected LineRenderer lineRenderer;
    
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
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

    public abstract void Refresh();
}
