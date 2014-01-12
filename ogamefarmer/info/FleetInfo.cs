using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Threading;

namespace GalaxyFarmer
{
    class FleetInfo : CommonInfo
    {
        #region 常量
        internal const string XPATH_FLEET_PARAM = "/html/body/center/table/tr/td/center[2]/input";
        internal const string XPATH_FLOTEN1_PARAM = "/html/body/center/input";
        internal const string XPATH_FLOTEN2_PARAM = "/html/body/center/center/input";
        #endregion
        
        #region 属性
        /// <summary>
        /// 舰队页面返回的属性
        /// </summary>
        internal Hashtable FleetParams;
        /// <summary>
        /// 发舰队第一个页面返回的属性
        /// </summary>
        internal Hashtable Floten1Params;
        /// <summary>
        /// 发舰队第二个页面返回的属性
        /// </summary>
        internal Hashtable Floten2Params;

        //internal Hashtable floten3Params;

        /// <summary>
        /// 可出发最大化舰队，一只虚拟的舰队。出发的舰队数量必须控制在这支虚拟舰队之下。
        /// </summary>
        internal Fleet MaxActionableFleet;
     
        /// <summary>
        /// 出征任务
        /// </summary>
        internal FleetMission FleetMission;
        #endregion

        internal static void SendFleet(HttpAccesser ha)
        {
            ha = PerpareHttpAccesserFleet(ha);
            ha.Access();
            Thread.Sleep(2000);
            FleetInfo fleetInfo = AnalyzHtmlFleet();
            //// 测试 发出所有可能行动的舰队
            // 测试 发间谍卫星探险
            Fleet f = new Fleet();
            f.IShip210.Quantity = 1;
            //ha = PerpareHttpAccesserFloten1(ha, fleetInfo, fleetInfo.MaxActionableFleet);
            ha = PerpareHttpAccesserFloten1(ha, fleetInfo, f);
            ha.Access();
            Thread.Sleep(2000);
            fleetInfo = AnalyzHtmlFloten1(fleetInfo);
            //TODO 添加一个舰队任务的内容
            Coordinate dest = new Coordinate(4, 336, 8);
            fleetInfo.FleetMission = new FleetMission(fleetInfo.MaxActionableFleet, dest, CoordinateType.MOON, dest, CoordinateType.PLANET,10,MissionType.TRANSPORT,1,1,1,0,0,0);
            //Coordinate depart = new Coordinate(4, 336, 7);
            //Coordinate dest = new Coordinate(4, 336, 16);
            //TODO 第一次加过了舰队，第二次又加了mission，里面又有舰队。
            //fleetInfo.FleetMission = new FleetMission(fleetInfo.MaxActionableFleet, depart, CoordinateType.PLANET, dest, CoordinateType.PLANET, 10, MissionType.EXPEDITION, 1, 1, 1, 0, 1, 0);
            ha = PerpareHttpAccesserFloten2(ha, fleetInfo, fleetInfo.FleetMission);
            ha.Access();
            Thread.Sleep(2000);
            fleetInfo = AnalyzHtmlFloten2(fleetInfo);
            ha = PerpareHttpAccesserFloten3(ha, fleetInfo);
            ha.Access();
            Thread.Sleep(2000);
            AnalyzHtmlFloten3(fleetInfo);
            Thread.Sleep(10000);
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

        private static HttpAccesser PerpareHttpAccesserFloten1(HttpAccesser ha, FleetInfo fleetInfo, Fleet sendingFleet)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(StarScript.universe);
            sb.Append(".cicihappy.com/ogame/floten1.php");
            ha.AccessUrl = sb.ToString();
            //ha.Referer = "http://u8.cicihappy.com/ogame/fleet.php";
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
            foreach (DictionaryEntry de in fleetInfo.Floten2Params)
            {
                if (i != 0)
                {
                    ha.UrlParam += "&";
                }
                ha.UrlParam += de.Key.ToString() + "=" + de.Value.ToString();
                i++;
            }

            foreach (DictionaryEntry de in fleetInfo.Floten1Params)
            {
                // 如果不用页面返回的thisgalaxy等值，而是自己设定，便不需要切换一下星球，重新去看别的星球的
                // fleet页面？当然这只是为了现在的简便，以后还是应该看，只是现在切换的话要传星球的参数
                if (de.Key.Equals("thisgalaxy") || de.Key.Equals("thissystem") || de.Key.Equals("thisplanet") || de.Key.Equals("thisplanettype") || de.Key.Equals("usedfleet") || de.Key.Equals("speedfactor") || de.Key.Equals("speedallsmin") || de.Key.Equals("curepedition") || de.Key.ToString().StartsWith("ship2"))
                {
                    ha.UrlParam += "&" + de.Key.ToString() + "=" + de.Value.ToString();
                    i++;
                }
            }
            foreach (DictionaryEntry de in fleetInfo.FleetParams)
            {
                if (de.Key.Equals("maxepedition"))
                {
                    ha.UrlParam += "&" + de.Key.ToString() + "=" + de.Value.ToString();
                    i++;
                }
            }
            //资源为0可以只传变量名
            ha.UrlParam += FleetUtil.PullShipFloten1ParamsToFloten3(fleetInfo);
            ha.UrlParam += "&resource1=0&resource2=0&resource3=0";
            ha.UrlParam += "&mission=15";
            ha.UrlParam += "&expeditiontime=1";
            return ha;
        }

        private static FleetInfo AnalyzHtmlFleet()
        {
            // 验证页面是否是未期待页面
            UnExpectPageController.Varify();

            // 取得舰队页面的参数，用来在发舰队页面1中使用
            FleetInfo fleetInfo = new FleetInfo();
            fleetInfo.FleetParams = new Hashtable();
            HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
            HtmlNode.ElementsFlags.Remove("option");
            h.Load(ConstString.HTML_PATH);
            HtmlNodeCollection fleetParams = h.DocumentNode.SelectNodes(XPATH_FLEET_PARAM);
            foreach (HtmlNode hn in fleetParams)
            {
                HtmlAttributeCollection hac = hn.Attributes;
                fleetInfo.FleetParams.Add(hac[1].Value, hac[2].Value);
            }
            // 取得舰队可用总数等信息
            SetFleetQuantity(ref fleetInfo);
            return fleetInfo;
        }

        private static FleetInfo AnalyzHtmlFloten1(FleetInfo fleetInfo)
        {
            // 验证页面是否是未期待页面
            UnExpectPageController.Varify();

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

        private static void AnalyzHtmlFloten3(FleetInfo fleetInfo)
        {
            // 验证页面是否是未期待页面
            UnExpectPageController.Varify();
        }

        private static void SetFleetQuantity(ref FleetInfo fleetInfo)
        {
            fleetInfo.MaxActionableFleet = new Fleet();
            foreach (DictionaryEntry de in fleetInfo.FleetParams)
            {
                if (de.Key.Equals("maxship202"))
                {
                    fleetInfo.MaxActionableFleet.IShip202.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship203"))
                {
                    fleetInfo.MaxActionableFleet.IShip203.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship204"))
                {
                    fleetInfo.MaxActionableFleet.IShip204.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship205"))
                {
                    fleetInfo.MaxActionableFleet.IShip205.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship206"))
                {
                    fleetInfo.MaxActionableFleet.IShip206.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship207"))
                {
                    fleetInfo.MaxActionableFleet.IShip207.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship208"))
                {
                    fleetInfo.MaxActionableFleet.IShip208.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship209"))
                {
                    fleetInfo.MaxActionableFleet.IShip209.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship210"))
                {
                    fleetInfo.MaxActionableFleet.IShip210.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship211"))
                {
                    fleetInfo.MaxActionableFleet.IShip211.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship213"))
                {
                    fleetInfo.MaxActionableFleet.IShip213.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship214"))
                {
                    fleetInfo.MaxActionableFleet.IShip214.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship203"))
                {
                    fleetInfo.MaxActionableFleet.IShip203.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship215"))
                {
                    fleetInfo.MaxActionableFleet.IShip215.Quantity = int.Parse((string)de.Value);
                }
            }

        }


    }
}
