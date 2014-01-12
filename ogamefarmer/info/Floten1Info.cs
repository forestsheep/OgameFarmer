using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class Floten1Info : CommonInfo
    {
        #region const
        private const string XPATH_FLOTEN1_PARAM = "/html/body/center/input";
        #endregion

        #region 属性
        /// <summary>
        /// 发舰队第一个页面返回的属性
        /// </summary>
        internal Hashtable Floten1Params;

        private Fleet1Info fleet1Info;
        #endregion

        #region 构造函数
        internal Floten1Info(Fleet1Info fleet1Info)
        {
            this.fleet1Info = fleet1Info;
        }
        #endregion

        #region 实现接口方法
        public void AccessSite(ref HttpAccesser httpAccesser)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(StarScript.universe);
            sb.Append(".cicihappy.com/ogame/floten1.php");
            httpAccesser.AccessUrl = sb.ToString();
            httpAccesser.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            httpAccesser.UrlParam = string.Empty;
            // TODO 怎样传递好初始舰队页面的参数
            //int i = 0;
            //foreach (DictionaryEntry de in fleetInfo.FleetParams)
            //{
            //    if (i != 0)
            //    {
            //        ha.UrlParam += "&";
            //    }
            //    ha.UrlParam += de.Key.ToString() + " = " + de.Value.ToString();
            //    i++;
            //}

            //httpAccesser.UrlParam += FleetUtil.FleetQuantity2PostParam(sendingFleet);
            httpAccesser.Access();
        }

        public void AnalyzResponse()
        {
            // 验证页面是否是未期待页面
            UnExpectPageController.Varify();

            // 解析
            HtmlAnalyzer htmlAnalyzer = new HtmlAnalyzer();
            HtmlNode.ElementsFlags.Remove("option");
            HtmlNodeCollection hc = htmlAnalyzer.AnalyzeNodes(XPATH_FLOTEN1_PARAM);

            // 储存值
            foreach (HtmlNode hn in hc)
            {
                HtmlAttributeCollection hac = hn.Attributes;
                Floten1Params.Add(hac[1].Value, hac[2].Value);
            }
        }

        #endregion
        private static HttpAccesser PerpareHttpAccesserFloten1(HttpAccesser ha, FleetInfo fleetInfo, Fleet sendingFleet)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(StarScript.universe);
            sb.Append(".cicihappy.com/ogame/floten1.php");
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            ha.UrlParam = string.Empty;
            int i = 0;
            foreach (DictionaryEntry de in fleetInfo.FleetParams)
            {
                if (i != 0)
                {
                    ha.UrlParam += "&";
                }
                ha.UrlParam += de.Key.ToString() + " = " + de.Value.ToString();
                i++;
            }

            ha.UrlParam += FleetUtil.FleetQuantity2PostParam(sendingFleet);
            return ha;
        }

        private static FleetInfo AnalyzHtmlFloten1(FleetInfo fleetInfo)
        {
            // 验证页面是否是未期待页面
            UnExpectPageController.Varify();

            HtmlAnalyzer htmlAnalyzer = new HtmlAnalyzer();
            HtmlNode.ElementsFlags.Remove("option");
            HtmlNodeCollection hc = htmlAnalyzer.AnalyzeNodes(XPATH_FLOTEN1_PARAM);
            foreach (HtmlNode hn in hc)
            {
                HtmlAttributeCollection hac = hn.Attributes;
                //Floten1Params.Add(hac[1].Value, hac[2].Value);
            }

            HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
            fleetInfo.Floten1Params = new Hashtable();
            HtmlNode.ElementsFlags.Remove("option");
            h.Load(ConstString.HTML_PATH);
            HtmlNodeCollection floten1Params = h.DocumentNode.SelectNodes(XPATH_FLOTEN1_PARAM);
            foreach (HtmlNode hn in floten1Params)
            {
                HtmlAttributeCollection hac = hn.Attributes;
                fleetInfo.Floten1Params.Add(hac[1].Value, hac[2].Value);
            }
            return fleetInfo;
        }
    }
}
