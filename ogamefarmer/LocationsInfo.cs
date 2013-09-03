using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace OgameFarmer
{
    class LocationsInfo : BaseInfo
    {

        private const string XPATH_GALAXY_CODE = "/html/body/center/table/tbody/tr/td[4]/form/input[2]";
        private const string XPATH_BALL1 = "/html/body/center/table/tbody/tr/td[2]/table/tbody/tr[";
        private const string XPATH_BALL2 = "]/th[3]";
        private const string XPATH_PLAYER1 = "/html/body/center/table/tbody/tr/td[2]/table/tbody/tr[";
        private const string XPATH_PLAYER2 = "]/th[6]/a";

        internal static string GALAXY_CODE;

        private string ballName;

        public string BallName
        {
            get { return ballName; }
            set { ballName = value; }
        }

        private string ballStatus;

        public string BallStatus
        {
            get { return ballStatus; }
            set { ballStatus = value; }
        }

        private string hasMoon;

        public string HasMoon
        {
            get { return hasMoon; }
            set { hasMoon = value; }
        }

        private string player;

        public string Player
        {
            get { return player; }
            set { player = value; }
        }

        private string playerStatus;

        public string PlayerStatus
        {
            get { return playerStatus; }
            set { playerStatus = value; }
        }

        private string location;

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        private string fxMetal;

        public string FxMetal
        {
            get { return fxMetal; }
            set { fxMetal = value; }
        }

        private string fxCrystal;

        public string FxCrystal
        {
            get { return fxCrystal; }
            set { fxCrystal = value; }
        }

        private string union;

        public string Union
        {
            get { return union; }
            set { union = value; }
        }

        internal static HttpAccesser PrepareHttpAccesser(string universe)
        {
            HttpAccesser ha = new HttpAccesser();
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

        internal static LocationsInfo[] AnalyzHtml()
        {
            LocationsInfo[] lis = new LocationsInfo[15];
            HtmlNode.ElementsFlags.Remove("form");
            HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
            h.Load(Strings.HTML_PATH);

            for (int i = 0; i <= 15; i++)
            {
                HtmlNode hn_player = h.DocumentNode.SelectSingleNode(XPATH_PLAYER1 + (i + 3) + XPATH_PLAYER2);
                if (hn_player != null)
                {
                    lis[i] = new LocationsInfo();
                    lis[i].Player = hn_player.InnerText.Replace("&nbsp;", string.Empty);
                    HtmlNode hn_ball = h.DocumentNode.SelectSingleNode(XPATH_BALL1 + (i + 3) + XPATH_BALL2);
                    if (hn_ball != null)
                    {
                        lis[i].ballName = hn_ball.InnerText;
                    }
                }
            }
            HtmlNode hn_code = h.DocumentNode.SelectSingleNode(XPATH_GALAXY_CODE);
            GALAXY_CODE = hn_code.Attributes[2].Value;
            return lis;
        }

    }
}
