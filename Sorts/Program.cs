using System.Diagnostics;
using Sorts;

var arrays = CreateArrays(4);

var watch = Stopwatch.StartNew();
_ = arrays[0].OrderBy(i => i).ToArray();
watch.Stop();
Console.WriteLine($"Linq: {watch.Elapsed}");

watch.Restart();
_ = arrays[1].HeapSort(i => i);
watch.Stop();
Console.WriteLine($"Heap: {watch.Elapsed}");

watch.Restart();
_ = arrays[2].ShellSort(i => i);
watch.Stop();
Console.WriteLine($"Shell: {watch.Elapsed}");

watch.Restart();
_ = arrays[3].InsertionSort(i => i);
watch.Stop();
Console.WriteLine($"Insertion: {watch.Elapsed}");

List<int[]> CreateArrays(int count)
{
    const int length = 100_000;

    var baseArray = GetRandomArray(length);

    return Enumerable.Range(0, count)
        .Select(_ => (baseArray.Clone() as int[])!)
        .ToList();
}

int[] GetRandomArray(int length)
{
    var random = new Random();

    return Enumerable.Range(0, length)
        .Select(_ => random.Next())
        .ToArray();
}