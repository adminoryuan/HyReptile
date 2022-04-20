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

      
        [Obsolete]
        static async Task Main(string[] args)
        {
            string html = await RepitleHtml();

            Console.WriteLine(html);

            RepitleUntity.GetUserAgent(UserAgentEnum.Android);
            RepitleUntity.GetTimeStamp();


        }
        static async Task<string> RepitleHtml()
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
            return BodyStr;
        }
        static async Task Example1()
        {
            HyRepitle repitle=new HyRepitle();
            
            repitle.Request("GET","http://www.240ps.com/images/ad/bot_9_1.jpg");
            repitle.User_Agent("Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.85 Safari/537.36");
            
            repitle.Headers("Host","www.240ps.com");
            
            repitle.AddCookie("ASPSESSIONIDQCBQQTRR=DOPFLANBANACGKKLJHNPLCNM; Hm_lvt_a51d8817652d1bb0611c5f7cfbb13209=1648813376,1648880465,1650114164,1650185402; Hm_lpvt_a51d8817652d1bb0611c5f7cfbb13209=1650185694");
            
            IRepitResponse response= await repitle.StartReptile();
 
            await HyRepitle.DownFile("../a.jpg",response.GetContent());
        }
    }

 
         
   
    }

