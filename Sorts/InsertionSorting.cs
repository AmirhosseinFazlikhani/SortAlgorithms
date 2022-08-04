namespace Sorts;

public static class InsertionSorting
{
    public static TSource[] InsertionSort<TSource, TKey>(
        this TSource[] array,
        Func<TSource, TKey> key)
        where TKey : IComparable<TKey>
    {
        for (var i = 0; i < array.Length; i++)
        {
            for (var j = i; j > 0 && key(array[j - 1]).CompareTo(key(array[j])) > 0; j--)
            {
                (array[j], array[j - 1]) = (array[j - 1], array[j]);
            }
        }

        return array;
    }
}