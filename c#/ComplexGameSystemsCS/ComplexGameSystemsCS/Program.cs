using System;
using System.Threading;

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
            //create a empty list of threads
            Thread[] threads = new Thread[10];

            for (int i = 0; i < threads.Length; ++i)
            {
                //assign a new thread to list of threads
                threads[i] = new Thread(print);
                threads[i].Start(i);
            }

            // blocks execution on the main thread until all threads exit
            for (int i = 0; i < threads.Length; ++i)
            {
                //wait until all threads are finished
                threads[i].Join();
            }
        }
    }
}
