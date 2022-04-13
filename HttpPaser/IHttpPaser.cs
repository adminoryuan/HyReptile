using System;
using RestitleUntity;

namespace RestitleUntity
{

    /// <summary>
    /// 负责解析HTML 
    /// </summary>
    public interface IHttpPaser
    {
        /// <summary>
        /// 将html 解析成对象
        /// </summary>
        HtmlElment Paser(); 

        /// <summary>
        /// 根据xpath 路径对html 进行解析
        /// </summary>
        HtmlElment  SearchXpath(string xpath);


        void SetHtmlSrc(string Filepath);


        void SetHtml(string Html);
               

    }
}
