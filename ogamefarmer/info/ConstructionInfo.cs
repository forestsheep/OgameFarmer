using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Collections;

namespace OgameFarmer
{
    class ConstructionInfo : CommonInfo
    {
        internal static string XPATH_CONSTRUCTION = "/html/body/center/table/tr/td/center/table/tr[{0:d}]/td[2]";

        private Construction metalMine;

        internal Construction MetalMine
        {
            get { return metalMine; }
            set { metalMine = value; }
        }

        internal static HttpAccesser PrepareHttpAccesser(string universe)
        {
            HttpAccesser ha = new HttpAccesser();
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(universe);
            sb.Append(".cicihappy.com/ogame/buildings.php");
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            ha.Host = universe + ".cicihappy.com";
            ha.UserAgent = "Mozilla/5.0 (iPad; CPU OS 5_0 like Mac OS X) AppleWebKit/534.46 (KHTML, like Gecko) Version/5.1 Mobile/9A334 Safari/7534.48.3";
            ha.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            ha.AddHeader("Accept-Language", "en-US,en;q=0.5");
            ha.Referer = "";
            ha.Connection = "keep-alive";
            ha.IsUseCookie = true;
            return ha;
        }

        internal ArrayList allCons = new ArrayList();
        internal static ConstructionInfo AnalyzHtml()
        {
            // 验证页面是否是未期待页面
            string htmlTxt = Txtout.Read();
            UnExpectPageController upc = UnExpectPageController.GetInstance();
            upc.VarifyCookiePeriod(htmlTxt);

            ConstructionInfo ci = new ConstructionInfo();
            HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
            h.Load(ConstString.HTML_PATH);
            //当前金属矿
            int firstN = 0;
            for (int i = 2; i < 8; i++)
            {
                HtmlNode hn_firstcon = h.DocumentNode.SelectSingleNode(string.Format(XPATH_CONSTRUCTION + "/a", i));
                if (hn_firstcon != null && ("金属矿".Equals(hn_firstcon.InnerText.Trim()) || "机器人工厂".Equals(hn_firstcon.InnerText.Trim())))
                {
                    firstN = i;
                    break;
                }
            }
            if (firstN != 0)
            {
                for (int j = firstN; true; j++)
                {
                    HtmlNode hn_con_name = h.DocumentNode.SelectSingleNode(string.Format(XPATH_CONSTRUCTION +"/a", j));
                    HtmlNode hn_con_next_1st = h.DocumentNode.SelectSingleNode(string.Format(XPATH_CONSTRUCTION + "/b[1]", j));
                    HtmlNode hn_con_next_2nd = h.DocumentNode.SelectSingleNode(string.Format(XPATH_CONSTRUCTION + "/b[2]", j));
                    HtmlNode hn_con_next_3rd = h.DocumentNode.SelectSingleNode(string.Format(XPATH_CONSTRUCTION + "/b[3]", j));

                    HtmlNode hn_con_need_1st = h.DocumentNode.SelectSingleNode(string.Format(XPATH_CONSTRUCTION + "/font/b[1]", j));
                    HtmlNode hn_con_need_2nd = h.DocumentNode.SelectSingleNode(string.Format(XPATH_CONSTRUCTION + "/font//b[2]", j));
                    HtmlNode hn_con_need_3rd = h.DocumentNode.SelectSingleNode(string.Format(XPATH_CONSTRUCTION + "/font//b[3]", j));

                    if (hn_con_name == null)
                    {
                        break;
                    }
                    else
                    {
                        Construction c = new Construction();
                        c.innerText = hn_con_name.InnerText;
                        //如果是地形改造器，则不需要金属。
                        if ("地形改造器".Equals(c.innerText.Trim()))
                        {
                            c.nextMetal = 0;
                            c.needMetal = 0;
                            if (hn_con_next_1st != null)
                            {
                                c.nextCrystal = ProductivityInfo.ToInt(hn_con_next_1st.InnerText);
                            }
                            if (hn_con_next_2nd != null)
                            {
                                c.nextH = ProductivityInfo.ToInt(hn_con_next_2nd.InnerText);
                            }
                            if (hn_con_need_1st != null)
                            {
                                c.needCrystal = ProductivityInfo.ToInt(hn_con_need_1st.InnerText);
                            }
                            if (hn_con_need_2nd != null)
                            {
                                c.needH = ProductivityInfo.ToInt(hn_con_need_2nd.InnerText);
                            }
                        }
                        else
                        {
                            if (hn_con_next_1st != null)
                            {
                                c.nextMetal = ProductivityInfo.ToInt(hn_con_next_1st.InnerText);
                            }
                            if (hn_con_next_2nd != null)
                            {
                                c.nextCrystal = ProductivityInfo.ToInt(hn_con_next_2nd.InnerText);
                            }
                            if (hn_con_next_3rd != null)
                            {
                                c.nextH = ProductivityInfo.ToInt(hn_con_next_3rd.InnerText);
                            }
                            if (hn_con_need_1st != null)
                            {
                                c.needMetal = ProductivityInfo.ToInt(hn_con_need_1st.InnerText);
                            }
                            if (hn_con_need_2nd != null)
                            {
                                c.needCrystal = ProductivityInfo.ToInt(hn_con_need_2nd.InnerText);
                            }
                            if (hn_con_need_3rd != null)
                            {
                                c.needH = ProductivityInfo.ToInt(hn_con_need_3rd.InnerText);
                            }
                        }
                        ci.allCons.Add(c);
                    }
                }
            }
            return ci;
        }
        public override string ToString()
        {
            return this.CurrentBallName;
        }
    }

    class Construction
    {
        internal string innerText;
        internal int level = 0;
        internal int nextMetal = 0;
        internal int nextCrystal = 0;
        internal int nextH = 0;
        internal int needMetal = 0;
        internal int needCrystal = 0;
        internal int needH = 0;
        internal bool canbuild = false;

        public override string ToString()
        {
            return innerText;
        }
    }
}
