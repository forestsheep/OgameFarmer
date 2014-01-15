using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class LoginInfoX : PageInfo
    {
        private LoginCommander loginCommander;

        internal LoginInfoX(LoginCommander loginCommander)
        {
            this.loginCommander = loginCommander;
        }

        public void AccessSite()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(loginCommander.Messager.ReqUniverse);
            sb.Append(".cicihappy.com/ogame/login.php");
            HttpAccesser ha = HttpAccesser.GetInstance();
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            ha.Host = loginCommander.Messager.ReqUniverse + ".cicihappy.com";
            ha.UserAgent = "Mozilla/5.0 (iPad; CPU OS 5_0 like Mac OS X) AppleWebKit/534.46 (KHTML, like Gecko) Version/5.1 Mobile/9A334 Safari/7534.48.3";
            ha.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            ha.AddHeader("Accept-Language", "en-US,en;q=0.5");
            ha.Referer = "http://www.cicihappy.com/";
            ha.Connection = "keep-alive";
            ha.ContentType = "application/x-www-form-urlencoded";
            ha.IsUseCookie = true;
            ha.AddCookie("pgv_pvi", "6115632128", "/", ".cicihappy.com", "2038年1月18日 8:00:00");
            ha.AddCookie("pgv_si", "s1617598464", "/", ".cicihappy.com", null);
            ha.UrlParam = "v=2&username=" + loginCommander.Messager.ReqLoginName + "&password=" + loginCommander.Messager.ReqPassword + "&universe=" + loginCommander.Messager.ReqUniverse + ".cicihappy.com";
            ha.Access();
        }

        public void AnalyzResponse() 
        {
            UnExpectPageController.Varify();

            HtmlAnalyzer htmlAnalyzer = new HtmlAnalyzer();
            htmlAnalyzer.Load();
            HtmlNode hn_login = htmlAnalyzer.AnalyzeNode("//*[@id=\"ogameframe\"]", false);
            if (hn_login == null)
            {
                this.loginCommander.Messager.ResIsLoginSuccess = false;
            }
            else
            {
                if ("rows".Equals(hn_login.Attributes[0].Name))
                {
                    this.loginCommander.Messager.ResIsLoginSuccess = true;
                }
                else
                {
                    this.loginCommander.Messager.ResIsLoginSuccess = false;
                }
            }
        }
    }
}
