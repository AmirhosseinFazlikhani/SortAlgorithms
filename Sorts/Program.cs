
using System.Diagnostics;
using Sorts;

var arrays = CreateArrays(4);

var watch = Stopwatch.StartNew();
_ = arrays[0].OrderBy(i => i).ToArray();
watch.Stop();
Console.WriteLine($"Linq: {watch.Elapsed}");

watch.Restart();
_ = arrays[1].HeapSort();
watch.Stop();
Console.WriteLine($"Heap: {watch.Elapsed}");

watch.Restart();
_ = arrays[2].ShellSort();
watch.Stop();
Console.WriteLine($"Shell: {watch.Elapsed}");

watch.Restart();
_ = arrays[3].InsertionSort();
watch.Stop();
Console.WriteLine($"Insertion: {watch.Elapsed}");

List<int[]> CreateArrays(int count)
{
    const int length = 100_000;

    var baseArray = GetRandomArray(length);

    return Enumerable.Range(0, count)
        .Select(_ =>
        {
            var array = new int[length];
            Array.Copy(baseArray, array, length);
            return array;
        })
        .ToList();
}

int[] GetRandomArray(int length)
{
    var random = new Random();

    return Enumerable.Range(0, length)
        .Select(_ => random.Next())
        .ToArray();
}