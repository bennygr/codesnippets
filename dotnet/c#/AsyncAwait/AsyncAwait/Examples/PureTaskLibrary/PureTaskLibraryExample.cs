using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Examples.PureTaskLibrary
{
    internal class PureTaskLibraryExample : IAsyncAwaitExample
    {
        #region IAsyncAwaitExample

        public string Name
        {
            get { return "Pure Task Library"; }
        }

        public void Run()
        {
            Console.WriteLine(
                " \".\" will be written from the worker thread while a \"|\" is written from the main thread");
            Task t = new Task(SomeVerryLongTask);
            t.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.Write("|");
                Thread.Sleep(500);
            }

            Console.WriteLine("Waiting for the Task to finish");
            t.Wait();
            Console.WriteLine(":-)");
        }

        #endregion


        public void SomeVerryLongTask()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(".");
                Thread.Sleep(7);
            }
        }
    }
}