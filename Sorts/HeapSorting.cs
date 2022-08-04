namespace Sorts;

public static class HeapSorting
{
    public static TSource[] HeapSort<TSource, TKey>(
        this TSource[] array,
        Func<TSource, TKey> key)
        where TKey : IComparable<TKey>
    {
        BuildMaxHeap(array, key);
        var heapSize = array.Length - 1;

        for (var i = array.Length - 1; i >= 0; i--)
        {
            (array[0], array[i]) = (array[i], array[0]);
            heapSize -= 1;
            MaxHeapify(array, key, 0, heapSize);
        }

        return array;
    }

    private static void BuildMaxHeap<TSource, TKey>(
        TSource[] array,
        Func<TSource, TKey> key)
        where TKey : IComparable<TKey>
    {
        var heapSize = array.Length - 1;

        for (var i = array.Length / 2 - 1; i >= 0; i--)
        {
            MaxHeapify(array, key, i, heapSize);
        }
    }

    private static void MaxHeapify<TSource, TKey>(
        TSource[] array,
        Func<TSource, TKey> key,
        int index,
        int heapSize)
        where TKey : IComparable<TKey>
    {
        var leftIndex = index * 2 + 1;
        var rightIndex = leftIndex + 1;

        var largestIndex = leftIndex <= heapSize && key(array[leftIndex]).CompareTo(key(array[index])) > 0
            ? leftIndex
            : index;

        if (rightIndex <= heapSize && key(array[rightIndex]).CompareTo(key(array[largestIndex])) > 0)
        {
            largestIndex = rightIndex;
        }

        if (largestIndex != index)
        {
            (array[largestIndex], array[index]) = (array[index], array[largestIndex]);
            MaxHeapify(array, key, largestIndex, heapSize);
        }
    }
}