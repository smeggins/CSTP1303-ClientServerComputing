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
}
