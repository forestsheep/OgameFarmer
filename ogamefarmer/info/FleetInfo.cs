using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace OgameFarmer
{
    class FleetInfo : CommonInfo
    {
        internal static string XPATH_FLEET_PARAM = "/html/body/center/table/tr/td/center[2]/input";
        internal static string XPATH_FLOTEN1_PARAM = "/html/body/center/input";
        internal static string XPATH_FLOTEN2_PARAM = "/html/body/center/center/input";

        internal static HttpAccesser PerpareHttpAccesserFleet(HttpAccesser ha, string universe)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(universe);
            sb.Append(".cicihappy.com/ogame/fleet.php");
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            return ha;
        }

        internal static HttpAccesser PerpareHttpAccesserFloten1(HttpAccesser ha, string universe, FleetInfo fleetInfo )
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(universe);
            sb.Append(".cicihappy.com/ogame/floten1.php");
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            ha.UrlParam = string.Empty;
            int i = 0;
            foreach (DictionaryEntry de in fleetInfo.fleetParams)
            {
                if (i != 0)
                {
                    ha.UrlParam += "&";
                }
                ha.UrlParam += de.Key.ToString() + " = " + de.Value.ToString();
                i++;
            }
            ha.UrlParam += "&ship202=1";
            return ha;
        }

        internal static HttpAccesser PerpareHttpAccesserFloten2(HttpAccesser ha, string universe, FleetInfo fleetInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(universe);
            sb.Append(".cicihappy.com/ogame/floten2.php");
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            ha.UrlParam = string.Empty;
            int i = 0;
            foreach (DictionaryEntry de in fleetInfo.floten1Params)
            {
                if (i != 0)
                {
                    ha.UrlParam += "&";
                }
                ha.UrlParam += de.Key.ToString() + " = " + de.Value.ToString();
                i++;
            }
            ha.UrlParam += "&galaxy=2&system=401&planet=10&planettype=3&fleet_group=0&acs_target_mr=0:0:0&speed=10";
            return ha;
        }

        internal static HttpAccesser PerpareHttpAccesserFloten3(HttpAccesser ha, string universe, FleetInfo fleetInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(universe);
            sb.Append(".cicihappy.com/ogame/floten3.php");
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            int i = 0;
            ha.UrlParam = string.Empty;
            fleetInfo.floten2Params.Remove("thisgalaxy");
            fleetInfo.floten2Params.Remove("thissystem");
            fleetInfo.floten2Params.Remove("thisplanet");
            fleetInfo.floten2Params.Remove("thisplanettype");
            fleetInfo.floten2Params.Remove("usedfleet");
            fleetInfo.floten2Params.Remove("speedfactor");
            fleetInfo.floten2Params.Remove("dist");
            fleetInfo.floten2Params.Remove("speedallsmin");
            
            foreach (DictionaryEntry de in fleetInfo.floten2Params)
            {
                if (i != 0)
                {
                    ha.UrlParam += "&";
                }
                ha.UrlParam += de.Key.ToString() + "=" + de.Value.ToString();
                i++;
            }

            foreach (DictionaryEntry de in fleetInfo.floten1Params)
            {
                if (de.Key.Equals("thisgalaxy") || de.Key.Equals("thissystem") || de.Key.Equals("thisplanet") || de.Key.Equals("thisplanettype") || de.Key.Equals("usedfleet") || de.Key.Equals("speedfactor") || de.Key.Equals("speedallsmin"))
                {
                    ha.UrlParam += "&";
                    ha.UrlParam += de.Key.ToString() + "=" + de.Value.ToString();
                    i++;
                }
            }
            ha.UrlParam += "&mission=4&resource1=3&resource2=2&resource3=1&ship202=1&capacity202=5000&consumption202=10&speed202=8000&usedfleet=LGbkBagcBwVjZwgmBwR6VwRvB30=";
            return ha;
        }

        internal static FleetInfo AnalyzHtmlFleet()
        {
            // 验证页面是否是未期待页面
            string htmlTxt = Txtout.Read();
            UnExpectPageController upc = UnExpectPageController.GetInstance();
            upc.VarifyCookiePeriod(htmlTxt);

            // 取得舰队页面的参数，用来在发舰队页面1中使用
            FleetInfo fleetInfo = new FleetInfo();
            fleetInfo.fleetParams = new Hashtable();
            HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
            HtmlNode.ElementsFlags.Remove("option");
            h.Load(ConstString.HTML_PATH);
            HtmlNodeCollection fleetParams = h.DocumentNode.SelectNodes(XPATH_FLEET_PARAM);
            foreach (HtmlNode hn in fleetParams)
            {
                HtmlAttributeCollection hac = hn.Attributes;
                fleetInfo.fleetParams.Add(hac[1].Value, hac[2].Value);
            }
            return fleetInfo;
        }

        internal static FleetInfo AnalyzHtmlFloten1(FleetInfo fleetInfo)
        {
            // 验证页面是否是未期待页面
            string htmlTxt = Txtout.Read();
            UnExpectPageController upc = UnExpectPageController.GetInstance();
            upc.VarifyCookiePeriod(htmlTxt);

            HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
            fleetInfo.floten1Params = new Hashtable();
            HtmlNode.ElementsFlags.Remove("option");
            h.Load(ConstString.HTML_PATH);
            HtmlNodeCollection floten1Params = h.DocumentNode.SelectNodes(XPATH_FLOTEN1_PARAM);
            foreach (HtmlNode hn in floten1Params)
            {
                HtmlAttributeCollection hac = hn.Attributes;
                fleetInfo.floten1Params.Add(hac[1].Value, hac[2].Value);
            }
            return fleetInfo;
        }

        internal static FleetInfo AnalyzHtmlFloten2(FleetInfo fleetInfo)
        {
            // 验证页面是否是未期待页面
            string htmlTxt = Txtout.Read();
            UnExpectPageController upc = UnExpectPageController.GetInstance();
            upc.VarifyCookiePeriod(htmlTxt);

            HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
            fleetInfo.floten2Params = new Hashtable();
            HtmlNode.ElementsFlags.Remove("option");
            h.Load(ConstString.HTML_PATH);
            HtmlNodeCollection floten2Params = h.DocumentNode.SelectNodes(XPATH_FLOTEN2_PARAM);
            foreach (HtmlNode hn in floten2Params)
            {
                HtmlAttributeCollection hac = hn.Attributes;
                try
                {
                    fleetInfo.floten2Params.Add(hac[1].Value, hac[2].Value);
                }
                catch (ArgumentException ae)
                {
                    ae.ToString();
                }
            }
            return fleetInfo;
        }

        internal static void AnalyzHtmlFloten3(FleetInfo fleetInfo)
        {
            // 验证页面是否是未期待页面
            string htmlTxt = Txtout.Read();
            UnExpectPageController upc = UnExpectPageController.GetInstance();
            upc.VarifyCookiePeriod(htmlTxt);
        }
        internal Hashtable fleetParams;
        internal Hashtable floten1Params;
        internal Hashtable floten2Params;
        //internal Hashtable floten3Params;
    }
}
