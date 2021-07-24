using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;


public static class Xml
{
    public static void xmlParse()
    {
        XElement customer = XElement.Parse(createXml().ToString());

        foreach (var item in customer.Elements())
        {
            Console.WriteLine(item.Name + ": " + item.Value);
            foreach (XAttribute attr in item.Attributes())
            {
                Console.WriteLine(attr.Name + ": " + attr.Value);
            }
        }
        int count = customer.Elements("firstName").Count();
        var name = customer.Elements().Where(e => e.Name == "firstName" && e.Value == "Joe");
        Console.WriteLine("name: {0}", name.ToString());

        foreach (XNode item in customer.Nodes())
        {
            // Saveoptions in this context is used to remove any formatting chars from the string like \n 
            Console.WriteLine(item.ToString(SaveOptions.DisableFormatting));
        }
    }

    public static void getInfoFromXml(XElement elements)
    {
        if (elements.HasAttributes)
        {
            foreach (var attribute in elements.Attributes())
            {
                Console.WriteLine("{0}: {1}", attribute.Name, attribute.Value);
            }
        }

        if (elements.HasElements)
        {
            foreach (var element in elements.Elements())
            {
                getInfoFromXml(element);
            }
        }
    }

    public static void xmlParseFromFile(string xmlDocumentPath)
    {
        XDocument xmlFile = XDocument.Load(xmlDocumentPath);

        foreach (var item in xmlFile.Elements())
        {
            getInfoFromXml(item);
        }
    }

    public static XElement createXml()
    {
        XElement lastName = new XElement("lastName", "jam");
        lastName.Add(new XComment("nice name"));

        XElement customer = new XElement("customer");
        customer.Add(new XAttribute("id", 123));
        customer.Add(new XElement("firstName", "Jim"));

        customer.Add(lastName);

        return customer;
    }

    public static void test()
    {
        var xmlFileLocation = "S:/VCC/client server computing/Explorations/Part3/xml/baseball.xml";

        //xmlParse();
        xmlParseFromFile(xmlFileLocation);
    }
    
    public static void xmlRetrieve()
    {

    }
}
