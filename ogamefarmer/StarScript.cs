using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Net;
using System.IO;

namespace OgameFarmer
{
    public delegate void MessageSender(string sParam);
    public delegate void ObjectSender(object o);
    internal class StarScript
    {
        private static MessageSender MessageEventHandler;

        private static ObjectSender ObjectEventHandler;

        private static Thread T;

        private static CookieContainer ccold;
        private static CookieCollection ccnew;

        internal StarScript()
        {
        }

        internal void run(object o)
        {
            if (T == null)
            {
                runSelector((int)o);
                T.Start(o);
            }
            else
            {
                if (ThreadState.Stopped == T.ThreadState)
                {
                    runSelector((int)o);
                    T.Start(o);
                }
                else
                {
                    MessageEventHandler("busy now" + "\r\n");
                }
            }
        }

        internal void runSelector(int id)
        {
            if (id == 1)
            {
                T = new Thread(new ParameterizedThreadStart(homepage));
            }
            else if (id == 2)
            {
                T = new Thread(new ParameterizedThreadStart(login));
            }
            else if (id == 3)
            {
                T = new Thread(new ParameterizedThreadStart(overview));
            }
            else if (id == 4)
            {
                T = new Thread(new ParameterizedThreadStart(logout));
            }
        }

        private void homepage(object o)
        {
            ccold = null;
            ccnew = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("http://www.cicihappy.com/");
            HttpAccesser ha = new HttpAccesser();
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            ha.Host = "www.cicihappy.com";
            ha.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:22.0) Gecko/20100101 Firefox/22.0";
            ha.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            ha.AddHeader("Accept-Language", "en-US,en;q=0.5");
            ha.Referer = "http://www.cicihappy.com/";
            ha.Connection = "keep-alive";
            ha.ContentType = "";
            ha.IsUseCookie = true;
            ha.AddHeader("Cache-Control", "max-age=0");
            ccold = ha.Cookies;
            ccnew = ha.access();
            Thread.Sleep(200);
        }

        internal static void login(object o)
        {
            ccold = null;
            ccnew = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("http://u7.cicihappy.com/ogame/login.php");
            HttpAccesser ha = new HttpAccesser();
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            ha.Host = "u7.cicihappy.com";
            ha.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:22.0) Gecko/20100101 Firefox/22.0";
            ha.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            ha.AddHeader("Accept-Language", "en-US,en;q=0.5");
            ha.Referer = "http://www.cicihappy.com/";
            ha.Connection = "keep-alive";
            ha.ContentType = "application/x-www-form-urlencoded";
            ha.IsUseCookie = true;
            ha.AddCookie("bd8e9_lastvisit", "1594%091376360967%09%2Findex.php", "/", "www.cicihappy.com", "Wed, 13-Aug-2014 02:29:27 GMT");
            ha.AddCookie("pgv_pvi", "6115632128", "/", ".cicihappy.com", "2038年1月18日 8:00:00");
            ha.AddCookie("pgv_si", "s1617598464", "/", ".cicihappy.com", null);
            ha.UrlParam = "v=2&username=boccaro&password=911911f911&universe=u7.cicihappy.com";
            ccold = ha.Cookies;
            ccnew = ha.access();
            LoginInfo li = LoginInfo.AnalyzHtml();
            ObjectEventHandler(li);
            Thread.Sleep(200);
        }

        internal static void overview(object o)
        {
            HttpAccesser ha = OverviewInfo.PrepareHttpAccesser();

            ha.Cookies = ccold;
            IEnumerator i = ccnew.GetEnumerator();
            while (i.MoveNext())
            {
                ha.Cookies.Add((Cookie)i.Current);
            }
            ccold = ha.Cookies;
            ccnew = ha.access();
            OverviewInfo ovf = OverviewInfo.AnalyzHtml();
            ObjectEventHandler(ovf);
            Thread.Sleep(200);
        }

        internal static void logout(object o)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("http://u7.cicihappy.com/ogame/buildings.php");
            HttpAccesser ha = new HttpAccesser();
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            ha.Host = "u7.cicihappy.com";
            ha.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:22.0) Gecko/20100101 Firefox/22.0";
            ha.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            ha.AddHeader("Accept-Language", "en-US,en;q=0.5");
            ha.Referer = "http://u7.cicihappy.com/ogame/leftmenu.php";
            ha.Connection = "keep-alive";
            ha.ContentType = "application/x-www-form-urlencoded";
            ha.IsUseCookie = true;
            //ha.Cookies = ccold;
            //IEnumerator i = ccnew.GetEnumerator();
            //while (i.MoveNext())
            //{
            //    ha.Cookies.Add((Cookie)i.Current);
            //}
            ccold = ha.Cookies;
            ccnew = ha.access();
            Thread.Sleep(200);
        }

        internal event MessageSender Login
        {
            add
            {
                MessageEventHandler += new MessageSender(value);
            }
            remove
            {
                MessageEventHandler -= new MessageSender(value);
            }
        }

        internal event ObjectSender Osender
        {
            add
            {
                ObjectEventHandler += new ObjectSender(value);
            }
            remove
            {
                ObjectEventHandler -= new ObjectSender(value);
            }
        }
    }
}
