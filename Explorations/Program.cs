using System;

namespace Explorations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Showing us accessing each constructor: \n");
            Person person1 = new Person("Henry");
            Person person2 = new Person("Jim", "Jam");
            Person person3 = new Person("Don", "Dotson", "(123)456-7890", "123 Main St, BC", "1/1/1111");


            Console.WriteLine("\nPrinting each users availible info:\n");
            //Print Person Info
            Console.WriteLine("First Persons Info: \n");
            Console.WriteLine("First Name: " + person1.getName(), "\n\n");

            Console.WriteLine("\n\nSecond Persons Info: \n");
            Console.WriteLine("Full Name: " + person2.getName(true));

            Console.WriteLine("\n\nThird Persons Info: \n");
            Console.WriteLine("Full Name: " + person3.getName(true));
            Console.WriteLine("Date Of Birth: " + person3.getDateOfBirth());
            Console.WriteLine("Phone Number: " + person3.getPhoneNumber());
            Console.WriteLine("Address: " + person3.getAddress());

        }

    }
}
