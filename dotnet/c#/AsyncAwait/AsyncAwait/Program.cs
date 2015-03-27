using System;
using System.Collections.Generic;
using AsyncAwait.Examples.PureTaskLibrary;
using AsyncAwait.Examples.SimpleAsyncAwait;

namespace AsyncAwait
{
    internal class Program
    {
        //List of examples to run at startup
        private static readonly List<IAsyncAwaitExample> examples = new List<IAsyncAwaitExample>
                                                                    {
                                                                        //Task example
                                                                        new PureTaskLibraryExample(),
                                                                        //Async Await example
                                                                        new SimpleAsyncAwait()
                                                                    };
        

        private static void Main(string[] args)
        {
            Console.WriteLine("-> Executing {0} Async Await examples...",examples.Count);
            Console.WriteLine("-------------------------------");
            foreach (var example in examples)
            {
                Console.WriteLine("-> Runnig Example \"{0}\"", example.Name);
                example.Run();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("-------------------------------");
            }

            Console.WriteLine("->[DONE] All Async Await examples have been executed. Press Return to exit");
            while (Console.ReadKey().Key != ConsoleKey.Enter){ }
        }
    }
}