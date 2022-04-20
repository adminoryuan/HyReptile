using System;
using System.Collections.Generic;

namespace RepitleCore
{
    /// <summary>
    /// 封装爬虫常用工具
    /// </summary>
    public class RepitleUntity
    {
        private static Dictionary<UserAgentEnum, string> AgentMap = new Dictionary<UserAgentEnum, string>()
        {
            {UserAgentEnum.Firefox,"Mozilla/5.0 (Windows NT 6.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1"},
            {UserAgentEnum.IE6,"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_7_0) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.56 Safari/535.11"},
            {UserAgentEnum.IE7,"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_7_0) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.56 Safari/535.11"},
            {UserAgentEnum.IE8,"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_7_0) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.56 Safari/535.11"},
            {UserAgentEnum.IE11,"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_7_0) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.56 Safari/535.11"},
            {UserAgentEnum.GoogleAgent,"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_7_0) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.56 Safari/535.11"},
            {UserAgentEnum.Brown360,"Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; 360SE)"},
            {UserAgentEnum.Android,"Mozilla/5.0 (Linux; U; Android 2.3.7; en-us; Nexus One Build/FRF91) AppleWebKit/533.1 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1"},
            {UserAgentEnum.IOS,"Mozilla/5.0 (iPhone; U; CPU iPhone OS 4_3_3 like Mac OS X; en-us) AppleWebKit/533.17.9 (KHTML, like Gecko) Version/5.0.2 Mobile/8J2 Safari/6533.18.5"}
        };
        /// <summary>
        /// 随机产生一个headers
        /// </summary>
        /// <returns></returns>
        public static string GetUserAgent(UserAgentEnum agentEnum)
        {
            if (!AgentMap.ContainsKey(agentEnum))
                throw  new Exception("无该请求头");
            return AgentMap[agentEnum]; 
        }


        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
                
            //当前时间减去1970-1-1
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
    }
}