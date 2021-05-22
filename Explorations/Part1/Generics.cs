using System;
using System.Collections.Generic;
using System.Text;

// Similar to templates in c++
public class Generics <T>
{
    int position;
    T[] data = new T[100];

    public void push(T value)
    {
        data[position++] = value;
    }

    public T pop()
    {
        return data[--position];
    }
}
