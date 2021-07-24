using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

public static class Xml
{
    public static void xmlParse(string xmlString)
    {
        XElement customer = XElement.Parse(xmlString);

        foreach (var item in customer.Elements())
        {
            Console.WriteLine(item.Name + ": " + item.Value);
        }
    }

    public static void xmlParseFromFile(string xmlDocumentPath)
    {
        XDocument xmlFile = XDocument.Load(xmlDocumentPath);
        foreach (XElement element in xmlFile.Descendants("division"))
        {
            Console.WriteLine(element);
        }
    }

    public static void test()
    {
        var xmlString = "<customer  id='123' status='active'><firstName>joe</firstName><lastName>Belfiore<!--nice name--></lastName></customer>";
        var xmlFileLocation = "xml/baseball.xml";

        xmlParse(xmlString);
        xmlParseFromFile(xmlFileLocation);
    }
    

}
