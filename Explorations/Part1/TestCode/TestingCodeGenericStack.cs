//using System;



////NAME SPACES
////public - fully accessable
////private - accessable only within that class
////protected - availible to all child/sub classes
////internal - accessible within the assembly 

///*  Assembly - This is a way to separate projects, 
// *  each assembly creates its own dll or exe file
// */
    

//namespace Explorations
//{
//    class TestingCodeGenericStack
//    {
//        static void Main(string[] args)
//        {
//            var stackGeneric = new GenericStack<int>(100);
//            stackGeneric.Push(5);
//            stackGeneric.Push(10);
//            int n1 = stackGeneric.Pop().Item;
//            int n2 = stackGeneric.Pop().Item;

//            Console.WriteLine($"popped values are: {n1}, and {n2}");

//            var stackGeneric2 = new GenericStack<string>(100);
//            stackGeneric2.Push("one");
//            stackGeneric2.Push("two");
//            string n3 = stackGeneric2.Pop().Item;
//            string n4 = stackGeneric2.Pop().Item;

//            Console.WriteLine($"popped values are: {n3}, and {n4}");

//            var stackGeneric3 = new GenericStack<Person>(100);
//            stackGeneric3.Push(new Person("Jim"));
//            stackGeneric3.Push(new Person("Sarah"));
//            string n5 = stackGeneric3.Pop().Item.getName();
//            string n6 = stackGeneric3.Pop().Item.getName();

//            Console.WriteLine($"popped values are: {n5}, and {n6}");

//            var stackGeneric4 = new GenericStack<Asset>(100);
//            stackGeneric4.Push(new Asset("Ford f150"));
//            stackGeneric4.Push(new Asset("Toyota Corolla"));
//            string n7 = stackGeneric4.Pop().Item.Name;
//            string n8 = stackGeneric4.Pop().Item.Name;

//            Console.WriteLine($"popped values are: {n7}, and {n8}");

//            var stackGeneric5 = new GenericStack<House>(100);
//            stackGeneric5.Push(new House("Mansion"));
//            stackGeneric5.Push(new House("Duplex"));
//            string n9 = stackGeneric5.Pop().Item.Name;
//            string n10 = stackGeneric5.Pop().Item.Name;

//            Console.WriteLine($"popped values are: {n9}, and {n10}");
//        }
//    }
//}
