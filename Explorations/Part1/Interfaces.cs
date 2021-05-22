using System;
using System.Collections.Generic;
using System.Text;

namespace Explorations.Part1
{
    // Interface naming convention starts with an I
    // interface only works for functions and MUST BE PUBLIC
    public interface IValidator
    {
        //below is dummy code for example 
        bool validate(int a);

        int returnVal(int b);
    }

    public interface IInterface2 {
        //you can inherit multiple interfaces
    }

    public interface IValidatorInheritor : IValidator
    {
        // this extends the IValidator interface so you can add to it
    }

    public class ExampleClass
    {
        //this is to illustrate that you can also inherit from a class
    }

    public class Interfaces : IValidator, IInterface2
    {
        // so interfaces are like virtual methods. 
        // so an interface is a declaration of a method without definition
        // so when we inherit it in a class if forces you to implement it
        // within that class

        public bool validate(int a)
        {
            return a > 5;
        }

        public int returnVal(int b)
        {
            return b - 1;
        }
    }

    public class InterfaceWithClass : ExampleClass, IInterface2
    {
        // This is just to show that you can inherit a class and an
        // interface at the same time
    }
}
