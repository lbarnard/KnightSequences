using System;
using System.Diagnostics;
using KnightSeqences.Fixtures;
using KnightSequences.Library;

namespace ConsoleOut
{
    class Program
    {
        static void Main()
        {
            var keyPad = new KeyPad(KeyPadHelper.Build());
            var factory = new WalkerFactory();

            var walkCoordinator = new WalkCoordinator(keyPad, factory);
            int depth = 16;
            int vowels = 2;
            Console.WriteLine("Calculating number of paths for {0} key-presses and {1} max vowels", depth, vowels);
            var watch = Stopwatch.StartNew();
            Console.WriteLine(walkCoordinator.Walk(depth, vowels));
            watch.Stop();
            Console.WriteLine("Elapsed time: " + watch.Elapsed.TotalSeconds);
            Console.ReadKey();
        }
    }
}
