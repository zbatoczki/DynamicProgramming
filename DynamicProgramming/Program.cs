using DynamicProgramming;
using System.Diagnostics;

Stopwatch sw = Stopwatch.StartNew();
Summing.RunBestSum();
sw.Stop();
Console.WriteLine($"Elapsed Time: {sw.ElapsedMilliseconds} ms");



