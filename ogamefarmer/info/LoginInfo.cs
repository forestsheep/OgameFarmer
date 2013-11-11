using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class LoginInfo :BaseInfo
    {

        internal static HttpAccesser PrepareHttpAccesser(string universe, string loginname, string pw)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(universe);
            sb.Append(".cicihappy.com/ogame/login.php");
            HttpAccesser ha = new HttpAccesser();
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            ha.Host = universe + ".cicihappy.com";
            ha.UserAgent = "Mozilla/5.0 (iPad; CPU OS 5_0 like Mac OS X) AppleWebKit/534.46 (KHTML, like Gecko) Version/5.1 Mobile/9A334 Safari/7534.48.3";
            ha.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            ha.AddHeader("Accept-Language", "en-US,en;q=0.5");
            ha.Referer = "http://www.cicihappy.com/";
            ha.Connection = "keep-alive";
            ha.ContentType = "application/x-www-form-urlencoded";
            ha.IsUseCookie = true;
            //ha.AddCookie("bd8e9_lastvisit", "1594%091376360967%09%2Findex.php", "/", "www.cicihappy.com", "Wed, 13-Aug-2014 02:29:27 GMT");
            ha.AddCookie("pgv_pvi", "6115632128", "/", ".cicihappy.com", "2038年1月18日 8:00:00");
            ha.AddCookie("pgv_si", "s1617598464", "/", ".cicihappy.com", null);
            //ha.AddCookie("pgv_si", "s3797821440", "/", ".cicihappy.com", null);
            ha.UrlParam = "v=2&username=" + loginname +"&password=" + pw + "&universe=" + universe + ".cicihappy.com";
            return ha;
        }
        internal static LoginInfo AnalyzHtml()
        {
            LoginInfo li = new LoginInfo();
            HtmlAgilityPack.HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
            h.Load(ConstString.HTML_PATH);
            HtmlAgilityPack.HtmlNode hn_login = h.DocumentNode.SelectSingleNode("//*[@id=\"ogameframe\"]");
            if (hn_login == null)
            {
                li.LoginSuccess = false;
            }
            else
            {
                //if ("rows".Equals(hn_login.Attributes[0].Name) && "*,100".Equals(hn_login.Attributes[0].Value))
                if ("rows".Equals(hn_login.Attributes[0].Name))
                {
                    li.LoginSuccess = true;
                }
                else
                {
                    li.LoginSuccess = false;
                }
            }
            return li;
        }
    }
}
