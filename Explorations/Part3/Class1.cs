using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
/// <summary>
/// Addressing
/// IPv4
/// 32bit
/// [101.102.103.104]
/// 
/// ipv6
/// 128bit
/// [Jead:ffef:...]
/// 
/// 0-F
/// 
/// SMTP - port 25
/// 
/// http://www.mydomain.com:999/files/books.json?q=book#top
/// scheme://host:port/AbsoluteAddress/Query/Fragment
/// </summary>
class Class1
{
    Uri page = new Uri("http://www.mydomain.com/info/page.html");

    public async void clientTest()
    {
        // URI class parses the address letting you grab different parts quickly
        // also validates the address

        // The basic client that lets you, simply, download and upload data
        WebClient wc = new WebClient() { Proxy = null };

        //wc.DownloadFile("address for file you want to save", "file save location");
        wc.DownloadFile("http://www.ibm.com/", "ibmcom.html");

        // async version of above using our previously saved URI
        await wc.DownloadFileTaskAsync(page, "ibmcom.html");

        //WebException
        ///////////////////////The following is the equivilant of using WebClient//////////////////
        //WebRequest && WebResponse = more complex and flexible than webclient                     
        WebRequest req = WebRequest.Create("http://www.mydomain.com/code.html");
        req.Proxy = null;
        using (WebResponse resp = req.GetResponse())
        {
            using (Stream rs = resp.GetResponseStream()) // Input stream
            {
                using (FileStream fs = File.Create("localcode.html")) // Output stream
                {
                    rs.CopyTo(fs);
                }
            }
        }

        ///async version///
        ///WebRequest req = WebRequest.Create(page);
        using (WebResponse aresp = await req.GetResponseAsync())
        {
            using (Stream rs = aresp.GetResponseStream()) // Input stream
            {
                using (FileStream fs = File.Create("localcode.html")) // Output stream
                {
                    await rs.CopyToAsync(fs);
                }
            }
        }
        ////////////////////////////////////end/////////////////////////////////////
    }

    public async Task httpClientTests()
    {
        // Http-bases web API and REST services
        // Rest == Representational State Transfer
        //          its a popular web architecture
        //          operates over basic HTTP
        string html = await new HttpClient().GetStringAsync(page);

        var httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync("http://www.google.com");
        
        using (var fs = File.Create("saveFile.html"))
        {
            await response.Content.CopyToAsync(fs);
        }

        
    }
}
