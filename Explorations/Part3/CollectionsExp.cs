using System;
using System.Collections.Generic;
using System.Text;

public class CollectionsExp
{
    // What is a Dictionary?
    // A collection of Key/Value pairs that is indexed by the Key
    // and gives to fast access to the value when you provide the key

    public static Dictionary<string, Book> BooksDict { get; set; }

    public static List<Book> BooksList { get; set; }

    public CollectionsExp()
    {
        BooksList = new List<Book>()
            {
                new Book() { Title = "The Atlantis", Author = "A.G. Riddle", Publisher = "Legion Books", PublicationYear =  2013 },
                new Book() { Title = "The Secret Lake", Author = "Karen Inglis", Publisher = "Bantam Books", PublicationYear = 1999 }
            };

        BooksDict = new Dictionary<string, Book>();
        foreach (var book in BooksList)
        {
            BooksDict.Add(book.Title, book);
        }
    }

    /// <summary>
    /// Search for a book by title - runtime complexity => O(N)
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    public Book SearchByTitle(string title)
    {
        foreach (var book in BooksList)
        {
            if (book.Title == title)
            {
                return book;
            }
        }

        return null;
    }

    /// <summary>
    /// Search for a book by title improved (v2) - runtime complexity => O(1)
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    public Book SearchByTitleV2(string title)
    {
        if (BooksDict.ContainsKey(title))
        {
            return BooksDict[title];
        }

        return null;
    }

    public Book SearchByTitleV3(string title)
    {
        //NOTE out denotes multiple return values.
        if (BooksDict.TryGetValue(title, out Book book))
        {
            return book;
        }

        return null;
    }

    // Book book gets defined here automaticallyt then uses a pointer in the folowing method
    public bool tryGetByTitleUsingOut(string title, out Book book)
    {
        //NOTE out denotes multiple return values.
        if (BooksDict.TryGetValue(title, out Book b))
        {
            book = b;
            return true;
        }
        book = null;
        return false;
    }





    //TEST CODE

    public void test()
    {
        tryGetByTitleUsingOut("brawk", out Book book);
        //TestSearchByTitle_WhenBookIsFound_ShouldReturnTheBook();
        //TestSearchByTitle_WhenBookIsNotFound_ShouldReturnNull();
        //TestSearchByTitleV2_WhenBookIsFound_ShouldReturnTheBook();
        //TestSearchByTitleV2_WhenBookIsNotFound_ShouldReturnNull();
    }

    public void testOutForMultipleReturns()
    {

    }

    public void TestSearchByTitle_WhenBookIsFound_ShouldReturnTheBook()
    {
        var expectedTitle = "The Atlantis";
        CollectionsExp collectionsExp = new CollectionsExp();
        var result = collectionsExp.SearchByTitle(expectedTitle);

        if (result == null || result.Title != expectedTitle)
        {
            Console.WriteLine("Title should be found and was Not Found!");
        }
    }

    public void TestSearchByTitle_WhenBookIsNotFound_ShouldReturnNull()
    {
        var expectedTitle = "The Atlantis II";
        CollectionsExp collectionsExp = new CollectionsExp();
        var result = collectionsExp.SearchByTitle(expectedTitle);

        if (result != null)
        {
            Console.WriteLine("Title should Not be Found, and null should be returned!");
        }
    }


    public void TestSearchByTitleV2_WhenBookIsFound_ShouldReturnTheBook()
    {
        var expectedTitle = "The Atlantis";
        CollectionsExp collectionsExp = new CollectionsExp();
        var result = collectionsExp.SearchByTitleV2(expectedTitle);

        if (result == null || result.Title != expectedTitle)
        {
            Console.WriteLine("Title should be found and was Not Found!");
        }
    }

    public void TestSearchByTitleV2_WhenBookIsNotFound_ShouldReturnNull()
    {
        var expectedTitle = "The Atlantis III";
        CollectionsExp collectionsExp = new CollectionsExp();
        var result = collectionsExp.SearchByTitleV2(expectedTitle);

        if (result != null)
        {
            Console.WriteLine("Title should Not be Found, and null should be returned!");
        }
    }
}

public class Book
{
    public string Title;
    public string Author;
    public string Publisher;
    public int PublicationYear;
}



////======== TESTS =======

////Snippet


