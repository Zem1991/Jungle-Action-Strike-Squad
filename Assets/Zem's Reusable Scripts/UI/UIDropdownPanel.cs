using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIDropdownPanel<Source, UIObject> : UIPanel where UIObject : MonoBehaviour
{
    [Header("UIDropdownPanel Runtime")]
    [SerializeField] private List<UIObject> contentList;
    public List<UIObject> ContentList { get => contentList; protected set => contentList = value; }

    public void CloseDropdown()
    {
        ClearDropdown();
    }

    public void OpenDropdown()
    {
        List<Source> sourceList = GetSourceList();
        CreateDropdown(sourceList);
    }

    protected void ClearDropdown()
    {
        foreach (UIObject item in ContentList)
        {
            Destroy(item.gameObject);
        }
        ContentList = new List<UIObject>();
    }
    
    protected void CreateDropdown(List<Source> sourceList)
    {
        ClearDropdown();
        foreach (Source item in sourceList)
        {
            UIObject newObject = InitializeUIObject(item);
            ContentList.Add(newObject);
        }
    }
    
    protected abstract List<Source> GetSourceList();
    protected abstract UIObject InitializeUIObject(Source source);
}
