using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    // public const double programVersion = 3.1;
    // public static readonly DateTime startUpTime= DateTime.Now;

    private string name;
    private string lastName;
    private string phoneNumber;
    private string address;
    private string dateOfBirth;

    public Person(string _name)
    {
        this.name = _name;
        Console.WriteLine("Created Person: " + this.name);
        Console.WriteLine("level 1 constructor");
    }

    // : this (_name) 
    // ^^ the above code that you can see to the right of the constructor is used to call the first constructor
    // so that you don't need to repeat the code in the first constructor we build, we can just use it.
    public Person(string _name, string _lastName) : this(_name)
    {
        Console.WriteLine("level 2 constructor");

        this.lastName = _lastName;
    }

    public Person(string _name, string _lastName, string _phoneNumber, string _address, string _dateOfBirth) : this(_name, _lastName)
    {
        Console.WriteLine("level 3 constructor");

        this.phoneNumber = _phoneNumber;
        this.address = _address;
        this.dateOfBirth = _dateOfBirth;
    }

    public string getName()
    {
        return name;
    }

    public string getName(bool isFull)
    {
        if (isFull)
        {
            return this.name + " " + this.lastName;
        }
        else
        {
            return getName();
        }
    }

    public string getDateOfBirth()
    {
        return dateOfBirth;
    }

    public string getPhoneNumber()
    {
        return phoneNumber;
    }

    public string getAddress()
    {
        return address;
    }
}

