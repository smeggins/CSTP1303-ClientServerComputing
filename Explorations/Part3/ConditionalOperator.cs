using System;
using System.Collections.Generic;
using System.Text;

class ConditionalOperator
{
    public static bool exampleConditional()
    {
        int? x1 = 5;
        int? x2 = 10;

        // THIS IS A CONDITIONL ARGUMENT
        // the if statement is to the left of the ?
        // if true return whats to the right of the ?
        // else return whats after :
        bool r2 = (x1.HasValue && x2.HasValue) ? (x1.Value < x2.Value) : false;

        // above r2 is the same as saying

        if (x1.HasValue && x2.HasValue) // checkls if either is null
        {
            return (x1.Value < x2.Value); // does actual comparison
        }
        else
        {
            return false;
        }
    }
}
