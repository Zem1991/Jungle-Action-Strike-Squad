using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Resource
{
    private Action OnChange;

    [SerializeField][Min(0)] private int current = 1;
    [SerializeField][Min(1)] private int maximum = 1;
    public int Current
    {
        get => current;
        private set
        {
            current = value;
            if (OnChange != null) OnChange();
        }
    }
    public int Maximum { get => maximum; private set => maximum = value; }

    public Resource(int maximum)
    {
        Current = maximum;
        Maximum = maximum;
    }

    public Resource(int current, int maximum)
    {
        Current = current;
        Maximum = maximum;
    }

    public void MakeFull()
    {
        Add(Maximum);
    }

    public void MakeEmpty()
    {
        Subtract(Maximum, false);
    }

    //public bool Set(int amount)
    //{
    //    Current = Mathf.Clamp(amount, 0, Maximum);
    //    return true;
    //}

    public bool Add(int amount)
    {
        if (amount <= 0) return false;
        if (CheckFull()) return false;
        Current = Mathf.Clamp(Current + amount, 0, Maximum);
        return true;
    }
    
    public bool Subtract(int amount, bool mustHaveEnough = true)
    {
        if (amount <= 0) return false;
        if (CheckEmpty()) return false;
        if (mustHaveEnough && !CheckEnough(amount)) return false;
        Current = Mathf.Clamp(Current - amount, 0, Maximum);
        return true;
    }

    public float GetFillAmount()
    {
        return Current / Maximum;
    }

    public string GetTextAmount()
    {
        return $"{Current} / {Maximum}";
    }

    public float PercentToAmount(int percent)
    {
        float result = Maximum / 100F * percent;
        return result;
    }

    public int PercentToAmountCeil(int percent)
    {
        float amount = PercentToAmount(percent);
        int result = Mathf.CeilToInt(amount);
        return result;
    }

    public bool CheckEnough(int amount)
    {
        return Current >= amount;
    }

    public bool CheckFull()
    {
        return Current >= Maximum;
    }

    public bool CheckEmpty()
    {
        return Current <= 0;
    }

    public void AddOnChangeAction(Action action)
    {
        OnChange += action;
        Debug.Log("AddOnChangeAction count = " + OnChange.GetInvocationList().Length);
    }

    public void RemoveOnChangeAction(Action action)
    {
        OnChange -= action;
        if (OnChange == null) Debug.Log("OnChange.GetInvocationList() = null");
        else Debug.Log("RemoveOnChangeAction count = " + OnChange.GetInvocationList().Length);
    }
}
