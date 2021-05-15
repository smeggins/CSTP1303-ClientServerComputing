using System;
using System.Collections.Generic;
using System.Text;

/*
 * Fully implement the stack class 
 * add a method to get the Count on the Stack
 * 
 * if (stack.Count() > 0) // do something
 * 
 * returns the count of items
 * public int Count()
 * {}
 * 
 * returns true if there are any items on stack
 * public bool HasItems()
 * {}
 * 
 * Push and Pop should check array boundries and return an error
 * Return type can be a bool for Push and Pop
 * true for success and false for failure
 * 
 *  For pop create a class with 2 members 
 *      public bool Result
 *      public object Item
 * 
 * 
 * */
public class PopReturn
{
    public PopReturn(bool result, object item)
    {
        Result = result;
        Item = item;
    }
    public bool Result;
    public object Item;
}

public class Stack
{
    private int position;
    private int size;
    private object[] data;

    public Stack(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException("size can't be zero");
        }

        this.size = size;
        this.data = new object[size];
    }

    public int count()
    {
        return position;
    }
    
    public bool HasItems()
    {
        return position > 0;
    }

    public void Push(object obj)
    {
        if (position < size)
        {
            data[position++] = obj;
        }
        else
        {
            throw new ArgumentException("Array Full");
        }
    }

    public object Pop()
    {
        if (HasItems())
        {
            return new PopReturn(true, data[--position]);
        }
        else
        {
            throw new ArgumentException("Array Already Empty");
        }
    }
}
