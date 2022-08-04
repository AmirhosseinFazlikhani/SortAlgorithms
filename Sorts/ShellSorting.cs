namespace Sorts;

public static class ShellSorting
{
    public static TSource[] ShellSort<TSource, TKey>(
        this TSource[] array,
        Func<TSource, TKey> key)
        where TKey : IComparable<TKey>
    {
        var h = 1;

        while (h < array.Length / 3)
        {
            h = h * 3 + 1;
        }

        while (h >= 1)
        {
            for (var i = h; i < array.Length; i++)
            {
                for (var j = i; j >= h && key(array[j]).CompareTo(key(array[j - h])) < 0; j -= h)
                {
                    (array[j], array[j - h]) = (array[j - h], array[j]);
                }
            }

            h /= 3;
        }

        return array;
    }
}