using System;
using System.Xml;

namespace RestitleUntity
{

    /// <summary>
    /// 实现一个html 解析器
    /// </summary>
    public class HttpPaser 
    {
        private XmlUntity _untity;

        public HttpPaser(string Html)
        {
            _untity=new XmlUntity(Html);
        }
       

        public HttpPaser SearchXpath(string xpath)
        {
            return null;
        }

        public void SetHtml(string Html)
        {
            throw new NotImplementedException();
        }

        public void SetHtmlSrc(string Filepath)
        {
            throw new NotImplementedException();
        }
    }
}
