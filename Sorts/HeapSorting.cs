namespace Sorts;

public static class HeapSorting
{
    public static T[] HeapSort<T>(this T[] array) where T : IComparable<T>
    {
        BuildMaxHeap(array);
        var heapSize = array.Length - 1;

        for (var i = array.Length - 1; i >= 0; i--)
        {
            (array[0], array[i]) = (array[i], array[0]);
            heapSize -= 1;
            MaxHeapify(array, 0, heapSize);
        }

        return array;
    }

    private static void BuildMaxHeap<T>(T[] array) where T : IComparable<T>
    {
        var heapSize = array.Length - 1;
        
        for (var i = array.Length / 2 - 1; i >= 0; i--)
        {
            MaxHeapify(array, i, heapSize);
        }
    }

    private static void MaxHeapify<T>(T[] array, int index, int heapSize) where T : IComparable<T>
    {
        var leftIndex = index * 2 + 1;
        var rightIndex = leftIndex + 1;

        var largestIndex = leftIndex <= heapSize && array[leftIndex].CompareTo(array[index]) > 0 ? leftIndex : index;

        if (rightIndex <= heapSize && array[rightIndex].CompareTo(array[largestIndex]) > 0)
        {
            largestIndex = rightIndex;
        }

        if (largestIndex != index)
        {
            (array[largestIndex], array[index]) = (array[index], array[largestIndex]);
            MaxHeapify(array, largestIndex, heapSize);
        }
    }
}