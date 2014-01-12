using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class Floten2Info : CommonInfo
    {
        internal const string XPATH_FLOTEN2_PARAM = "/html/body/center/center/input";

        private static HttpAccesser PerpareHttpAccesserFloten2(HttpAccesser ha, FleetInfo fleetInfo, FleetMission fleetMission)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(StarScript.universe);
            sb.Append(".cicihappy.com/ogame/floten2.php");
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            ha.UrlParam = string.Empty;
            int i = 0;
            foreach (DictionaryEntry de in fleetInfo.Floten1Params)
            {
                if (i != 0)
                {
                    ha.UrlParam += "&";
                }
                ha.UrlParam += de.Key.ToString() + " = " + de.Value.ToString();
                i++;
            }
            ha.UrlParam += FleetUtil.FleetDestination2PostParam(fleetMission);
            return ha;
        }

        private static FleetInfo AnalyzHtmlFloten2(FleetInfo fleetInfo)
        {
            // 验证页面是否是未期待页面
            UnExpectPageController.Varify();

            HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
            fleetInfo.Floten2Params = new Hashtable();
            HtmlNode.ElementsFlags.Remove("option");
            h.Load(ConstString.HTML_PATH);
            HtmlNodeCollection floten2Params = h.DocumentNode.SelectNodes(XPATH_FLOTEN2_PARAM);
            foreach (HtmlNode hn in floten2Params)
            {
                HtmlAttributeCollection hac = hn.Attributes;
                try
                {
                    if (!fleetInfo.Floten1Params.ContainsKey(hac[1].Value))
                    {
                        fleetInfo.Floten2Params.Add(hac[1].Value, hac[2].Value);
                    }
                }
                catch (ArgumentException ae)
                {
                    ae.ToString();
                }
            }
            return fleetInfo;
        }
    }
}
