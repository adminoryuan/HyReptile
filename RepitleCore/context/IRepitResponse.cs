using System;
using RepitleCore.Untity;

namespace RepitleCore
{
    public interface IRepitResponse : IDisposable
    {
        string getCookie();

        string GetHeaders(string key);

        byte[] GetContent();

        /// <summary>
        /// 获取响应文本
        /// </summary>
        /// <returns></returns>
        string GetText(CodingEnum Coding);
        
        

    }
}
