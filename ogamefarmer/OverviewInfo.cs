using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace OgameFarmer
{
    class OverviewInfo : CommonInfo
    {

        //internal static string XPATH_METAL = "";
        //internal static string XPATH_METAL = "";
        //internal static string XPATH_METAL = "";
        //internal static string XPATH_METAL = "";
        //internal static string XPATH_METAL = "";
        //internal static string XPATH_METAL = "";
        //internal static string XPATH_METAL = "";
        //internal static string XPATH_METAL = "";
        //internal static string XPATH_METAL = "";
        //internal static string XPATH_METAL = "";


        internal static HttpAccesser PrepareHttpAccesser()
        {
            HttpAccesser ha = new HttpAccesser();

            StringBuilder sb = new StringBuilder();
            sb.Append("http://u7.cicihappy.com/ogame/overview.php");
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            ha.Host = "u7.cicihappy.com";
            ha.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:22.0) Gecko/20100101 Firefox/22.0";
            ha.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            ha.AddHeader("Accept-Language", "en-US,en;q=0.5");
            ha.Referer = "http://u7.cicihappy.com/ogame/leftmenu.php";
            ha.Connection = "keep-alive";
            ha.IsUseCookie = true;

            return ha;
        }

        internal static OverviewInfo AnalyzHtml()
        {
            OverviewInfo ovf = new OverviewInfo();
            
            HtmlAgilityPack.HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
            h.Load(Strings.HTML_PATH);
            
            //当前球的名字
            HtmlNode hn_ballname = h.DocumentNode.SelectSingleNode(XPATH_BALL_NAME);
            ovf.CurrentBallName = hn_ballname.InnerText;
            //当前金属存量
            HtmlNode hn_metal = h.DocumentNode.SelectSingleNode(XPATH_METAL);
            ovf.Metal = hn_metal.InnerText;
            //金属仓库
            HtmlNode hn_metalstore = h.DocumentNode.SelectSingleNode(XPATH_METAL_STORE);
            ovf.MetalStore = hn_metalstore.InnerText;
            //当前晶体存量
            HtmlNode hn_crystal = h.DocumentNode.SelectSingleNode(XPATH_CRYSTAL);
            ovf.Crystal = hn_crystal.InnerText;
            //晶体仓库
            HtmlNode hn_crystal_store = h.DocumentNode.SelectSingleNode(XPATH_CRYSTAL_STORE);
            ovf.CrystalStore = hn_crystal_store.InnerText;
            //当前重氢存量
            HtmlNode hn_h = h.DocumentNode.SelectSingleNode(XPATH_H);
            ovf.H = hn_h.InnerText;
            //重氢仓库
            HtmlNode hn_hstore = h.DocumentNode.SelectSingleNode(XPATH_H_STROE);
            ovf.HStore = hn_hstore.InnerText;
            //当前能量
            HtmlNode hn_energy = h.DocumentNode.SelectSingleNode(XPATH_ENERGY);
            ovf.Energy = hn_energy.InnerText;
            //总能量
            HtmlNode hn_energystore = h.DocumentNode.SelectSingleNode(XPATH_ENERGY_STROE);
            ovf.EnergyStroe = hn_energystore.InnerText;
            return ovf;
        }

    }
}
