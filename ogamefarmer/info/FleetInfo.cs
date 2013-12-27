using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Threading;

namespace OgameFarmer
{
    class FleetInfo : CommonInfo
    {
        internal static string XPATH_FLEET_PARAM = "/html/body/center/table/tr/td/center[2]/input";
        internal static string XPATH_FLOTEN1_PARAM = "/html/body/center/input";
        internal static string XPATH_FLOTEN2_PARAM = "/html/body/center/center/input";

        internal static void SendFleet(HttpAccesser ha)
        {
            ha = PerpareHttpAccesserFleet(ha);
            ha.access();
            Thread.Sleep(2000);
            FleetInfo fleetInfo = AnalyzHtmlFleet();
            // 测试 发出所有可能行动的舰队
            ha = PerpareHttpAccesserFloten1(ha, fleetInfo, fleetInfo.MaxActionableFleet);
            ha.access();
            Thread.Sleep(2000);
            fleetInfo = AnalyzHtmlFloten1(fleetInfo);
			Fleet.Ship202.id = "ship202";
			System.Windows.Forms.MessageBox.Show (Fleet.Ship203.id);
            // todo 添加一个舰队任务的内容
			//FleetMission fleetMission = new FleetMission();
			//fleetMission.Destination = new Coordinate(1,1,1);
			//ha = PerpareHttpAccesserFloten2(ha, fleetInfo, fleetMission);
            ha.access();
            Thread.Sleep(2000);
            fleetInfo = AnalyzHtmlFloten2(fleetInfo);
            ha = PerpareHttpAccesserFloten3(ha, fleetInfo);
            ha.access();
            Thread.Sleep(2000);
            AnalyzHtmlFloten3(fleetInfo);
        }

        private static HttpAccesser PerpareHttpAccesserFleet(HttpAccesser ha)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(StarScript.universe);
            sb.Append(".cicihappy.com/ogame/fleet.php");
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            return ha;
        }

        private static HttpAccesser PerpareHttpAccesserFloten1(HttpAccesser ha, FleetInfo fleetInfo, Fleet sendingFleet )
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(StarScript.universe);
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
            
            ha.UrlParam += FleetQuantityUtil.FleetQuantity2PostParam(sendingFleet);
            return ha;
        }

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

        private static HttpAccesser PerpareHttpAccesserFloten3(HttpAccesser ha, FleetInfo fleetInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(StarScript.universe);
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

        private static FleetInfo AnalyzHtmlFleet()
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
            // 取得舰队可用总数等信息
            SetFleetQuantity(ref fleetInfo);
            return fleetInfo;
        }

        private static FleetInfo AnalyzHtmlFloten1(FleetInfo fleetInfo)
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

        private static FleetInfo AnalyzHtmlFloten2(FleetInfo fleetInfo)
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

        private static void AnalyzHtmlFloten3(FleetInfo fleetInfo)
        {
            // 验证页面是否是未期待页面
            string htmlTxt = Txtout.Read();
            UnExpectPageController upc = UnExpectPageController.GetInstance();
            upc.VarifyCookiePeriod(htmlTxt);
        }

        private static void SetFleetQuantity(ref FleetInfo fleetInfo)
        {
            fleetInfo.MaxActionableFleet = new Fleet();
            foreach (DictionaryEntry de in fleetInfo.fleetParams)
            {
                if (de.Key.Equals("maxship202"))
                {
                    fleetInfo.MaxActionableFleet.ship202.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship203"))
                {
                    fleetInfo.MaxActionableFleet.ship203.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship204"))
                {
                    fleetInfo.MaxActionableFleet.ship204.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship205"))
                {
                    fleetInfo.MaxActionableFleet.ship205.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship206"))
                {
                    fleetInfo.MaxActionableFleet.ship206.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship207"))
                {
                    fleetInfo.MaxActionableFleet.ship207.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship208"))
                {
                    fleetInfo.MaxActionableFleet.ship208.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship209"))
                {
                    fleetInfo.MaxActionableFleet.ship209.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship210"))
                {
                    fleetInfo.MaxActionableFleet.ship210.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship211"))
                {
                    fleetInfo.MaxActionableFleet.ship211.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship213"))
                {
                    fleetInfo.MaxActionableFleet.ship213.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship214"))
                {
                    fleetInfo.MaxActionableFleet.ship214.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship203"))
                {
                    fleetInfo.MaxActionableFleet.ship203.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship215"))
                {
                    fleetInfo.MaxActionableFleet.ship215.Quantity = int.Parse((string)de.Value);
                }
            }

        }
        
        private Hashtable fleetParams;
        private Hashtable floten1Params;
        private Hashtable floten2Params;
        //internal Hashtable floten3Params;

        private Fleet maxActionableFleet;
        internal Fleet MaxActionableFleet
        {
            get
            {
                return maxActionableFleet;
            }
			set
			{
				maxActionableFleet = value;
			}
        }
    }
}
