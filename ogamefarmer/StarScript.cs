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
    internal delegate void MessageSender(string sParam);
    internal delegate void ObjectSender(object o);
    internal class StarScript
    {
        private static MessageSender MessageEventHandler;

        private static ObjectSender ObjectEventHandler;

        private static Thread T;

        private static CookieContainer ccold;
        private static CookieCollection ccnew;
        private static string referer;

        internal static string loginname;
        internal static string password;
        internal static string universe;

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
                T = new Thread(new ParameterizedThreadStart(Productivity));
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
            HttpAccesser ha = LoginInfo.PrepareHttpAccesser(universe, loginname, password);
            ccold = ha.Cookies;
            ccnew = ha.access();
            LoginInfo li = LoginInfo.AnalyzHtml();
            ObjectEventHandler(li);
            Thread.Sleep(200);
        }

        internal static void overview(object o)
        {
            ArrayList balls = new ArrayList();
            HttpAccesser ha = OverviewInfo.PrepareHttpAccesser(universe);
            string baseurl = ha.AccessUrl;
            ha.Cookies = ccold;
            IEnumerator i = ccnew.GetEnumerator();
            while (i.MoveNext())
            {
                ha.Cookies.Add((Cookie)i.Current);
            }
            ccold = ha.Cookies;
            ccnew = ha.access();
            //取得第一个星球的总星球列表
            OverviewInfo ovf = OverviewInfo.AnalyzHtml();

            foreach (OverviewInfo.Ball ball in ovf.Balllist)
            {
                ha.Referer = ha.AccessUrl;
                ha.AccessUrl = baseurl + ball.AccessParm;
                ha.Cookies = ccold;
                IEnumerator ie = ccnew.GetEnumerator();
                while (ie.MoveNext())
                {
                    ha.Cookies.Add((Cookie)ie.Current);
                }
                ccnew = ha.access();
                //取得每一个星球
                OverviewInfo ovfloop = OverviewInfo.AnalyzHtml();
                balls.Add(ovfloop);
            }
            referer = ha.AccessUrl;
            ObjectEventHandler(ovf);
            Thread.Sleep(200);
            ObjectEventHandler(balls);
            Thread.Sleep(200);
        }

        internal static void Productivity(object o)
        {
            ArrayList balls = new ArrayList();
            HttpAccesser ha = ProductivityInfo.PrepareHttpAccesser(universe);
            ha.Referer = referer;
            string baseurl = ha.AccessUrl;
            ha.Cookies = ccold;
            IEnumerator i = ccnew.GetEnumerator();
            while (i.MoveNext())
            {
                ha.Cookies.Add((Cookie)i.Current);
            }
            ccold = ha.Cookies;
            ccnew = ha.access();
            //取得第一个星球的总星球列表
            ProductivityInfo pi = ProductivityInfo.AnalyzHtml();

            foreach (ProductivityInfo.Ball ball in pi.Balllist)
            {
                ha.Referer = ha.AccessUrl;
                ha.AccessUrl = baseurl + ball.AccessParm;
                ha.Cookies = ccold;
                IEnumerator ie = ccnew.GetEnumerator();
                while (ie.MoveNext())
                {
                    ha.Cookies.Add((Cookie)ie.Current);
                }
                ccnew = ha.access();
                //取得每一个星球
                ProductivityInfo piloop = ProductivityInfo.AnalyzHtml();
                balls.Add(piloop);
            }
            referer = ha.AccessUrl;
            ObjectEventHandler(pi);
            Thread.Sleep(200);
            ObjectEventHandler(balls);
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
