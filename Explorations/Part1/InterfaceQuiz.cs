using System;
using System.Collections.Generic;
using System.Text;

namespace Explorations.Part1
{
    
    class InterfaceQuiz : IInterface
    {

        public void takesString(string a)
        {
            Console.WriteLine(a);
        }
}
}
