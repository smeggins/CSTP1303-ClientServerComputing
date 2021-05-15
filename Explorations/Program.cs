using System;

namespace Explorations
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack1 = new Stack(5);
            stack1.Push("this is a test");
            stack1.Push(22);
            stack1.Push("this is a test");
            stack1.Push(22);
            stack1.Push(22);
            Console.WriteLine($"stack1 has items = {stack1.HasItems()}");
            Console.WriteLine($"stack1 has this many items = {stack1.count()}");
            stack1.Pop();
            Console.WriteLine($"stack1 has items = {stack1.HasItems()}");
            Console.WriteLine($"stack1 has this many items = {stack1.count()}");
            stack1.Pop();
            stack1.Pop();
            stack1.Pop();
            stack1.Pop();
            Console.WriteLine($"stack1 has items = {stack1.HasItems()}");
            Console.WriteLine($"stack1 has this many items = {stack1.count()}");

        }
    }
}
