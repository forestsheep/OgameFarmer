using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace GalaxyFarmer
{
    class MapInfo
    {

        #region xpath关键字
        private const string XPATH_GALAXY_CODE = "/html/body/center/table/tbody/tr/td[4]/form/input[2]";
        private const string XPATH_BALL1 = "/html/body/center/table/tbody/tr/td[2]/table/tbody/tr[";
        private const string XPATH_BALL2 = "]/th[3]";
        private const string XPATH_PLAYER1 = "/html/body/center/table/tbody/tr/td[2]/table/tbody/tr[";
        private const string XPATH_PLAYER2 = "]/th[6]/a";

        private const string XPATH_UNION1 = "/html/body/center/table/tbody/tr/td[2]/table/tbody/tr[";
        private const string XPATH_UNION2 = "]/th[7]/a";

        private const string XPATH_MOON1 = "/html/body/center/table/tbody/tr/td[2]/table/tbody/tr[";
        private const string XPATH_MOON2 = "]/th[4]/a";
        #endregion

        private const string PAGE_NAME = "galaxy.php?mode={0}";

        internal string GalaxyCode;

        internal MapInfo(MapCommander mapCommander)
        {

        }
        
        /// <summary>
        /// 第一次点下外部银河，用的是get来访问自己球所在的星系。并获取galaxycode
        /// </summary>
        internal void AccessSiteMyPlanet()
        {
            HttpAccesser ha = HttpAccesser.GetInstance();
            // mode = 0
            ha.AccessUrl = UrlUtil.GetUrl(String.Format(PAGE_NAME, "0"));
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            ha.Access();
        }

        /// <summary>
        /// 分析访问自己球所在的星系时取得的galaxycode
        /// </summary>
        internal void AnalyzResponseMyPlanet()
        {
            UnExpectPageController.Varify();
            HtmlAnalyzer htmlAnalyzer = new HtmlAnalyzer();
            htmlAnalyzer.Load();
            HtmlNode hn_code = htmlAnalyzer.AnalyzeNode(XPATH_GALAXY_CODE);
            this.GalaxyCode = hn_code.Attributes[2].Value;
            if (StringUtil.IsEmpty(this.GalaxyCode))
            {
                throw new CanContinueException();
            }
        }

        /// <summary>
        /// 访问星系图
        /// </summary>
        /// <param name="galaxy">银河</param>
        /// <param name="system">太阳系</param>
        internal void AccessSite(int galaxy, int system)
        {
            HttpAccesser ha = HttpAccesser.GetInstance();
            // mode = 1
            ha.AccessUrl = UrlUtil.GetUrl(String.Format(PAGE_NAME, "1"));
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            ha.UrlParam = "galaxyRight=dr&galaxy=" + galaxy + "&system=" + system + "&galaxycode=" + this.GalaxyCode;
            ha.Access();
        }

        internal List<BallStarMap> AnalyzResponse()
        {
            UnExpectPageController.Varify();
            List<BallStarMap> ballList = new List<BallStarMap>();
            HtmlAnalyzer htmlAnalyzer = new HtmlAnalyzer();
            // 分析本次的galaxycode，为下次做准备
            HtmlNode hn_code = htmlAnalyzer.AnalyzeNode(XPATH_GALAXY_CODE);
            this.GalaxyCode = hn_code.Attributes[2].Value;
            if (StringUtil.IsEmpty(this.GalaxyCode))
            {
                throw new CanContinueException();
            }
            // 循环15个球
            for (int i = 0; i <= 15; i++)
            {
                HtmlNode hn_player = htmlAnalyzer.AnalyzeNode(XPATH_PLAYER1 + (i + 3) + XPATH_PLAYER2, false);
                // 没有玩家，代表空位
                if (hn_player != null)
                {
                    BallStarMap ball = new BallStarMap();
                    ball.Player = hn_player.InnerText.Replace("&nbsp;", string.Empty).Trim();
                    HtmlNode hn_ball = htmlAnalyzer.AnalyzeNode(XPATH_BALL1 + (i + 3) + XPATH_BALL2, false);
                    if (hn_ball != null)
                    {
                        ball.Name = hn_ball.InnerText.Trim();
                    }
                    HtmlNode hn_union = htmlAnalyzer.AnalyzeNode(XPATH_UNION1 + (i + 3) + XPATH_UNION2, false);
                    if (hn_union != null)
                    {
                        ball.Union = hn_union.InnerText.Trim();
                    }
                    HtmlNode hn_moon = htmlAnalyzer.AnalyzeNode(XPATH_MOON1 + (i + 3) + XPATH_MOON2, false);
                    if (hn_moon != null)
                    {
                        ball.HasMoon = true;
                    }
                    else
                    {
                        ball.HasMoon = false;
                    }
                    //是否度假中
                    Regex rx = new Regex("\\(.*\\)");
                    Match m = rx.Match(hn_player.InnerText);
                    if (m.Value.Contains("u"))
                    {
                        ball.IsU = true;
                    }
                    else
                    {
                        ball.IsU = false;
                    }
                    ballList.Add(ball);
                }
            }
            return ballList;
        }

        internal static HttpAccesser PrepareHttpAccesser(string universe)
        {
            HttpAccesser ha = HttpAccesser.GetInstance();
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(universe);
            sb.Append(".cicihappy.com/ogame/galaxy.php?mode=0");
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
            ha.ContentType = "application/x-www-form-urlencoded";
            //ha.UrlParam = "galaxyRight=dr&galaxy=" + 1 + "&system=" + 1 + "&galaxycode=";
            return ha;
        }

        //internal static LocationsInfo[] AnalyzHtml()
        //{
        //    // 验证页面是否是未期待页面
        //    UnExpectPageController.Varify();

        //    LocationsInfo[] lis = new LocationsInfo[15];
        //    HtmlNode.ElementsFlags.Remove("form");
        //    HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
        //    h.Load(ConstString.HTML_PATH);

        //    for (int i = 0; i <= 15; i++)
        //    {
        //        HtmlNode hn_player = h.DocumentNode.SelectSingleNode(XPATH_PLAYER1 + (i + 3) + XPATH_PLAYER2);
        //        if (hn_player != null)
        //        {
        //            lis[i] = new LocationsInfo();
        //            lis[i].Player = hn_player.InnerText.Replace("&nbsp;", string.Empty).Trim();
        //            HtmlNode hn_ball = h.DocumentNode.SelectSingleNode(XPATH_BALL1 + (i + 3) + XPATH_BALL2);
        //            if (hn_ball != null)
        //            {
        //                lis[i].ballName = hn_ball.InnerText.Trim();
        //            }
        //            HtmlNode hn_union = h.DocumentNode.SelectSingleNode(XPATH_UNION1 + (i + 3) + XPATH_UNION2);
        //            if (hn_union != null)
        //            {
        //                lis[i].union = hn_union.InnerText.Trim();
        //            }
        //            HtmlNode hn_moon = h.DocumentNode.SelectSingleNode(XPATH_MOON1 + (i + 3) + XPATH_MOON2);
        //            if (hn_moon != null)
        //            {
        //                lis[i].HasMoon = true;
        //            }
        //            else 
        //            { 
        //                lis[i].HasMoon = false;
        //            }
        //            //是否度假中
        //            Regex rx = new Regex("\\(.*\\)");
        //            Match m = rx.Match(hn_player.InnerText);
        //            if (m.Value.Contains("u"))
        //            {
        //                lis[i].IsU = true;
        //            }
        //            else
        //            {
        //                lis[i].IsU = false;
        //            }
        //        }
        //    }
        //    HtmlNode hn_code = h.DocumentNode.SelectSingleNode(XPATH_GALAXY_CODE);
        //    //GALAXY_CODE = hn_code.Attributes[2].Value;
        //    return lis;
        //}
    }
}
