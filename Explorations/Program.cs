using System;



//NAME SPACES
//public - fully accessable
//private - accessable only within that class
//protected - availible to all child/sub classes
//internal - accessible within the assembly 

/*  Assembly - This is a way to separate projects, 
 *  each assembly creates its own dll or exe file
 */
    

namespace Explorations
{
    class Program
    {
        static void Main(string[] args)
        {
            //var genericStack = new GenericStack();
            ////statusReporter sr = null;
            ////sr += writeStatustoConsole;
            ////sr += writeStatusToFile;

            ////reportUtil.work()
            //genericStack.test();

            GenericStack<int>.test();


        }
    }
}
