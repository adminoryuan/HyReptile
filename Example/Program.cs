using System;
using RestitleUntity;

using System.IO;
using System.Net;
using RepitleCore;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        [Obsolete]
        static async Task Main(string[] args)
        {
            HyRepitle repitle= new HyRepitle();

            repitle.Request("GET", "http://www.spvec.com.cn");

            repitle.Accpect("text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");

            repitle.AddCookie("JSESSIONID=A8EBF79CFFBE80C24EF6C91C7D3D46E8");

            repitle.User_Agent("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.75 Safari/537.36");

            //repitle.Host("www.spvec.com.cn");

            repitle.Headers("Connection","keep-alive");

            repitle.Headers("Accept-Encoding", "gzip,deflate");

           await  repitle.StartReptile();
 


        }
        static void TestRepitleCore()
        {
            
        }
        static void TestXmlUntity()
        {
            #region TestXmlUntity

            string currPath = Environment.CurrentDirectory;

            string allHtml = File.ReadAllText($"{currPath}/{"ExmapleHtml/ExampleTest1.html"}");
            XmlUntity untity = new XmlUntity(allHtml);

            var Nodes = untity.SelectNode("body");


            Console.WriteLine(Nodes.Item(0).InnerXml);

            #endregion
        }
    }
}
