using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RepitleCore
{
    public class HyRepitle: iHyRepitle
    {
        private NetHttp _Nethttp;

        private HttpReqBody reqBody;

        
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static async  Task DownFile(string filePath,byte[] content)
        {
            
           await File.WriteAllBytesAsync(filePath,content);
            
        }
        public void AddCookie(string cookie)
        {
            reqBody.Headers($"cookie: {cookie}");
        }

        public void Headers(string key, string val)
        {
            reqBody.Headers($"{key}: {val}");
        }

        public void Host(string val)
        {
            reqBody.Headers($"Host: {val}");
        }

        public void Accpect(string val)
        {
            reqBody.Headers($"Accpect: {val}");
        }

        [Obsolete]
        public void Request(string Method, string url)
        {
            _Nethttp = new NetHttp(url);
            reqBody = new HttpReqBody(Method,url);
           
        }

        public async Task<IRepitResponse> StartReptile()
        {
            return  await _Nethttp.RequestAsync(reqBody.GetReqBuff());
         
        }

        public void User_Agent(string val)
        {
            reqBody.Headers($"User-Agent: {val}");
        }
    }
}
