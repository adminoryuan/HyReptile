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

        static async Task RepitleHtml()
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


            string BodyStr = response.GetText(CodingEnum.Utf8);
        }
        [Obsolete]
        static async Task Main(string[] args)
        {
            HyRepitle repitle=new HyRepitle();
            
            repitle.Request("GET","http://www.spvec.com.cn/static/images/notice-bg.png");
            repitle.User_Agent("Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.85 Safari/537.36");
            repitle.Headers("Referer","http://www.spvec.com.cn/static/css/index.css");
            IRepitResponse response= await repitle.StartReptile();
        
            Console.WriteLine(response.GetText(CodingEnum.Utf8));


        }
       }

 
         
   
    }

