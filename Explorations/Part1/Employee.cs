using System;
using System.Collections.Generic;
using System.Text;

public class Employee : Person
{
    public Employee(string name) : base(name) { }
    public Employee(string fname, string lname) : base(fname, lname) { }
}