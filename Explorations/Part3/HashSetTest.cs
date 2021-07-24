using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class HashSetTest
{
    public HashSet<Person> People { get; set; }
    public static int getNumerOfVowels(string str)
    {
        var letters = new HashSet<char>(str);
        var vowels = "aeiou";

        letters.IntersectWith(vowels);
        foreach (var item in letters)
        {
            Console.WriteLine(item);
        }
        return letters.Count;
    }

    public static void LinqQuery()
    {
        IEnumerable<string> names = new[] { "tom", "dick", "harry" , "Joan"};

        // we don't do anything with this but it can be used to sort ienumerables
        var sortedNames = names.OrderBy(n => n.Length);

        // returns the first value that matches the search param of contains "e"
        var s = names.Where(n => n.Contains("a"));
        foreach (var item in s)
        {
            Console.WriteLine(item);
        }
    }

    public static void test()
    {
        getNumerOfVowels("Brawk");
        LinqQuery();
    }
}
