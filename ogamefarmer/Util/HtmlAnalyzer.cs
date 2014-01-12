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
        }
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
            HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
            h.Load(ConstString.HTML_PATH);
            return h.DocumentNode;
        }

        /// <summary>
        /// 解析一个xpath，从加载文件开始
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns>HtmlNodeCollection</returns>
        internal HtmlNodeCollection AnalyzeNodes(string xpath)
        {
            return Load().SelectNodes(xpath);
        }

        /// <summary>
        /// 解析一个xpath，之前已经加载过文件
        /// </summary>
        /// <param name="htmlNode">加载好的HtmlNOde</param>
        /// <param name="xpath"></param>
        /// <returns>HtmlNodeCollection</returns>
        internal HtmlNodeCollection AnalyzeNodes(HtmlNode htmlNode, string xpath)
        {
            return htmlNode.SelectNodes(xpath);
        }

        /// <summary>
        /// 解析一个xpath，从加载文件开始
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns>返回单个的HtmlNode节点</returns>
        internal HtmlNode AnalyzeNode(string xpath)
        {
            return Load().SelectSingleNode(xpath);
        }

        /// <summary>
        /// 解析一个xpath，之前已经加载过文件
        /// </summary>
        /// <param name="htmlNode"></param>
        /// <param name="xpath"></param>
        /// <returns>返回单个的HtmlNode节点</returns>
        internal HtmlNode AnalyzeNode(HtmlNode htmlNode, string xpath)
        {
            return htmlNode.SelectSingleNode(xpath);
        }
    }
}
