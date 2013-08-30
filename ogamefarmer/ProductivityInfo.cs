using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace OgameFarmer
{
    class ProductivityInfo : CommonInfo
    {
        internal static string XPATH_BALL_NAME = "/html/body/center/table/tr/td[1]/table/tbody/tr/td";
        internal static string XPATH_METAL_HOUR = "/html/body/center/table/tr/td[1]/table/tbody/tr[4]/th[2]/font/font";
        internal static string XPATH_CRYSTAL_HOUR = "/html/body/center/table/tr/td[1]/table/tbody/tr[5]/th[3]/font/font";
        internal static string XPATH_H_HOUR = "/html/body/center/table/tr/td[1]/table/tbody/tr[6]/th[4]/font/font";
        internal static string XPATH_SOLAR_BASE_HOUR = "/html/body/center/table/tr/td[1]/table/tbody/tr[7]/th[5]/font/font";
        internal static string XPATH_SOLAR_SATELLITE_HOUR = "/html/body/center/table/tr/td[1]/table/tbody/tr[8]/th[5]/font/font";

        internal static HttpAccesser PrepareHttpAccesser(string universe)
        {
            HttpAccesser ha = new HttpAccesser();
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(universe);
            sb.Append(".cicihappy.com/ogame/resources.php");
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

        internal static ProductivityInfo AnalyzHtml()
        {
            ProductivityInfo pi = new ProductivityInfo();
            
            HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
            
            HtmlNode.ElementsFlags.Remove("option");
            h.Load(Strings.HTML_PATH);
            
            //星球列表
            HtmlNode hn_ball = h.DocumentNode.SelectSingleNode(XPATH_BALL_LIST);
            foreach (HtmlNode hn in hn_ball.ChildNodes)
            {
                if ("option".Equals(hn.Name))
                {
                    Ball ball = new Ball();
                    Regex rx = new Regex("\\w*(?=\\&nbsp;)");
                    Match m = rx.Match(hn.InnerText);
                    if (m.Value != null)
                    {
                        ball.Name = m.Value;
                    }
                    else
                    {
                        ball.Name = "Unknow";
                    }
                    rx = new Regex("(?<=\\&nbsp;\\[).*(?=\\]\\&nbsp;\\&nbsp;)");
                    m = rx.Match(hn.InnerText);
                    if (m.Value != null)
                    {
                        ball.Location = m.Value;
                    }
                    else
                    {
                        ball.Location = "0:0:0";
                    }
                    
                    
                    foreach (HtmlAttribute ha in hn.Attributes)
                    {
                        if ("value".Equals(ha.Name))
                        {
                            ball.AccessParm = ha.Value.Replace("&amp;","&");
                        }
                    }
                    pi.Balllist.Add(ball);
                }
            }

            //当前球的名字
            HtmlNode hn_ballname = h.DocumentNode.SelectSingleNode(XPATH_BALL_NAME);
            Regex rr = new Regex("\"(\\w*)\"");
            Match mm = rr.Match(hn_ballname.InnerText);
            pi.CurrentBallName = mm.Groups[1].Value;
            //当前金属存量
            HtmlNode hn_metal = h.DocumentNode.SelectSingleNode(XPATH_METAL);
            pi.Metal = ToInt(hn_metal.InnerText);
            //金属仓库
            HtmlNode hn_metalstore = h.DocumentNode.SelectSingleNode(XPATH_METAL_STORE);
            pi.MetalStore = ToInt(hn_metalstore.InnerText);
            //当前晶体存量
            HtmlNode hn_crystal = h.DocumentNode.SelectSingleNode(XPATH_CRYSTAL);
            pi.Crystal = ToInt(hn_crystal.InnerText);
            //晶体仓库
            HtmlNode hn_crystal_store = h.DocumentNode.SelectSingleNode(XPATH_CRYSTAL_STORE);
            pi.CrystalStore = ToInt(hn_crystal_store.InnerText);
            //当前重氢存量
            HtmlNode hn_h = h.DocumentNode.SelectSingleNode(XPATH_H);
            pi.H = ToInt(hn_h.InnerText);
            //重氢仓库
            HtmlNode hn_hstore = h.DocumentNode.SelectSingleNode(XPATH_H_STROE);
            pi.HStore = ToInt(hn_hstore.InnerText);
            //当前能量
            HtmlNode hn_energy = h.DocumentNode.SelectSingleNode(XPATH_ENERGY);
            pi.Energy = ToInt(hn_energy.InnerText);
            //总能量
            HtmlNode hn_energystore = h.DocumentNode.SelectSingleNode(XPATH_ENERGY_STROE);
            pi.EnergyStroe = ToInt(hn_energystore.InnerText);

            HtmlNode.ElementsFlags.Remove("tr");
            HtmlNode.ElementsFlags.Remove("td");
            //金属产量
            HtmlNode hn_metalp = h.DocumentNode.SelectSingleNode(XPATH_METAL_HOUR);
            if (hn_metalp == null)
            {
                pi.MetalHour = 0;
            }
            else
            {
                pi.MetalHour = ToInt(hn_metalp.InnerText);
            }

            //晶体产量
            HtmlNode hn_crystalp = h.DocumentNode.SelectSingleNode(XPATH_CRYSTAL_HOUR);
            if (hn_crystalp == null)
            {
                pi.CrystalHour = 0;
            }
            else
            {
                pi.CrystalHour = ToInt(hn_crystalp.InnerText);
            }

            //重氢产量
            HtmlNode hn_hp = h.DocumentNode.SelectSingleNode(XPATH_H_HOUR);
            if (hn_hp == null)
            {
                pi.HHour = 0;
            }
            else
            {
                pi.HHour = ToInt(hn_hp.InnerText);
            }
            //太阳能（基地）

            //太阳能（卫星）

            return pi;
        }

        public static int ToInt(string number)
        {
            string n = number.Replace(",", string.Empty);
            int i = 0;
            try
            {
                i = int.Parse(n);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return i;
        }

        private int metalHour;

        public int MetalHour
        {
            get { return metalHour; }
            set { metalHour = value; }
        }

        private int crystalHour;

        public int CrystalHour
        {
            get { return crystalHour; }
            set { crystalHour = value; }
        }

        private int hHour;

        public int HHour
        {
            get { return hHour; }
            set { hHour = value; }
        }

        private int solorBaseHour;

        internal int SolorBaseHour
        {
            get { return solorBaseHour; }
            set { solorBaseHour = value; }
        }

        private int solorSTHour;

        internal int SolorSTHour
        {
            get { return solorSTHour; }
            set { solorSTHour = value; }
        }

    }
}
