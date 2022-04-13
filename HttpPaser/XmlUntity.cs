using System;
using System.Xml;

namespace RestitleUntity
{
    /// <summary>
    /// 负责解析Xml
    /// </summary>
    public class XmlUntity
    {
        private XmlDocument doc;

        public XmlUntity(string xml)
        {
            doc = new XmlDocument();
            doc.LoadXml(xml);

           
        }

        public XmlNodeList SelectNode(string node)
        {
            int len=doc.DocumentElement.ChildNodes.Count;


            
            return doc.DocumentElement.SelectNodes(node);
        }

        
    }
}
