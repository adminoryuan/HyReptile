using System;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            List<byte> RespDatas = new List<byte>();

            byte[] DatasCache = new byte[521];
            int CurrReadLen = 512;

            int Readlens = connSocket.Receive(DatasCache);


            

            string[] https= Encoding.UTF8.GetString(DatasCache).Split("\r\n");

            int index=1; int ContenLenth = 0;


            while (https.Length > index){
                string[] row = https[index].Split(":");

                if (row[0].Contains("Content-Length")){
                    ContenLenth = int.Parse(row[1].Trim());
                    break;
                }
                index++;
            }
             

            foreach(byte i in DatasCache)
            {
                RespDatas.Add(i);
            }

          
           
            while (CurrReadLen < ContenLenth)
            {
                DatasCache = new byte[512];
                Readlens=connSocket.Receive(DatasCache);

                 
                foreach (byte i in DatasCache)
                {
                    
                    RespDatas.Add(i);
                } 

                CurrReadLen += Readlens;

            }



            string respStrings = Encoding.UTF8.GetString((DatasCache.ToArray()));

            Console.WriteLine(respStrings);
         
            string[] rows= respStrings.Split("\r\n\r\n");

          //  InitHeadersAsync(rows[0]);

            InitBodysAsync(rows[1]);

        }

       

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

        private void InitBodysAsync(string allBody)
        {
            allBodys =Encoding.UTF8.GetBytes(allBody);
                
        }

        public byte[] GetContent()
        {
            return allBodys;
        }

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

        public string GetText()
        {
            if (allBodys.Length <=0)
            {
                return "";
            }

            return Encoding.GetEncoding("GB2312").GetString(allBodys);
        }
    }
}
