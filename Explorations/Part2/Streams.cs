using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.IO.Pipes;

/*
 Shows example of streaming through data from a document
 */

public class Streams
{
    public void createMemoryStream()
    {
        var ms = new MemoryStream();
        ms.ToArray();// converts stream to byte array
        //sourceStream.CopyTo(ms);

    }
    // PipeStream provides a simple way to commuinicate between processes
    // One process sends data to the stream and the other process recieves a series of bytes
    // interprocess communication (ipc)
    //there are 2 kinds of pipes
    /*
     Anonymous pipe 
    -allows one way communication between parent and child precesses on the same computer
    -considered faaster

    Named pipe
    -allows 2 way communication between priocesses onm the same or different computer across a network
    -it doesnt rely on a network transport which means there will be no network protocol overhead
     */
    public void CreateNamedPipe()
    {
        Console.WriteLine("LEGGO");
        // the parites communicate through pipe of the same name 
        // 2 distict roles: the client and the server

        using var server = new NamedPipeServerStream("comm1"); // comm1 == pipe name
        server.WaitForConnection(); // this is to wait for the client connection
        server.WriteByte(112);
        Console.WriteLine("byte read" + server.ReadByte());

        using var client = new NamedPipeClientStream("comm1");
        client.Connect();
        Console.WriteLine(client.ReadByte());
        server.WriteByte(212);

        // named pipes are bi-directional (ie. they can read or write to the stream
        // client and server have to agree on some protocol in order to coordinate their actions
        
    }

    public static byte[] ReadMessage(PipeStream p)
    {
        MemoryStream ms = new MemoryStream();
        byte[] buffer = new byte[0x1000];

        // this do looop is essentially here to make sure that the code inside of do is executed
        // at least once, then if the loop condition is not met it will continue to loop
        // but again it ensures that the code inside is always executed at least once
        do// passthough, no conditional operator
        {
            ms.Write(buffer, 0, p.Read(buffer));
        } while (!p.IsMessageComplete); //THEN it checks the while condition

        return ms.ToArray();
    }

    // anonymous pips are a one way stream used for communitcation between
    // the parent and the child process
    public void CreateAnonymuousPipeServer()
    {
        using var aps = new AnonymousPipeServerStream(PipeDirection.Out);
    }

    public void CreateAnonymuousPipeClient()
    {
        //using var rx = new AnonymousPipeClientStream(PipeDirection.In, );
    }

    public void CreateFile(string fileName)
    {
        using (Stream s = new FileStream(fileName, FileMode.Create))
        {
            Console.WriteLine(s.CanRead); // if false stream is write only
            Console.WriteLine(s.CanWrite); // if false stream is read only
            Console.WriteLine(s.CanSeek); // if true i seekable

            s.WriteByte(101);
            s.WriteByte(102);

            byte[] bytes = { 1, 2, 3, 4, 5, 6 };
            s.Write(bytes, 0, bytes.Length);

            Console.WriteLine("Stream Length: {0}", s.Length);
            Console.WriteLine("positon {0}:", s.Position);

            s.Position = 0;

            Console.WriteLine("new Position[0]: {0}", s.ReadByte());
            Console.WriteLine("new Position[1]: {0}", s.ReadByte());

            var block = new byte[10];
            var bytesRead = s.Read(block, 0, bytes.Length); 

            Console.WriteLine("block: {0}", block);

        }
    }

    public async void CreateFileAsync(string fileName) // added async
    {
        // when you see using used in this way it is opening a connection with something
        // external, it will execute the code inside of its {} 
        // Then at the end it will close the connection to that external resource automatically
        // basically so you don't need to close the connection manually like in c++
        using (Stream s = new FileStream(fileName, FileMode.Create))
        {
            byte[] bytes = { 1, 2, 3, 4, 5, 6 };
            s.WriteAsync(bytes, 0, bytes.Length);// changed from write to writeasync

            Console.WriteLine("Stream Length: {0}", s.Length);
            Console.WriteLine("positon {0}:", s.Position);

            s.Position = 0;

            Console.WriteLine("new Position[0]: {0}", s.ReadByte());
            Console.WriteLine("new Position[1]: {0}", s.ReadByte());

            var block = new byte[10];
            var bytesRead = await s.ReadAsync(block, 0, bytes.Length);// added await and async after Read

            // streams are not thread safe. This means 2 or more threads can not
            // concurrently read and write to the same stream
        }
    }

    /// <summary>
    /// TextReader and TextWriter are the abstract base classes and deal with chars and string
    /// text adapters make it easier to read and write to files than working directly with streams
    /// </summary>
    public void textAdapter()
    {
        // write 2 lines of text to a file then read the file back
        using (FileStream fs = File.Create("testStream1.txt"))
            using (TextWriter writer = new StreamWriter(fs))
        {
            writer.WriteLine("here is the first line");
            writer.WriteLine("here is the second line");
        }

        using (FileStream fs = File.OpenRead("testStream1.txt"))
            using (TextReader reader = new StreamReader(fs))
        {
            Console.WriteLine(reader.ReadLine());
            Console.WriteLine(reader.ReadLine());
        }

        // alternate way to do the same thing

        using (TextWriter writer = File.CreateText("testStream2.txt"))
        {
            writer.WriteLine("here is the first line");
            writer.WriteLine("here is the second line");
        }

        using (TextReader reader = File.OpenText("testStream2.txt"))
        {
            while (reader.Peek() > -1)
            {
                Console.WriteLine(reader.ReadLine());
            }
        }

    }

    public void textAdapterAsync()
    {
        // write 2 lines of text to a file then read the file back
        using (FileStream fs = File.Create("testStream1.txt"))
        using (TextWriter writer = new StreamWriter(fs))
        {
            writer.WriteLineAsync("here is the first line");
            writer.WriteLineAsync("here is the second line");
        }

        using (FileStream fs = File.OpenRead("testStream1.txt"))
        using (TextReader reader = new StreamReader(fs))
        {
            Console.WriteLine(reader.ReadLineAsync());
            Console.WriteLine(reader.ReadLineAsync());
        }

        // alternate way to do the same thing

        using (TextWriter writer = File.CreateText("testStream2.txt"))
        {
            writer.WriteLineAsync("here is the first line");
            writer.WriteLineAsync("here is the second line");
        }

        using (TextReader reader = File.OpenText("testStream2.txt"))
        {
            while (reader.Peek() > -1)
            {
                Console.WriteLine(reader.ReadLineAsync());
            }
        }
    }

    public void compression()
    {
        using (var s = File.Create("compressed.bin"))
        using (var df = new DeflateStream(s, CompressionMode.Compress))
        {
            for (byte i = 0; i < 100; i++)
            {
                df.WriteByte(i); // should write 0-99
            }
        }

        using (var s = File.OpenRead("compressed.bin"))
        using (var ds = new DeflateStream(s, CompressionMode.Decompress))
        {
            for (byte i = 0; i < 100; i++)
            {
                Console.WriteLine(ds.ReadByte());
            }
        }
    }

    public void file()
    {
        string filepath = "compressed.bin";
        var fileAttributes = File.GetAttributes(filepath);

        if ((fileAttributes & FileAttributes.ReadOnly) != 0)
        {
            Console.WriteLine("The file is read only");
        }

        File.Delete("someFile");

        var fileInfo = new FileInfo("compressed.bin");// serts file to read only
        fileInfo.IsReadOnly = true;
    }

    public static void test()
    {
        Streams aStream = new Streams();

        // if you want 2 methods to access the same resource you need to make sure
        // one method has priority using locks
        // in this case we are just acting on 2 different files
        //aStream.CreateFile("StreamText.txt");
        //Console.WriteLine("\n\n");
        //aStream.CreateFileAsync("StreamTextAsync.txt");

        // ===========================Pipes================================
        //aStream.CreateNamedPipe();

        // ===========================TextAdapters================================
        //aStream.textAdapter();

        // ===========================Compression================================
        aStream.compression();
    }
}

public class StreamsPerson
{
    public String name;
    public int age;
    public double height;

    public StreamsPerson(String a_name, int a_age, double a_height)
    {
        name = a_name;
        age = a_age;
        height = a_height;
    }

    public void binaryAdapterSaveData(Stream s)
    {
        var writer = new BinaryWriter(s);
        writer.Write(name);
        writer.Write(age);
        writer.Write(height);
    }

    public void binaryAdapterLoadData(Stream s)
    {
        var reader = new BinaryReader(s);
        name = reader.ReadString();
        age = reader.ReadInt32();
        height = reader.ReadDouble();

        byte[] data = new BinaryReader(s).ReadBytes((int)s.Length);
    }

    public void fileStream()
    {
        using (FileStream fs = new FileStream("fsText.txt", FileMode.Create))
        {
            var writer = new StreamWriter(fs);
            writer.WriteLine("test from stream");
            writer.Flush();

            fs.Position = 0;
            Console.WriteLine(fs.ReadByte());
        }  
    }
}