using System;
using System.Collections.Generic;
using System.Text;

// basically passes stuff as a reference or a copy

public class refExample
{
    int a = 1;
    int b = 2;

    public static void swap<T>(ref T a, ref T b)
    {
        var temp = a;
        a = b;
        b = temp;
    }


    public static void swap2(ref int a, ref int b)
    {
        var temp = a;
        a = b;
        b = temp;
    }

    void doThing()
    {
        refExample.swap2(ref a, ref b);
    }
}
