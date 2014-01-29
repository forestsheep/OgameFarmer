using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class HtmlAnalyzer
    {
        static HtmlAnalyzer()
        {
            HtmlNode.ElementsFlags.Remove("option");
            //HtmlNode.ElementsFlags.Remove("form");
        }

        private HtmlDocument hdoc;
        /// <summary>
        /// 获取或设定是否忽略html的Option tag
        /// 默认为true
        /// </summary>
        internal bool IsRemoveOption = true;

        /// <summary>
        /// 读取html
        /// </summary>
        /// <returns>HtmlDocument</returns>
        internal HtmlNode Load()
        {
            if (hdoc == null)
            {
                hdoc = new HtmlAgilityPack.HtmlDocument();
                hdoc.Load(ConstString.HTML_PATH);
            }
            return hdoc.DocumentNode;
        }

        /// <summary>
        /// 解析一个xpath节点
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns>返回单个的HtmlNode节点的集合</returns>
        internal HtmlNodeCollection AnalyzeNodes(string xpath)
        {
            return Load().SelectNodes(xpath);
        }

        /// <summary>
        /// 解析一个xpath节点
        /// </summary>
        /// <param name="xpath">xpath路径表达式</param>
        /// <param name="carenull">
        /// 是否在意能否解析到信息，如在意则抛出KeywordNotFoundInHtmlException异常。默认在意。
        /// </param>
        /// <returns>返回单个的HtmlNode节点</returns>
        internal HtmlNode AnalyzeNode(string xpath, bool carenull = true)
        {
            HtmlNode hn = Load().SelectSingleNode(xpath);
            if (carenull && hn == null)
            {
                throw new KeywordNotFoundInHtmlException(xpath);
            }
            return hn;
        }
    }
}
