namespace Sorts;

public static class InsertionSorting
{
    public static T[] InsertionSort<T>(this T[] array) where T : IComparable<T>
    {
        for (var i = 0; i < array.Length; i++)
        {
            for (var j = i; j > 0 && array[j - 1].CompareTo(array[j]) > 0; j--)
            {
                (array[j], array[j - 1]) = (array[j - 1], array[j]);
            }
        }

        return array;
    }
}