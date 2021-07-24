using System;
using System.Collections.Generic;
using System.Text;
using System.Threading; 

namespace Explorations.Part2
{
    class AsyncAndThreads
    {
        /* == Concurrency ==
        Responsive UI
        Allow requests to process simultaneously
        Parallel Programming

        The general mechanism to simultaniously execute code is multi-threading

        threads run within a os process
         */

        private static bool _done { get; set; }
        private readonly static object _locker = new object();

        public static void startThread()
        {
            Thread t1 = new Thread(writeCharZ);

            t1.Start();
            

            for (int i = 0; i < 1000; i++)
            {
                Console.Write("Y");
            }

            // join waits for the thread (in this case t1) to end before executing 
            // the following lines of code
            t1.Join();

            // sleep pauses the current thread. This means ie. the startThread()...
            // if we wanted to sleep the t1 thread we would add Thread.Sleep in 
            // the method being called by t1 which is writeCharZ()
            Thread.Sleep(100);

            Console.WriteLine("thread t1 has ended");

            for (int i = 0; i < 1000; i++)
            {
                Console.Write("X");
            }
        }

        public static void writeCharZ()
        {
            Console.WriteLine("charZ is excecuting");
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("Z");
                //Thread.Sleep(100);// waits 100 ms before printing every z
            }
        }

        public static void useFunc()
        {
            _done = false;
            new Thread(go).Start(); // new thread calling go

            // this is the preferred way to use a function that takes an argument  in threads
            // using Lambda Expressions
            Thread tm1 = new Thread(() => printMessage("passing the message argument using the method it'self"));
            tm1.Start();
            go();                   // main thread calling go

            Thread tm2 = new Thread(printMessage2);
            tm2.Start("passing the message argument through Thread.Start() instead of printMessage(). sends arg as an obj!");

        } 

        public static void go()
        {
            
            for (int cycle = 0; cycle < 10; cycle++)
            {
                Console.Write('?');
            }

            // lock uses an object to make sure that the containing code is only executed once
            // we normally use an empty readonly object for this
            // this is only used when a method is called by multiple threads at the same time
            lock (_locker)
            {
                if (!_done)
                {
                    // prints done when finished iterating in go()
                    // NOTE: because the os determine execution order sometimes
                    // --done-- prints after 10 ?'s and sometimes it's after all 20
                    // basically whenever the go() for loop finishes iterating
                    _done = true;
                    Console.WriteLine("-- Done --");
                }
            }
        }

        public static void printMessage(string message)
        {
            Console.WriteLine("message: {0}", message);
        }

        public static void printMessage2(object message)
        {
            var strMessage = (string)message;
            Console.WriteLine("message: {0}", strMessage);
        }

        public static void ThreadsAndException()
        {
            try
            {
                new Thread(throwingFunc).Start();
            }
            catch (Exception ex)
            {
                // this will never be thrown because the exception is being handled in a
                // new thread above in try
                Console.WriteLine("Exception Occured"); 
            }
        }

        public static void throwingFunc()
        {
            throw new Exception("something done mucked up");
        }


        public static void threadPriority()
        {
            // priority of threads based on other threads
            // increasing the priority of 1 thread slows down all other threads 
            // overuse can slowdown entire computer
            // should be used as last resort and only to solve specific problems
            // is controlled by an enum value that goes from 0 -lowest to 5? highest
            var signal = new ManualResetEvent(false);
            new Thread(() =>
            {
                Console.WriteLine("wait for the go...");
                signal.WaitOne();
                signal.Dispose();
                Console.WriteLine("got it .. excecuting");
            
            }).Start();

            Thread.Sleep(3000);
            signal.Set();
        }

        public static void test()
        {
            AsyncAndThreads.useFunc();
            AsyncAndThreads.startThread();
            AsyncAndThreads.ThreadsAndException();
        }
    }
}
