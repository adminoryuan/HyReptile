using System;
using RestitleUntity;

using System.IO;
using System.Net;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Console.WriteLine(Dns.GetHostByName("www.baidu.com").AddressList[0].ToString());



         
            Console.ReadLine();
             
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
