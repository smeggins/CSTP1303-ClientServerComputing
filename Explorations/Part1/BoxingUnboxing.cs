using System;
using System.Collections.Generic;
using System.Text;

namespace Explorations.Part1
{
    class BoxingUnboxing
    {
        void example()
        {
            // References the change from value type to reference type
            // value types are the primitve types:
            // bool, int, etc.....
            // Reference types are created/complex types
            // so if you make a class its a reference type

            // this would be an example of boxing
            // X is 'boxed' to a reference type
            int x = 9;
            object obj = x;

            // this would be an example of unboxing
            // y is 'unboxed' back to a value type
            int y = (int)obj;

            //NOTE:: casting is checked at runtime so if 
            // you cannot cast the two values it will throw an
            // exception (invalid cast exception) at that time
            // you will not see an error before you compile though

            object obj2 = 3.5;
            int y2 = (int)obj2;
        }
    }
}
