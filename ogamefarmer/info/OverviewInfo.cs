using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace OgameFarmer
{
    class OverviewInfo : CommonInfo
    {

        //internal static string XPATH_METAL = "";

        internal static HttpAccesser PrepareHttpAccesser(string universe)
        {
            HttpAccesser ha = new HttpAccesser();
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(universe);
            sb.Append(".cicihappy.com/ogame/overview.php");
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            ha.Host = universe + ".cicihappy.com";
            ha.UserAgent = "Mozilla/5.0 (iPad; CPU OS 5_0 like Mac OS X) AppleWebKit/534.46 (KHTML, like Gecko) Version/5.1 Mobile/9A334 Safari/7534.48.3";
            ha.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            ha.AddHeader("Accept-Language", "en-US,en;q=0.5");
            //指定有问题?只有第一次可以这样指定。
            ha.Referer = "http://" + universe + ".cicihappy.com/ogame/leftmenu.php";
            ha.Connection = "keep-alive";
            ha.IsUseCookie = true;
            return ha;
        }

        internal static OverviewInfo AnalyzHtml()
        {
            return null;
        }
    }
}
