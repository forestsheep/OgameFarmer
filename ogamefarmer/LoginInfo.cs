using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class LoginInfo :BaseInfo
    {
        internal static LoginInfo AnalyzHtml()
        {
            LoginInfo li = new LoginInfo();
            HtmlAgilityPack.HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
            h.Load(Strings.HTML_PATH);
            HtmlAgilityPack.HtmlNode hn_login = h.DocumentNode.SelectSingleNode("//*[@id=\"ogameframe\"]");
            if ("rows".Equals(hn_login.Attributes[0].Name) && "*,100".Equals(hn_login.Attributes[0].Value))
            {
                li.LoginSuccess = true;
            }
            else
            {
                li.LoginSuccess = false;
            }
            return li;
        }
    }
}
