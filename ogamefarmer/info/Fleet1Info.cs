using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class Fleet1Info : PageInfo
    {
        #region const
        internal const string XPATH_FLEET_PARAM = "/html/body/center/table/tr/td/center[2]/input";
        #endregion

        #region 属性
        /// <summary>
        /// 舰队页面返回的属性
        /// </summary>
        internal Hashtable FleetParams;
        #endregion

        #region 实现接口方法
        public void AccessSite(ref HttpAccesser httpAccesser)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(StarScript.universe);
            sb.Append(".cicihappy.com/ogame/fleet.php");
            httpAccesser.AccessUrl = sb.ToString();
            httpAccesser.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            httpAccesser.Access();
        }

        public void AnalyzResponse()
        {
            // 验证页面是否是未期待页面
            string htmlTxt = Txtout.Read();
            UnExpectPageController upc = UnExpectPageController.GetInstance();
            upc.VarifyCookiePeriod(htmlTxt);

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
            //return fleetInfo;
        }
        #endregion

        #region 私有方法
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
        #endregion
    }
}
