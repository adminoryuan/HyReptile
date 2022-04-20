using System;
using System.Xml;

namespace RestitleUntity
{

    /// <summary>
    /// 用于描述一个html 元素对象
    /// </summary>
    public class HtmlElment
    {
        private XmlNodeList _list;
        public HtmlElment(XmlNodeList _nodes)
        {
            _list = _nodes;
        }
    }
}
