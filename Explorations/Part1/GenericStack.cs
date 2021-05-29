using System;
using System.Collections.Generic;
using System.Text;

public class PopReturn <T>
{
    public PopReturn(bool result, T item)
    {
        Result = result;
        Item = item;
    }
    public bool Result;
    public T Item;
}

public class GenericStack<T>
{
    private int position;
    private int size;
    private T[] data;

    public GenericStack(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException("size can't be zero");
        }

        this.size = size;
        this.data = new T[size];
    }

    public int count()
    {
        return position;
    }

    public bool HasItems()
    {
        return position > 0;
    }

    public void Push(T obj)
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

    public PopReturn<T> Pop()
    {
        if (HasItems())
        {
            return new PopReturn<T>(true, data[--position]);
    }
        else
        {
            throw new ArgumentException("Array Already Empty");
}
    }

    public static void test()
    {
        var stackGeneric = new GenericStack<int>(100);
        stackGeneric.Push(5);
        stackGeneric.Push(10);
        int n1 = stackGeneric.Pop().Item;
        int n2 = stackGeneric.Pop().Item;

        Console.WriteLine($"popped values are: {n1}, and {n2}");

        var stackGeneric2 = new GenericStack<string>(100);
        stackGeneric2.Push("one");
        stackGeneric2.Push("two");
        string n3 = stackGeneric2.Pop().Item;
        string n4 = stackGeneric2.Pop().Item;

        Console.WriteLine($"popped values are: {n3}, and {n4}");

        var stackGeneric3 = new GenericStack<Person>(100);
        stackGeneric3.Push(new Person("Jim"));
        stackGeneric3.Push(new Person("Sarah"));
        string n5 = stackGeneric3.Pop().Item.getName();
        string n6 = stackGeneric3.Pop().Item.getName();

        Console.WriteLine($"popped values are: {n5}, and {n6}");

        var stackGeneric4 = new GenericStack<Asset>(100);
        stackGeneric4.Push(new Asset("Ford f150"));
        stackGeneric4.Push(new Asset("Toyota Corolla"));
        string n7 = stackGeneric4.Pop().Item.Name;
        string n8 = stackGeneric4.Pop().Item.Name;

        Console.WriteLine($"popped values are: {n7}, and {n8}");

        var stackGeneric5 = new GenericStack<House>(100);
        stackGeneric5.Push(new House("Mansion"));
        stackGeneric5.Push(new House("Duplex"));
        string n9 = stackGeneric5.Pop().Item.Name;
        string n10 = stackGeneric5.Pop().Item.Name;

        Console.WriteLine($"popped values are: {n9}, and {n10}\n");

        Console.WriteLine("------------------------------------About to Test Try/Catch-------------------------------\n");
        
        /////////////////////////////////////////////////////////////////////////    
        // Note the exception I throw supersedes the try/catch but without it  //
        // (and without the if statment in the push and pull methods)          //
        // the compiler would throw a IndexOutOfRangeException                 //
        /////////////////////////////////////////////////////////////////////////
        
        var stackGenericPushExc = new GenericStack<int>(2);
        try
        {
            Console.WriteLine("beginning Push");
            stackGenericPushExc.Push(5);
            stackGenericPushExc.Push(10);
            stackGenericPushExc.Push(20);
        }
        catch(IndexOutOfRangeException sysExc)
        {
            Console.WriteLine("IndexOutOfRangeException occured when pushing: " + sysExc);
        }
        catch (Exception exc)
        {
            Console.WriteLine("Exception occured when pushing: " + exc);
        }

        try
        {
            Console.WriteLine("Beginning Pop");
            stackGenericPushExc.Pop();
            stackGenericPushExc.Pop();
            stackGenericPushExc.Pop();
        }
        catch (IndexOutOfRangeException sysExc)
        {
            Console.WriteLine("IndexOutOfRangeException occured when popping: " + sysExc);
        }
        catch (Exception exc)
        {
            Console.WriteLine("Exception occured when popping: " + exc);
        }
    }
}
