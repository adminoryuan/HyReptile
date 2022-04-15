using System.Drawing;
using System.Net.Sockets;
using Microsoft.VisualBasic.CompilerServices;

namespace Example
{
    public class ReadHttpUntity
    {
        private Socket socket;

        public ReadHttpUntity(Socket _socket)
        {
                
        }
        /// <summary>
        /// 读取一个完整的http 响应报文
        /// </summary>
        /// <param name="headers">返回请求头</param>
        /// <param name="Bodys">返回请求体</param>
        public void ReadHttp(byte[] headers,byte[] Bodys)
        {
            
            
        }
    }
}