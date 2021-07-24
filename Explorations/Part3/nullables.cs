using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// This class is here to illustrate that you can put a ? after a primative type to make it a nullable of that type
/// This means a type like int that can't normally return null is able to return that type of value
/// </summary>
class nullables
{
    int? a = 123;
    
    static void setIntToNull(int? nullableINT)
    {
        a = null;
    }
    
}
