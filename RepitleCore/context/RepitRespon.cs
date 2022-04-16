using System;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepitleCore.Untity;

namespace RepitleCore
{

    /// <summary>
    /// 爬虫的响应对象
    /// </summary>
    public class RepitRespon : IRepitResponse
    {
        private Socket connSocket;


        private int statueCode;

        private byte[] allBodys;

        private Dictionary<String, string> _Headers=new Dictionary<string, string>();

        

        public RepitRespon(Socket cSocket)
        {
            connSocket = cSocket;

            ReadResonse();
        }

        /// <summary>
        /// 读取响应体
        /// </summary>
        private  void ReadResonse()
        {
          
          
            //简单粗暴
            byte[] req = new byte[20480];

            
            int n=connSocket.Receive(req);
            Console.WriteLine(n);
            req = req.Take(n).ToArray(); 
            
            Console.WriteLine(n);
            int SplitIndex = 0;
            //找到分割线 \r\n\r\n 
            for (int i = 0; i < n; i++)
            {
                if (req[i]==13)
                {
                    if (req[i+3]==10)
                    {
                        //从这里开始分割
                        SplitIndex = i;
                        break;
                    }
                }
            } 
            InitHeadersAsync(Encoding.UTF8.GetString(req.Take(SplitIndex).ToArray()));
            
            int ContentLength=int.Parse(_Headers["Content-Length"]);

            List<byte> newBodyByte = req.Skip(SplitIndex + 4).ToList();


            int readBodylen = n - SplitIndex - 4;
            
            while (ContentLength> readBodylen)
            {
                
                n = connSocket.Receive(req);
                readBodylen += n;
                newBodyByte.AddRange(req.Take(n).ToArray());
            }
            
            Console.WriteLine($"len={ContentLength} readlen={readBodylen}");
            
            allBodys =newBodyByte.ToArray();
           
            
            
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        }

       

        /// <summary>
        /// 初始化请求头
        /// </summary>
        /// <param name="AllHeaders"></param>
        private void InitHeadersAsync(string AllHeaders)
        {
            string[] allHttps= AllHeaders.Split("\r\n");


            statueCode =int.Parse(allHttps[0].Split(" ")[1]);


            int index = 1;

            while (index < allHttps.Length)
            {
                string[] Rows = allHttps[index].Split(":");  
                _Headers.Add(Rows[0].Trim(), Rows[1].Trim());
                index++;
            }
            
        }

        
    
        /// <summary>
        /// 获取请求体
        /// </summary>
        /// <returns></returns>
        public byte[] GetContent()
        {
            return allBodys;
        }

       
    
        /// <summary>
        /// 获取Cookie
        /// </summary>
        /// <returns></returns>
        public string getCookie()
        {
            if (_Headers.ContainsKey("Cookie"))
            {
                return _Headers["Cookie"];
            }
            return null;
        }

        public string GetHeaders(string key)
        {
            if (_Headers.ContainsKey(key))
                return _Headers[key];
            
            return null;
        }

        public string GetText(CodingEnum Coding)
        {
            if (allBodys.Length <= 0)
            {
                return "";
            }
            return EncodingBody.Decoding(Coding,allBodys);
        }
        
        
    }
}
