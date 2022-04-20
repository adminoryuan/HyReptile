using System;
using System.Text;

namespace RepitleCore
{
    /// <summary>
    /// 描述一个http 请求对象
    /// </summary>
    public class HttpReqBody
    {

        /// <summary>
        /// 保存http 请求协议
        /// </summary>
        private StringBuilder _stringBuilder = new StringBuilder();


        public HttpReqBody(string method, string url)
        {

            StringBuilder builder=new StringBuilder();
            string[] Curls = url.Split("/");
            
            for (int i = 3; i <Curls.Length-1; i++)
            {
                builder.Append(Curls[i]); builder.Append("/");
            } 
            builder.Append(Curls[Curls.Length-1]);
          
            if (builder.ToString().Equals(""))
            {
                builder.Append("/");
            }

            Console.WriteLine(builder.ToString());
            _stringBuilder.Append($"{method} /{builder.ToString()} HTTP/1.1");
            _stringBuilder.Append("\r\n");
        }

        public void Headers(string headers)
        {
            _stringBuilder.Append(headers);
            _stringBuilder.Append("\r\n");
        }

        /// <summary>
        /// 添加data数据
        /// </summary>
        public void AddData(string playLoad)
        { 
            _stringBuilder.Append("\r\n");
            _stringBuilder.Append("\r\n"); 
            _stringBuilder.Append(playLoad); 
        }


        /// <summary>
        /// 获取请求的消息字节对象
        /// </summary>
        /// <returns></returns>
        public byte[] GetReqBuff()
        {
            _stringBuilder.Append("\r\n");
            _stringBuilder.Append("\r\n");
          
            return Encoding.UTF8.GetBytes(_stringBuilder.ToString());

        }




    }
}
