using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    internal class Ex24MultiThreading
    {
        static int Count = 0;
        static void SomeComplexOperation()
        {
            lock (typeof(Ex24MultiThreading))
            {
                var currentThread = Thread.CurrentThread;

                Console.WriteLine("Into Complex operation");
                for (int i = 0; i < 10; i++)
                {
                    Count++;
                    Console.WriteLine("Complex function is running with Count {0} on thread {1}", Count, currentThread.Name);
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Exiting Complex Operation");
                Count = 0;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Into the main function");
            //SomeComplexOperation();
            Thread t1 = new Thread(SomeComplexOperation);
            t1.Name = "Thread 1";
            Thread t2 = new Thread(SomeComplexOperation);
            t2.Name = "Thread 2";
            t2.IsBackground = true;

            t1.Start();
            for(int i=0; i<10; i++)
            {
                Console.WriteLine("Main function is running");
                Thread.Sleep(1000);
            }
            t2.Start();
            Console.WriteLine("The main has finished the operation and we are closing it");
        }
    }
}
