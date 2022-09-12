using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Item : MonoBehaviour
{
    [Header("Tags")]
    [SerializeField] private List<string> itemTags = new List<string>();
    public List<string> ItemTags { get => itemTags; private set => itemTags = value; }
    //TODO: make tags as multi-select enums

    public bool HasTag(string tag)
    {
        return itemTags.Contains(tag);
    }

    public bool AddTag(string tag)
    {
        if (string.IsNullOrEmpty(tag)) return false;
        if (HasTag(tag)) return false;
        itemTags.Add(tag);
        return true;
    }

    public bool RemoveTag(string tag)
    {
        if (string.IsNullOrEmpty(tag)) return false;
        if (!HasTag(tag)) return false;
        itemTags.Remove(tag);
        return true;
    }
}
