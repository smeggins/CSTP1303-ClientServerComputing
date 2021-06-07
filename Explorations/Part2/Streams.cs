using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

/*
 Shows example of streaming through data from a document
 */

public class Streams
{
    public void CreateFile(string fileName)
    {
        using (Stream s = new FileStream(fileName, FileMode.Create))
        {
            Console.WriteLine(s.CanRead);
            Console.WriteLine(s.CanWrite);
            Console.WriteLine(s.CanSeek);

            s.WriteByte(101);
            s.WriteByte(102);

            byte[] bytes = { 1, 2, 3, 4, 5, 6 };
            s.Write(bytes, 0, bytes.Length);

            Console.WriteLine("Stream Length: {0}", s.Length);
            Console.WriteLine("posiiton {0}:", s.Position);

            s.Position = 0;

            Console.WriteLine("new Position[0]: {0}", s.ReadByte());
            Console.WriteLine("new Position[1]: {0}", s.ReadByte());

            var block = new byte[10];
            s.Read(block, 0, bytes.Length);

            Console.WriteLine("block: {0}", block);

        }
    }


    public static void test()
    {
        Streams aStream = new Streams();

        aStream.CreateFile("StreamText.txt");
    }
}

