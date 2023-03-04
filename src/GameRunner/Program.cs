using GameRunner;
using System.Diagnostics;

var watch = new Stopwatch();
watch.Start();

Console.WriteLine(new Game().Run(@"TestData\map_4_1_10kx10k.txt"));
//Console.WriteLine(new Game().Run(@"TestData\map_example_1.txt"));
//Console.WriteLine(new Game().Run(@"TestData\map_example_2.txt"));

Console.WriteLine($"Total: {watch.Elapsed}");
Console.ReadLine();
