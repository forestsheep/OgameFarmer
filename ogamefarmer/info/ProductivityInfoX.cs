using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace GalaxyFarmer
{
    class ProductivityInfoX : PageInfo
    {
        #region const

        #region xpath关键字
        private const string XPATH_METAL = "//*[@id=\"metalx\"]";
        private const string XPATH_METAL_STORE = "/html/body/div[2]/center/table[2]/tbody/tr/td[2]/table/tbody/tr[4]/td";
        private const string XPATH_CRYSTAL = "//*[@id=\"crystalx\"]";
        private const string XPATH_CRYSTAL_STORE = "/html/body/div[2]/center/table[2]/tbody/tr/td[2]/table/tbody/tr[4]/td[2]";
        private const string XPATH_H = "//*[@id=\"deuteriumx\"]";
        private const string XPATH_H_STROE = "/html/body/div[2]/center/table[2]/tbody/tr/td[2]/table/tbody/tr[4]/td[3]";
        private const string XPATH_ENERGY = "/html/body/div[2]/center/table[2]/tbody/tr/td[2]/table/tbody/tr[3]/td[4]";
        private const string XPATH_ENERGY_STROE = "/html/body/div[2]/center/table[2]/tbody/tr/td[2]/table/tbody/tr[4]/td[4]";
        private const string XPATH_METAL_HOUR = "/html/body/center/table/tr/td[1]/table/tbody/tr[4]/th[2]/font/font";
        private const string XPATH_CRYSTAL_HOUR = "/html/body/center/table/tr/td[1]/table/tbody/tr[5]/th[3]/font/font";
        private const string XPATH_H_HOUR = "/html/body/center/table/tr/td[1]/table/tbody/tr[6]/th[4]/font/font";
        private const string XPATH_SOLAR_BASE_HOUR = "/html/body/center/table/tr/td[1]/table/tbody/tr[7]/th[5]/font/font";
        private const string XPATH_SOLAR_SATELLITE_HOUR = "/html/body/center/table/tr/td[1]/table/tbody/tr[8]/th[5]/font/font";
        #endregion

        private const string PAGE_NAME = "resources.php";

        #endregion

        private ProductivityCommander producitivityCommander;
        internal ProductivityInfoX(ProductivityCommander producitivityCommander)
        {
            this.producitivityCommander = producitivityCommander;
        }

        public void AnalyzBalls()
        {
            List<BallProductivity> bps = new List<BallProductivity>();
            foreach (BallProductivity bp in producitivityCommander.Messager.BallProductivityList)
            {
                AccessByBall(bp.Prama);
                BallProductivity bpcopy = bp;
                AnalyzByBall(ref bpcopy);
                bps.Add(bpcopy);
            }
            producitivityCommander.Messager.BallProductivityList = bps;
        }

        public void AccessByBall(string ballPram)
        {
            HttpAccesser ha = HttpAccesser.GetInstance();
            ha.AccessUrl = UrlUtil.GetUrl(PAGE_NAME + ballPram);
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            ha.Access();
        }

        public void AccessSite()
        {
            AccessByBall("");
        }

        public void AnalyzByBall(ref BallProductivity bp)
        {
            UnExpectPageController.Varify();
            HtmlAnalyzer htmlAnalyzer = new HtmlAnalyzer();
            htmlAnalyzer.Load();
            // 当前金属存量
            HtmlNode hn_metal = htmlAnalyzer.AnalyzeNode(XPATH_METAL);
            bp.Metal = StringUtil.CommaNumberToInt(hn_metal.InnerText);
            // 金属仓库
            HtmlNode hn_metalstore = htmlAnalyzer.AnalyzeNode(XPATH_METAL_STORE);
            bp.MetalStore = StringUtil.CommaNumberToInt(hn_metalstore.InnerText);
            // 当前晶体存量
            HtmlNode hn_crystal = htmlAnalyzer.AnalyzeNode(XPATH_CRYSTAL);
            bp.Crystal = StringUtil.CommaNumberToInt(hn_crystal.InnerText);
            // 晶体仓库
            HtmlNode hn_crystal_store = htmlAnalyzer.AnalyzeNode(XPATH_CRYSTAL_STORE);
            bp.CrystalStore = StringUtil.CommaNumberToInt(hn_crystal_store.InnerText);
            // 当前重氢存量
            HtmlNode hn_h = htmlAnalyzer.AnalyzeNode(XPATH_H);
            bp.HH = StringUtil.CommaNumberToInt(hn_h.InnerText);
            // 重氢仓库
            HtmlNode hn_hstore = htmlAnalyzer.AnalyzeNode(XPATH_H_STROE);
            bp.HHStore = StringUtil.CommaNumberToInt(hn_hstore.InnerText);
            //当前能量
            HtmlNode hn_energy = htmlAnalyzer.AnalyzeNode(XPATH_ENERGY);
            bp.Energy = StringUtil.CommaNumberToInt(hn_energy.InnerText);
            //总能量
            HtmlNode hn_energystore = htmlAnalyzer.AnalyzeNode(XPATH_ENERGY_STROE);
            bp.EnergyStroe = StringUtil.CommaNumberToInt(hn_energystore.InnerText);

            HtmlNode.ElementsFlags.Remove("tr");
            HtmlNode.ElementsFlags.Remove("td");
            
            // 金属产量
            HtmlNode hn_metalp = htmlAnalyzer.AnalyzeNodeIgnore(XPATH_METAL_HOUR);
            if (hn_metalp == null)
            {
                bp.MetalHour = 0;
            }
            else
            {
                bp.MetalHour = StringUtil.CommaNumberToInt(hn_metalp.InnerText);
            }

            // 晶体产量
            HtmlNode hn_crystalp = htmlAnalyzer.AnalyzeNodeIgnore(XPATH_CRYSTAL_HOUR);
            if (hn_crystalp == null)
            {
                bp.CrystalHour = 0;
            }
            else
            {
                bp.CrystalHour = StringUtil.CommaNumberToInt(hn_crystalp.InnerText);
            }

            // 重氢产量
            HtmlNode hn_hp = htmlAnalyzer.AnalyzeNodeIgnore(XPATH_H_HOUR);
            if (hn_hp == null)
            {
                bp.HHHour = 0;
            }
            else
            {
                bp.HHHour = StringUtil.CommaNumberToInt(hn_hp.InnerText);
            }

            //太阳能（基地）

            //太阳能（卫星）
        }

        public void AnalyzResponse()
        {

        }

        internal static ProductivityInfo AnalyzHtml()
        {
            // 验证页面是否是未期待页面
            UnExpectPageController.Varify();

            ProductivityInfo pi = new ProductivityInfo();
            HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
            HtmlNode.ElementsFlags.Remove("option");
            h.Load(ConstString.HTML_PATH);
            return null;
            //星球列表
            //HtmlNode hn_ball = h.DocumentNode.SelectSingleNode(XPATH_BALL_NAME);
            //foreach (HtmlNode hn in hn_ball.ChildNodes)
            //{
                //if ("option".Equals(hn.Name))
                //{
                //    Ball ball = new Ball();
                //    Regex rx = new Regex("\\w*(?=\\&nbsp;)");
                //    Match m = rx.Match(hn.InnerText);
                //    if (m.Value != null)
                //    {
                //        ball.Name = m.Value;
                //    }
                //    else
                //    {
                //        ball.Name = "Unknow";
                //    }
                //    rx = new Regex("(?<=\\&nbsp;\\[).*(?=\\]\\&nbsp;\\&nbsp;)");
                //    m = rx.Match(hn.InnerText);
                //    if (m.Value != null)
                //    {
                        //ball.Location = m.Value;
                    //}
                    //else
                    //{
                        //ball.Location = "0:0:0";
                    //}
                    
                    
                    //foreach (HtmlAttribute ha in hn.Attributes)
                    //{
                    //    if ("value".Equals(ha.Name))
                    //    {
                    //        //ball.AccessParm = ha.Value.Replace("&amp;","&");
                    //    }
                    //}
                    //pi.Balllist.Add(ball);
            //    }
            //}

            //当前球的名字
            //HtmlNode hn_ballname = h.DocumentNode.SelectSingleNode(XPATH_BALL_NAME);
            //Regex rr = new Regex("\"(\\w*)\"");
            //Match mm = rr.Match(hn_ballname.InnerText);
            //pi.CurrentBallName = mm.Groups[1].Value;
            //当前金属存量
            //HtmlNode hn_metal = h.DocumentNode.SelectSingleNode(XPATH_METAL);
            //pi.Metal = CommaNumberToInt(hn_metal.InnerText);
            ////金属仓库
            //HtmlNode hn_metalstore = h.DocumentNode.SelectSingleNode(XPATH_METAL_STORE);
            //pi.MetalStore = CommaNumberToInt(hn_metalstore.InnerText);
            ////当前晶体存量
            //HtmlNode hn_crystal = h.DocumentNode.SelectSingleNode(XPATH_CRYSTAL);
            //pi.Crystal = CommaNumberToInt(hn_crystal.InnerText);
            ////晶体仓库
            //HtmlNode hn_crystal_store = h.DocumentNode.SelectSingleNode(XPATH_CRYSTAL_STORE);
            //pi.CrystalStore = CommaNumberToInt(hn_crystal_store.InnerText);
            ////当前重氢存量
            //HtmlNode hn_h = h.DocumentNode.SelectSingleNode(XPATH_H);
            //pi.H = CommaNumberToInt(hn_h.InnerText);
            ////重氢仓库
            //HtmlNode hn_hstore = h.DocumentNode.SelectSingleNode(XPATH_H_STROE);
            //pi.HStore = CommaNumberToInt(hn_hstore.InnerText);
            ////当前能量
            //HtmlNode hn_energy = h.DocumentNode.SelectSingleNode(XPATH_ENERGY);
            //pi.Energy = CommaNumberToInt(hn_energy.InnerText);
            ////总能量
            //HtmlNode hn_energystore = h.DocumentNode.SelectSingleNode(XPATH_ENERGY_STROE);
            //pi.EnergyStroe = CommaNumberToInt(hn_energystore.InnerText);

            //HtmlNode.ElementsFlags.Remove("tr");
            //HtmlNode.ElementsFlags.Remove("td");
            ////金属产量
            //HtmlNode hn_metalp = h.DocumentNode.SelectSingleNode(XPATH_METAL_HOUR);
            //if (hn_metalp == null)
            //{
            //    pi.MetalHour = 0;
            //}
            //else
            //{
            //    pi.MetalHour = CommaNumberToInt(hn_metalp.InnerText);
            //}

            //晶体产量
            //HtmlNode hn_crystalp = h.DocumentNode.SelectSingleNode(XPATH_CRYSTAL_HOUR);
            //if (hn_crystalp == null)
            //{
            //    pi.CrystalHour = 0;
            //}
            //else
            //{
            //    pi.CrystalHour = CommaNumberToInt(hn_crystalp.InnerText);
            //}

            ////重氢产量
            //HtmlNode hn_hp = h.DocumentNode.SelectSingleNode(XPATH_H_HOUR);
            //if (hn_hp == null)
            //{
            //    pi.HHour = 0;
            //}
            //else
            //{
            //    pi.HHour = CommaNumberToInt(hn_hp.InnerText);
            //}
            ////太阳能（基地）

            ////太阳能（卫星）

            //return pi;
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
