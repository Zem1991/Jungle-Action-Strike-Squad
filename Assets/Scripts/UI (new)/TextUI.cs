using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TextUI<T> : MonoBehaviour
{
    [Header("TextUI Awake")]
    [SerializeField] private Text text;

    private void Awake()
    {
        List<Text> texts = new List<Text>(GetComponentsInChildren<Text>());
        text = texts[0];
    }

    public void Refresh(T thing)
    {
        if (thing != null)
        {
            text.text = GetText(thing);
        }
        else
        {
            text.text = null;
        }
    }

    protected abstract string GetText(T thing);
}
