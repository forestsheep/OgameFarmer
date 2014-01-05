using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class Floten1Info : CommonInfo
    {
        internal const string XPATH_FLOTEN1_PARAM = "/html/body/center/input";

        /// <summary>
        /// 发舰队第一个页面返回的属性
        /// </summary>
        internal Hashtable Floten1Params;

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
            string htmlTxt = Txtout.Read();
            UnExpectPageController upc = UnExpectPageController.GetInstance();
            upc.VarifyCookiePeriod(htmlTxt);

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
