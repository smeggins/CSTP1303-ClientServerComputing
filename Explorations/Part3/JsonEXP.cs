using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

class JsonEXP
{
    /*
     people.json 
    {
        "firstname" : "sarah",
        "lastname" : "smith",
        "age" : 35,
        "friends" : 
        [
            "dyllan",
            "jim",
            "jam"
        ]
    }
     */

    public void createReadWriteJson()
    {
        var student = new Student()
        {
            studentID = "00123",
            name = "jim jam",
            program = "computer science",
            startYear = 2020
        };

        string jsonString = JsonSerializer.Serialize(student);
        Console.WriteLine(jsonString);

        File.WriteAllText("myJsonFile.json", jsonString);
        var jsonFromFile = File.ReadAllText("myJsonFile.json");

        Console.WriteLine(jsonFromFile);

        var studentFromFile = JsonSerializer.Deserialize<Student>(jsonFromFile);
        studentFromFile.name
    }

    public static void test()
    {
        var json = new JsonEXP();
        json.createReadWriteJson();
    }
}

public class Student
{
    public string studentID { get; set; }
    public string name { get; set; }
    public string program { get; set; }
    public int startYear { get; set; }
}
