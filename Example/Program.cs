using System;
using RestitleUntity;

using System.IO;
namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {


            string currPath = Environment.CurrentDirectory;

            string allHtml=File.ReadAllText($"{currPath}/{"ExmapleHtml/ExampleTest1.html"}");


          
            XmlUntity untity = new XmlUntity(allHtml);

            var Nodes= untity.SelectNode("html/body");

       


           Console.ReadLine();
            
        }
    }
}
