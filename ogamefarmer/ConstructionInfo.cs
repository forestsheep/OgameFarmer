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
            ConstructionInfo ci = new ConstructionInfo();
            HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
            h.Load(Strings.HTML_PATH);
            //当前金属矿
            int firstN = 0;
            for (int i = 2; i < 8; i++)
            {
                HtmlNode hn_metal = h.DocumentNode.SelectSingleNode(string.Format(XPATH_CONSTRUCTION + "/a", i));
                if (hn_metal != null && "金属矿".Equals(hn_metal.InnerText.Trim()))
                {
                    firstN = i;
                    break;
                }
            }
            if (firstN != 0)
            {
                for (int j = firstN; true; j++)
                {
                    HtmlNode hn_con = h.DocumentNode.SelectSingleNode(string.Format(XPATH_CONSTRUCTION, j));
                    if (hn_con == null)
                    {
                        break;
                    }
                    else
                    {
                        Construction c = new Construction();
                        c.innerText = hn_con.InnerText;
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
        internal int nextCystal = 0;
        internal bool canbuild = false;

        public override string ToString()
        {
            return innerText;
        }
    }
}
