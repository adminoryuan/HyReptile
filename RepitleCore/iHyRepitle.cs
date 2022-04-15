using System;
using System.Threading.Tasks;

namespace RepitleCore
{

    public interface iHyRepitle
    {
        void Request(string Method, string url);

        void Headers(string key,string val);

        void User_Agent(string val);

        void Accpect(string val);

        void Host(string val);

        void AddCookie(string cookie);
        /// <summary>
        /// 开启爬虫
        /// </summary>
        Task<IRepitResponse> StartReptile();
    }
}
