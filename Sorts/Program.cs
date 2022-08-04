using System.Diagnostics;
using Sorts;

var arrays = CreateArrays(4);

var watch = new Stopwatch();

Benchmark("Linq", watch, () => _ = arrays[0].OrderBy(i => i).ToArray());
Benchmark("Heap", watch, () => _ = arrays[1].HeapSort(i => i));
Benchmark("Shell", watch, () => _ = arrays[2].ShellSort(i => i));
Benchmark("Insertion", watch, () => _ = arrays[3].InsertionSort(i => i));

void Benchmark(string name, Stopwatch watch, Action action)
{
    watch.Restart();
    action();
    watch.Stop();
    Console.WriteLine($"{name}: {watch.Elapsed}");
}

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