using System;
using System.Threading;
using System.Threading.Tasks;


/*Threading in C# follows a similar design pattern to that of in C++.

The basics are the same: we can spawn threads, assign them a method to run, and use synchronization primitives like mutexes to control which threads are running and when.*/
namespace ComplexGameSystemsCS
{
    class Program
    {
        //create lock
        static Mutex mLock = new Mutex();

        static void print(object i)
        {
            //lock
            mLock.WaitOne();

            Console.WriteLine($"Hello Thread! {(int)i}");

            //unlock
            mLock.ReleaseMutex();
        }

        static void Main(string[] args)
        {
            //
            //c# threads BEGIN
            //

            Console.WriteLine("Starting the thread...");

            //create a empty list of threads
            Thread[] threads = new Thread[10];

            //spawn threads
            for (int i = 0; i < threads.Length; ++i)
            {
                //assign a new thread to list of threads
                threads[i] = new Thread(print);
                threads[i].Start(i);
            }

            // blocks execution on the main thread until all threads exit
            Console.WriteLine("Wait for the thread to complete...");
            for (int i = 0; i < threads.Length; ++i)
            {
                //wait until all threads are finished
                threads[i].Join();
            }
            Console.WriteLine("The thread has completed!");

            //
            //c# threads END
            //

            //
            //c# task based Async BEGIN
            //

            //// main is synchronous, but will block and wait for its asynchronous
            // counterpart to finish

            //call MainAsync() and block execution until this task finishes
            MainAsync().Wait();

            //
            //c# task based Async END
            //


        }


        //REFERENCE task based Async

        // like a thread, this Task will not complete until we return from this
        // method (whether explicitly with a `return` statement or implicitly by
        // reaching the end of this method)
        static async Task MainAsync()
        {
            Console.WriteLine("MainAsync starting...");

            Worker worker = new Worker();
            Console.WriteLine("MainAsync halting and waiting for worker to complete...");
            // task will halt execution until this is done, but not block execution on this thread
            // (it'll do something else instead)
            string result = await worker.DoWork(1000);
            Console.WriteLine("MainAsync resuming after worker completed.");
            Console.WriteLine($"Task Result: {result}");

            Console.WriteLine("MainAsync ending...");
        }
    }

    class Worker
    {
        // note the use of the async keyword here
        public async Task<string> DoWork(int delay)
        {
            Console.WriteLine("Worker Task starting...");

            // task will halt execution until this is done
            // (the delay is the "work" we're doing)
            //
            // ... but not halt execution on the thread (it'll do something else instead)
            await Task.Delay(delay);
            Console.WriteLine("Hello Async!");

            Console.WriteLine("Worker Task finishing...");

            // this will be wrapped into a Task<TResult> object for return (where TResult is string)
            return "Completed";
        }
    }
}

//REFERENCE - c# threads
//
//// custom object for passing data to threads
//class PrintData
//{
//    public int id;
//    public string color;
//}

//class Program
//{
//    // mutex protecting Console Output (aka stdout)
//    static Mutex printLock = new Mutex();

//    // method to be run by thread
//    static void Print(object data)
//    {
//        Print((PrintData)data);
//    }

//    // actual method implementation
//    static void Print(PrintData printData)
//    {
//        // lock mutex (blocks if unable)
//        printLock.WaitOne();

//        Console.WriteLine($"Hello Thread {printData.id}");
//        Console.WriteLine($"My owner is John Madden and my favorite color is {printData.color}!");
//        Console.WriteLine("He's really good at football. Football!");

//        // unlock mutex
//        printLock.ReleaseMutex();
//    }

//    static void Main(string[] args)
//    {
//        Console.WriteLine("Starting the thread...");

//        Thread[] printers = new Thread[10];

//        // spawn threads
//        for (int i = 0; i < printers.Length; ++i)
//        {
//            printers[i] = new Thread(Print);    // spawns thread w/ given method
//            printers[i].Name = "Print Thread";  // name (for) debugging

//            PrintData data = new PrintData();   // populate data
//            data.id = i;
//            data.color = "Orange";

//            printers[i].Start(data);            // start thread, passing the argument (only one)
//        }

//        // block and wait until all threads are finished
//        Console.WriteLine("Wait for the thread to complete...");
//        for (int i = 0; i < printers.Length; ++i)
//        {
//            printers[i].Join();
//        }

//        Console.WriteLine("The thread has completed!");
//    }
//}