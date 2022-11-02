using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class FillBarUI<T> : MonoBehaviour
{
    [Header("FillBarUI Awake")]
    [SerializeField] private Image barBack;
    [SerializeField] private Image barFront;
    [SerializeField] private Text text;

    private void Awake()
    {
        List<Image> sprites = new List<Image>(GetComponentsInChildren<Image>());
        barBack = sprites[0];
        barFront = sprites[1];

        List<Text> texts = new List<Text>(GetComponentsInChildren<Text>());
        text = texts[0];
    }

    public void Refresh(T thing)
    {
        if (thing != null)
        {
            barBack.enabled = true;
            barFront.enabled = true;
            barFront.fillAmount = GetFillAmount(thing);
            text.text = GetTextAmount(thing);
        }
        else
        {
            barBack.enabled = false;
            barFront.enabled = false;
            barFront.sprite = null;
            text.text = null;
        }
    }

    protected abstract float GetFillAmount(T thing);
    protected abstract string GetTextAmount(T thing);
}
