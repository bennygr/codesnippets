using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Examples.SimpleAsyncAwait
{
    internal class SimpleAsyncAwait : IAsyncAwaitExample
    {
        private bool wait = true;

        #region IAsyncAwaitExample

        public string Name
        {
            get { return "Simple Async Await"; }
        }

        public void Run()
        {
            Console.WriteLine(
                " \".\" will be written from the worker thread while a \"|\" is written from the main thread");
            //Starts the task and returns
            RunInternal();
            //Doing something else while the task is doing it's hard work
            for (int i = 0; i < 3; i++)
            {
                Console.Write("|");
                Thread.Sleep(1000);
            }

            //Waiting for the task to finish
            Console.WriteLine("Waiting for the Task to finish");
            while (wait)
                Thread.Sleep(1);
        }

        #endregion

        public async void RunInternal()
        {
            Console.WriteLine("Hello World");
            //await is like a return
            await ReadData();
            Console.WriteLine(":-)");
            //Everything after the await keyword is compiled to a callback event handler which 
            //gets executed after the ReadData-Task has been finished
            this.wait = false;
        }

        public Task ReadData()
        {
            Task t = new Task(() =>
                                        {
                                            for (int i = 0; i < 1000; i++)
                                            {
                                                Console.Write(".");
                                                Thread.Sleep(5);
                                            }
                                        });
            t.Start();
            return t;
        }
    }
}