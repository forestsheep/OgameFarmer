using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
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

        /// <summary>
        /// 最大可动用舰队
        /// </summary>
        internal Fleet MaxActionableFleet;
        #endregion

        #region 实现接口方法
        public void AccessSite()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(StarScript.universe);
            sb.Append(".cicihappy.com/ogame/fleet.php");
            HttpAccesser httpAccesser = HttpAccesser.GetInstance();
            httpAccesser.AccessUrl = sb.ToString();
            httpAccesser.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            httpAccesser.Access();
        }

        public void AnalyzResponse()
        {
            // 验证页面是否是未期待页面
            UnExpectPageController.Varify();

            // 解析
            HtmlAnalyzer htmlAnalyzer = new HtmlAnalyzer();
            HtmlNode.ElementsFlags.Remove("option");
            HtmlNodeCollection hc = htmlAnalyzer.AnalyzeNodes(XPATH_FLEET_PARAM);

            // 储存
            foreach (HtmlNode hn in hc)
            {
                HtmlAttributeCollection hac = hn.Attributes;
                this.FleetParams.Add(hac[1].Value, hac[2].Value);
            }

            // 取得舰队可用总数等信息
            SetFleetQuantity();
        }
        #endregion

        #region 私有方法
        private void SetFleetQuantity()
        {
            this.MaxActionableFleet = new Fleet();
            foreach (DictionaryEntry de in this.FleetParams)
            {
                if (de.Key.Equals("maxship202"))
                {
                    this.MaxActionableFleet.IShip202.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship203"))
                {
                    this.MaxActionableFleet.IShip203.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship204"))
                {
                    this.MaxActionableFleet.IShip204.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship205"))
                {
                    this.MaxActionableFleet.IShip205.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship206"))
                {
                    this.MaxActionableFleet.IShip206.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship207"))
                {
                    this.MaxActionableFleet.IShip207.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship208"))
                {
                    this.MaxActionableFleet.IShip208.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship209"))
                {
                    this.MaxActionableFleet.IShip209.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship210"))
                {
                    this.MaxActionableFleet.IShip210.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship211"))
                {
                    this.MaxActionableFleet.IShip211.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship213"))
                {
                    this.MaxActionableFleet.IShip213.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship214"))
                {
                    this.MaxActionableFleet.IShip214.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship203"))
                {
                    this.MaxActionableFleet.IShip203.Quantity = int.Parse((string)de.Value);
                }
                else if (de.Key.Equals("maxship215"))
                {
                    this.MaxActionableFleet.IShip215.Quantity = int.Parse((string)de.Value);
                }
            }
        }
        #endregion
    }
}
