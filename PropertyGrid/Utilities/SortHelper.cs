using System;
using System.Collections.Generic;

namespace AvaloniaBasic.Utilities;

public static class SortHelper
{
    public static Comparison<TU?> SortAscending<T, TU>(Func<TU, T> selector)
    {
        return (x, y) =>
        {
            if (x is null && y is null)
            {
                return 0;
            }
            else if (x is null)
            {
                return -1;
            }
            else if (y is null)
            {
                return 1;
            }
            else
            {
                return Comparer<T>.Default.Compare(selector(x), selector(y));
            }
        };
    }

    public static Comparison<TU?> SortDescending<T, TU>(Func<TU, T> selector)
    {
        return (x, y) =>
        {
            if (x is null && y is null)
            {
                return 0;
            }
            else if (x is null)
            {
                return 1;
            }
            else if (y is null)
            {
                return -1;
            }
            else
            {
                return Comparer<T>.Default.Compare(selector(y), selector(x));
            }
        };
    }
}
