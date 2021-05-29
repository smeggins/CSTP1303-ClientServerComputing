using System;
using System.Collections.Generic;
using System.Text;

namespace Explorations.Part1
{
    public delegate int Transformer (int x);
    class LambdaFuncFuncExample
    {
        /*
         Internally the compiler resolved the lambda by writing a private method
        and by putting the expression code into the method
        Lambda x => x*x;
        (parameters) => statement-block
         */
        Transformer lambdaTransformer = x => x * x;

        // last val is always the return type of func
        // (int = x, int = y, int = return type)
        Func<int, int, int> basicallyTheSameWithoutDelegate = (x, y) => x * y;
    }
}
