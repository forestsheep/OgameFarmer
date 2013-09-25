using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class RankInfo : BaseInfo
    {
        private const string XPATH_RANK1 = "/html/body/center/center/table/tr/td/table/tr[";
        private const string XPATH_RANK2 = "]/th[1]";

        private const string XPATH_PLAYER1 = "/html/body/center/center/table/tr/td/table/tr[";
        private const string XPATH_PLAYER2= "]/th[3]";


        private const string XPATH_SCORE1 = "/html/body/center/center/table/tr/td/table/tr[";
        private const string XPATH_SCORE2 = "]/th[6]";

        private string user;
        internal string User
        {
            get { return user; }
            set { user = value; }
        }

        private int score;
        internal int Score
        {
            get { return score; }
            set { score = value; }
        }

        private int rank;
        internal int Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        internal static HttpAccesser PrepareHttpAccesser(HttpAccesser ha, string universe, int range)
        {
            if (ha == null)
            {
                ha = new HttpAccesser();
            }
            //指定有问题?只有第一次可以这样指定。
            if (ha.AccessUrl == null)
            {
                ha.Referer = "http://" + universe + ".cicihappy.com/ogame/leftmenu.php";
            }
            else
            {
                ha.Referer = ha.AccessUrl;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(universe);
            sb.Append(".cicihappy.com/ogame/stat.php?range=1");
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            ha.Host = universe + ".cicihappy.com";
            ha.UserAgent = "Mozilla/5.0 (iPad; CPU OS 5_0 like Mac OS X) AppleWebKit/534.46 (KHTML, like Gecko) Version/5.1 Mobile/9A334 Safari/7534.48.3";
            ha.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            ha.AddHeader("Accept-Language", "en-US,en;q=0.5");
            ha.Connection = "keep-alive";
            ha.IsUseCookie = true;
            ha.ContentType = "application/x-www-form-urlencoded";
            ha.UrlParam = "whochange=0&typechange=0&rangechange=1&who=1&type=1&range=" + range;
            return ha;
        }

        internal static RankInfo[] AnalyzHtml()
        {
            RankInfo[] ris = new RankInfo[100];
            
            HtmlAgilityPack.HtmlDocument h = new HtmlAgilityPack.HtmlDocument();

            h.Load(Strings.HTML_PATH);
            for (int i = 0; i < 100; i++)
            {
                ris[i] = new RankInfo();
                HtmlAgilityPack.HtmlNode hn_user = h.DocumentNode.SelectSingleNode(XPATH_PLAYER1 + (i + 2) + XPATH_PLAYER2);
                HtmlAgilityPack.HtmlNode hn_score = h.DocumentNode.SelectSingleNode(XPATH_SCORE1 + (i + 2) + XPATH_SCORE2);
                HtmlAgilityPack.HtmlNode hn_rank = h.DocumentNode.SelectSingleNode(XPATH_RANK1 + (i + 2) + XPATH_RANK2);

                ris[i].User = hn_user.InnerText;
                ris[i].Score = ProductivityInfo.ToInt(hn_score.InnerText);
                ris[i].Rank = ProductivityInfo.ToInt(hn_rank.InnerText);
            }
            return ris;
        }
    }
}
