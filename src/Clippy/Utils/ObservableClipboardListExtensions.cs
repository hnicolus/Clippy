using System;
using System.Collections.Generic;
using Clippy.Models;

namespace Clippy.ViewModels;

public static class ObservableClipboardListExtensions
{
    public static void Sort<T>(this ObservableClipboardList<T> collection, Comparison<T> comparison)
    {
        var sortableList = new List<T>(collection);
        sortableList.Sort(comparison);

        for (int i = 0; i < sortableList.Count; i++)
        {
            collection.Move(collection.IndexOf(sortableList[i]), i);
        }
    }
}
