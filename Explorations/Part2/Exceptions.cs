using System;
using System.Collections.Generic;
using System.Text;


class Exceptions
{
    static int calc(int x) => 10 / x;
    public void throwExceptionTest()
    {
        try
        {
            int a = 5 * 5;
            int y = calc(0);
            var result = 35 + a + y;
        }
        // NOTE: Specific Exceptions must be checked before generic Exception
        // it ArgumentNullException before Exception
        catch(ArgumentNullException aex)
        {
            Console.WriteLine("Argument passed was nuill: " + aex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Exception happened: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("clean-up code or data if needed here");
        }
    }

    public static void throwExceptionArgNullTest()
    {
        try
        {
            int y = calc(1);
            var result = 35 + y;
        }
        catch (ArgumentNullException aex)
        {
            Console.WriteLine("Argument passed was nuill: " + aex.Message);
        }
        finally
        {
            Console.WriteLine("clean-up code or data if needed here");
        }
    }

    public void test()
    {
        throwExceptionTest();
        throwExceptionArgNullTest();
    }
}