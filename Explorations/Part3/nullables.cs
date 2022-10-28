using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// This class is here to illustrate that you can put a ? after a primative type to make it a nullable of that type
/// This means a type like int that can't normally return null is able to return that type of value
/// </summary>
class Nullables
{
    int? a = 123; // nullable
    int b = 456; // not nullable

    static void nullableTypes(int? nullableINT)
    {
        string a = null; // strings are a reference type so this is ok
        //int i = null; // this is not ok because it is a value type (compile error)

        int? j = null; // this creates a nullable type of int

        // <T>? translates to Nullable<T>

        int? x = 5; // implicit conversion
        int y = (int)x; // explicit conversion

        object o = "string";
        int? z = 0 as int?; // z will return null because "string" cannot cast to int

        int? x1 = 5;
        int? x2 = 10;

        bool result = x1 < x2; // true

        // must handle the potential for x1 or x2 being null

        if (x1.HasValue && x2.HasValue) // checkls if either is null
        {
            //return (x1.Value < x2.Value); // does actual comparison
        }
        else
        {
            //return false;
        }

        int? z1 = null;
        int? z2 = 3;
        int? z3 = z1 + z1; // will equal null

        //shorthand for dealing with nullables
        int? d1 = null;
        int? d2 = d1 ?? 5; // this means if d1 is null use 5 instead
        int? d3 = 6;

        // This will print the FIRST value found that isn't a null.
        // else it will print the last value
        Console.WriteLine(d1 ?? d2 >> d3);

    }

    public class Customer
    {
        public decimal? accountBalance;
    }

    //public class Entity
    //{
    //    Entity parentEntity;
    //    Color? a_color;
        
    //    public Color color 
    //    { 
    //        get { return a_color ?? parentEntity.a_color; }
    //        set { a_color = value == parentEntity.a_color ? (Color?}null : value;
    //    }
    //}

    public class Color
    {

    }
}
