using System;
using System.Collections.Generic;
using System.Text;

namespace Explorations.Part1
{
    class Delegates
    {
        // in this situation we are defining Transformer as our value name
        public delegate int Transformer(int s);

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

        public static int SquareArea2(int s) => s * s;

        public static void process(int[] values, Transformer val)
        {
            for (int i = 0; i< values.Length; i++)
            {
                values[i] = val(values[i]);
            }
        }

    }
}
