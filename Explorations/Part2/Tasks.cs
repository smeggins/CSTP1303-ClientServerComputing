using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;


namespace Explorations.Part2
{
    class Tasks
    {
        public static void threadPool()
        {
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

            Task.Run(() =>
            {
                var isPool = Thread.CurrentThread.IsThreadPoolThread;
                Console.WriteLine("This task is thread pool active {0}", isPool);
            });
            //Task.WaitAll();
            var isPool = Thread.CurrentThread.IsThreadPoolThread;
            Console.WriteLine("This task is thread pool active {0}", isPool);

            Task<int> task1 = Task.Run(() =>
            {
                Console.WriteLine("Task of int");
                return 30;
            });

            //blocks until result
            int res = task1.Result;

            Console.WriteLine(res);
            // define a thread and run the folllowing code
            Task taskThrowingException = Task.Run(() => throw new Exception("something wrong yo"));

            //main thread (not a defined thread
            try
            {
                // wait for this thread to finish
                taskThrowingException.Wait();
            }
            catch (AggregateException aex)
            {
                if (aex.InnerException is Exception)
                {
                    Console.WriteLine("exception error");
                }
                else
                {
                    Console.WriteLine("sme other exception happened");
                    throw;
                }
            }
        }

        public static void taskContinuation()
        {
            Task<int> task = Task.Run(async () =>
             {
                 Console.WriteLine("doing something here");
                 await Task.Delay(3000);
                 return 3200; 
             });
            // can't delay specific task, will only work to delay whatever task happens to be executed by
            // the cpu at thte time.
    

            ///////////////////////////
            // Continuation method 1 //
            ///////////////////////////

            //var awaiter = task.GetAwaiter(); awaiter.OnCompleted(() =>
            //{
            //    int result = awaiter.GetResult();
            //    Console.WriteLine(result);
            //});

            ///////////////////////////
            // Continuation method 2 //
            /////////////////////////// 
            
            // Executes when the 
            task.ContinueWith(a =>
            {
                char[] test = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(test[i]);
                }
                Console.WriteLine("continue with: ");
            });
            task.Wait();

            Console.WriteLine("continuing on ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////
        /// Didn't Get Working////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        
        public static async void downloadSomething(string uri)
        {
            Console.WriteLine("about to do something");
            try 
            {
                var u = new Uri(uri);

                byte[] data = await new WebClient().DownloadDataTaskAsync(u);
                Console.WriteLine("Length of data: {0}", data.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured: {0}", e);
            }
        }
        public static void test()
        {
            var uri = "https://www.msn.com/en-ca/news/news-videos/trudeau-says-the-feds-are-looking-at-reopening-canada-to-tourists-in-a-phased-way/vp-AAKX1m5";
            downloadSomething(uri);
        }
    }
}

