using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace Explorations.Part2
{
    class FibonacciAssignment
    {

        static int fib(int n)
        {
            // calculates fib iteratively, not sure if you wanted recursive
            // (i know thats normally the fib exercise)
            // but this is more efficient
            int x = 0;
            int y = 1;
            int z = y;
            for (int j = 0; j < n - 1; j++)
            {
                z = y;
                y = x + y;
                x = z;
            }
            return y;
        }

        static int getArg()
        {
            int result = -1;
            Console.Write("Please Enter A Integer for it's Fibinnaci number Or Q to quit: ");

            while (true) {
                string input = Console.ReadLine();
                if (input != "q" && input != "Q")
                {
                    try
                    {
                        result = Convert.ToInt32(input);
                        break;
                    }
                    catch
                    {
                        Console.Write("\nPlease Enter A Valid Integer Or Q to quit: ");
                    }

                }
                else
                {
                    break;
                }
            }
            return result;
        }

        public static void test()
        {
            while (true)
            {
                int arg = getArg();
                int result = -1;

                if (arg != -1)
                {
                    Thread fib1 = new Thread(() => result = fib(arg));
                    fib1.Start();
                    fib1.Join();
                    Console.WriteLine("Fibonacci: {0}\n", result);
                }
                else
                {
                    Console.WriteLine("Thanks for Using my Fibonacci Calculator!\n");
                    Console.WriteLine("Made By: Phillip Chadwick");
                    break;
                }
            }
        }
    }
}
