using System;
using System.Text;

namespace RepitleCore.Untity
{
    /// <summary>
    /// 对字符串进行编码
    /// </summary>
    public class EncodingBody
    {
        public static String Decoding(string code,byte[] bodys)
        {
            switch (code)
            {
                case "utf-8":
                    return Encoding.UTF8.GetString(bodys);
                case "gb2312":
                    return Encoding.GetEncoding("gb2312").GetString(bodys);
                case "Unicode":
                    return Encoding.Unicode.GetString(bodys);
            }

            throw  new Exception("暂时不支持该编码");
        }
        
    }
}