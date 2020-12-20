using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class ListExtension
{
    public static void AddIfNotExists<T>(this List<T> list, T value)
    {
        checkListIsNull(list);
        if (!list.Contains(value))
            list.Add(value);
    }

    public static void UpdateValue<T>(this IList<T> list, T value, T newValue)
    {
        checkListAndValueIsNull(list, value);
        checkValueIsNull(newValue);
        var index = list.IndexOf(value);
        list[index] = newValue;
    }

    public static void DeleteIfExists<T>(this IList<T> list, T value)
    {
        checkListAndValueIsNull(list, value);
        if (list.Contains(value))
            list.Remove(value);
    }

    public static bool AreValuesEmpty<T>(this IList<T> list)
    {
        checkListIsNull(list);
        return list.All(x => x == null);
    }

    public static bool IsNullOrEmpty<T>(this IList<T> list)
    {
        return (list == null || list.Count <= 0);
    }

    private static void checkListAndValueIsNull<T>(this IList<T> list, T value)
    {
        checkListIsNull(list);
        checkValueIsNull(value);
    }

    private static void checkValueIsNull<T>(T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
    }

    private static void checkListIsNull<T>(this IList<T> list)
    {
        if (list == null) throw new ArgumentNullException(nameof(list));
    }
}
