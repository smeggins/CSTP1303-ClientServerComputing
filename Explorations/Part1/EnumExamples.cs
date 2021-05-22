using System;
using System.Collections.Generic;
using System.Text;

namespace Explorations.Part1
{
    // enum is a value type
    public enum Example {
        a,
        b,
        c,
        d
    }
    class EnumExamples
    {
        void test (Example letter)
        {
            if (letter == Example.a)
            {
                // casting enum to an int
               int aNumber = (int)letter;
            }
            //casting int to enum
            Example testval = (Example)2;

        }
    }
}
