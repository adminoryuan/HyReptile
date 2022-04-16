using System;
using System.Collections.Generic;
using RestitleUntity;

using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using RepitleCore;
using System.Threading.Tasks;
using System.Text;
using RepitleCore.Untity;

namespace Example
{
    class Program
    {

       static void TestRow()
        {
            string str = "user-agent:askjdlaksjdlaksjdklajsdas \r\n\r\n bodys";

            byte[] bodys = Encoding.UTF8.GetBytes(str);

            byte[] a =Encoding.UTF8.GetBytes("\r\n");
          
            int len = 0;
            foreach (var item in bodys)
            {
                if(item==13 || item == 10)
                {
                    len += 1;
                }
                else
                {
                    len = 0;
                }

                if (len > 4)
                {
                    Console.WriteLine(item);
                   
                }
                
            }
        }


        [Obsolete]
        static async Task Main(string[] args)
        {

     

         
           HyRepitle repitle = new HyRepitle();

           repitle.Request("GET", "http://www.spvec.com.cn");

           repitle.Accpect("text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");

           repitle.AddCookie("JSESSIONID=A8EBF79CFFBE80C24EF6C91C7D3D46E8");

           repitle.User_Agent("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.75 Safari/537.36");

           repitle.Headers("Accept-Language", "zh-CN,zh;q=0.9,en;q=0.8");
            
           repitle.Host("www.spvec.com.cn");

           repitle.Headers("Connection", "keep-alive");

          // repitle.Headers("Accept-Encoding", "gzip,deflate");

           IRepitResponse response= await repitle.StartReptile();

             
           Console.WriteLine(response.GetText(CodingEnum.Utf8));

           }
       }

 
         
   
    }

