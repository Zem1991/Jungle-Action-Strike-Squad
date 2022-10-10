using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ListUtils
{
    public static bool CompareLists<T>(List<T> list1, List<T> list2)
    {
        List<T> firstNotSecond = list1.Except(list2).ToList();
        List<T> secondNotFirst = list2.Except(list1).ToList();
        return !firstNotSecond.Any() && !secondNotFirst.Any();
    }
}
