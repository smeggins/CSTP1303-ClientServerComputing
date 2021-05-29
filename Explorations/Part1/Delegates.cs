using System;
using System.IO;
using System.Collections.Generic;
using System.Text;


public class Delegates
{
    // in this situation we are defining Transformer as our value name
    public delegate int Transformer(int s);
    public delegate T GenericTransformer<T>(T s);

    // as you can see we are defining this delegate as newTransformer
    public delegate string newTransformer(int x);

    public Delegates()
    {
        Transformer transformer = squareArea;
        int result = transformer(5);
        int result2 = squareArea(5);

        //as you can see result and result2 are the same thing

        Console.WriteLine($"delegates returned: {result}, {result2}");

        // delegates automaticall use invoke when called.
        // this is just to show what it calls automatically
        int result3 = transformer.Invoke(5);
        Console.WriteLine($"delegate thats been invoked: {result3}");
    }

    public static int squareArea(int s)
    {
        return s * s;
    }

    public static int squareArea2(int s) => s * s;

    public static void process(int[] values, Transformer val)
    {
        for (int i = 0; i< values.Length; i++)
        {
            values[i] = val(values[i]);
        }
    }

    public static int[] DoTransformation(int[] values,  Transformer t)
    {
        int[] results = new int[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            results[i] = t(values[i]);
        }
            
        return results;
    }

    public static T[] DoTransformationGeneric<T>(T[] values, GenericTransformer<T> t)
    {
        var results = new T[values.Length];
        for (int i = 0; i< values.Length; i++)
        {
            results[i] = t(values[i]);
        }

        return results;
    }

    public static T[] DoTransformationGeneric<T>(T[] values, Func<T, T> t)
    {
        var results = new T[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            results[i] = t(values[i]);
        }

        return results;
    }

    public static void Process(int[] values, Transformer t)
    {
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = t(values[i]);
        }
    }

    public static void WriteStatusToConsole(int status)
    {
        Console.WriteLine("status: " + status);
    }

    public static void WriteStatusToFile(int status)
    {
        File.WriteAllText("status.txt", "status: " + status.ToString());
    }

    public void test()
    {
        Transformer transformer = squareArea;
        //GenericTransformer gTransformer = squareArea;
        transformer(5);

        // multi cast example
        // basically what this does is let you run multiple methods that share the same signature
        // using the same delegate
        StatusReporter sr = null;
        sr += WriteStatusToConsole;
        sr += WriteStatusToFile;

        ReportUtil.work(sr);

        var shapeType = 1; // squaretype 1, squaretype 2 
        var area = 0;

        if (shapeType == 1)
        {
            area = squareArea(2);
        }
        else
        {
            area = squareArea2(3);
        }

        // using a delegate
        if (shapeType == 1)
        {
            transformer = squareArea; // initializing 
        }
        else
        {
            transformer = squareArea2; // initializing 
            transformer += squareArea;
        }

        var area3 = transformer(2);

        var Number = 15;

        int result2 = squareArea(5);



        int result = transformer(5);

        int r3 = transformer.Invoke(6); // <= another way to use a delegate

        int r2 = squareArea(5);

        Console.WriteLine("transformer returned:", result);



        int[] values = { 1, 2, 3, 4, 5 };
        var results = DoTransformation(values, transformer);

        foreach (int i in results)
        {
            Console.WriteLine(i);
        }


        transformer -= squareArea2; // removes a function reference from the delegate

        //DoTransformationGeneric(values, gTransformer);
    }

}

public delegate void StatusReporter(int completedNumber);

public class ReportUtil
{
    public static void work(StatusReporter sr)
    {
        for (int i = 0; i < 10; i++)
        {
            // doing something important here 
            sr(i); // reporting the status to console and a file
        }
    }
}

