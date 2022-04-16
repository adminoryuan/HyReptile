using System;
using System.Text;

namespace RepitleCore.Untity
{
    public enum CodingEnum
    {
        Utf8,
        GB2312,
        Unicode
    }
    /// <summary>
    /// 对字符串进行编码
    /// </summary>
    public class EncodingBody
    {
        public static String Decoding(CodingEnum code,byte[] bodys)
        {
            switch (code)
            {
                case CodingEnum.Utf8:
                    return Encoding.UTF8.GetString(bodys);
                case CodingEnum.GB2312:
                    return Encoding.GetEncoding("gb2312").GetString(bodys);
                case CodingEnum.Unicode:
                    return Encoding.Unicode.GetString(bodys);
            }

            throw  new Exception("暂时不支持该编码");
        }
        
    }
}