using System;
using System.Collections.Generic;
using RestitleUntity;

using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using RepitleCore;
using System.Threading.Tasks;
using System.Text;

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
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
           StringBuilder reqBuilder=new StringBuilder();
           reqBuilder.Append("GET / HTTP/1.1 \r\n");
           reqBuilder.Append("User-Agent:Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1 \r\n");
           reqBuilder.Append("Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9 \r\n");
           reqBuilder.Append("Host: www.baidu.com");
           reqBuilder.Append(
               "Cookie: BIDUPSID=D7AC3D6EEE91F8E8A81E1DC12651606B; PSTM=1619265710; __yjs_duid=1_66c39136fb7293da681078f0ae3de5791619267517373; BDUSS=RXOVJ-cDFSaHZDVU9wWEh1TFFjMmd1M0xlYUF6OVk5REhiSDhnelNSM0xST0JnRVFBQUFBJCQAAAAAAAAAAAEAAAAQ9LKwMTU2MTk5Njg1MDd5AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAMu3uGDLt7hgVm; BDUSS_BFESS=RXOVJ-cDFSaHZDVU9wWEh1TFFjMmd1M0xlYUF6OVk5REhiSDhnelNSM0xST0JnRVFBQUFBJCQAAAAAAAAAAAEAAAAQ9LKwMTU2MTk5Njg1MDd5AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAMu3uGDLt7hgVm; MCITY=-324%3A; BD_UPN=123353; BAIDUID=668606376D4F065ABEFFDD7BB999D126:FG=1; BDORZ=B490B5EBF6F3CD402E515D22BCDA1598; channel=baidusearch; BAIDUID_BFESS=668606376D4F065ABEFFDD7BB999D126:FG=1; BD_HOME=1; delPer=0; BD_CK_SAM=1; PSINO=6; baikeVisitId=86ae8ddf-0eae-48d9-a863-b704c6e75d6b; ab_sr=1.0.1_Y2MxMzkxNTIxNTY5N2I3ZGI4NTMzZTEyNzUyNmNkNzRjNTIyODU1MzUyNTljMGEwZGU1MzJlMTgxMmQyNjI3MWM4ZjE1NDFkMGE0MjBmNTA4MGQzNTFiZTBmOWRiMjEwYWJhYmE2NDFlMzEzZDUyNzQ4NmU3MzA0MWFiMjI0NzI2YmIxNDUwZTE2YWMxYzY2YjQxZjE0ZTg0M2Y3M2QyZmZkZWY0M2IwN2QyZGUzNTVjZDVmMzA1ODY0ZDlhMmI4; BDRCVFR[feWj1Vr5u3D]=I67x6TjHwwYf0; H_PS_PSSID=35834_31253_36004_36165_34584_36121_36193_36126_36224_26350_35867_36102_36061; H_PS_645EC=f9b5%2BDzUK0W67QNUj8D2vhm%2BEc9e9BjTd6iOWlwIVCs%2FHfDHoZxWZTZhS08eRUN1ahwC; BA_HECTOR=258gahaka000018g6t1h5igno0r");
             
           socket.Connect("222.186.58.73",80);
           
           
           socket.Send(Encoding.UTF8.GetBytes(reqBuilder.ToString()));
           
           
           byte[] req = new Byte[100];
           int n=101;
           bool isRadHeaders = true;
           List<String> header = new List<string>();
           List<byte> RespData=new List<byte>();
           while (n >= 100)
           {
               n = socket.Receive(req);

               if (isRadHeaders)
               {
                   
                   string httpHeaders = Encoding.UTF8.GetString(req); 
                   string[] rows = httpHeaders.Split("\r\n");
                   foreach (var row in rows)
                   {
                       header.Add(row);
                       if (row.Trim().Equals(""))
                       {
                           isRadHeaders = false;
                           break;
                       }

                   }
               }
               else
               {
                   for (int i = 0; i < n; i++)
                   {
                       RespData.Append(req[i]);
                   }
               }
           }
       }

 

        static  async  void H()
        {
            
            HyRepitle repitle = new HyRepitle();

            repitle.Request("GET", "http://www.spvec.com.cn");

            repitle.Accpect("text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");

            // repitle.AddCookie("JSESSIONID=A8EBF79CFFBE80C24EF6C91C7D3D46E8");

            repitle.Headers("Accept-Encoding", "gzip, deflate");
            repitle.User_Agent("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.75 Safari/537.36");

            repitle.Headers("Accept-Language", "zh-CN,zh;q=0.9,en;q=0.8");
            
            repitle.Host("www.spvec.com.cn");

            repitle.Headers("Connection", "keep-alive");

            repitle.Headers("Accept-Encoding", "gzip,deflate");

            IRepitResponse response= await repitle.StartReptile();

             
            Console.WriteLine(response.GetText());
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
