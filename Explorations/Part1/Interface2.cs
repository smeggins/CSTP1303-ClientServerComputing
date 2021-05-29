using System;
using System.Collections.Generic;
using System.Text;


class Interface2
{
    public static int[] TransformAll(int[] values, ITransform t)
    {
        var results = new int[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            t.Transform(values[i]);
        }

        return results;
    }

    public void test()
    {
        int[] vs = { 1, 2, 3 };
        var results3 = TransformAll(vs, new Squarer());
    }
}

public interface ITransform
{
    int Transform(int x);
}

public class Squarer : ITransform
{
    public int Transform(int x)
    {
        return x * x;
    }
}

