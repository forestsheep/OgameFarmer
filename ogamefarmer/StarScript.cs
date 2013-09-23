using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Net;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace OgameFarmer
{
    internal delegate void MessageSender(int sParam);
    internal delegate void ObjectSender(object o);
    internal delegate void ConstructionSender(ArrayList al);
    internal class StarScript
    {
        private static MessageSender MessageEventHandler;

        private static ObjectSender ObjectEventHandler;

        private static ConstructionSender ConstructionEventHandler;

        private static Thread T;

        private static HttpAccesser ha;
        private static CookieContainer ccold;
        private static CookieCollection ccnew;
        private static string referer;
        private static ProductivityInfo pi;

        internal static string loginname;
        internal static string password;
        internal static string universe;

        internal static int yinhe;

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
                    MessageEventHandler(111);
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
                T = new Thread(new ParameterizedThreadStart(Construction));
            }
            else if (id == 5)
            {
                T = new Thread(new ParameterizedThreadStart(Locations));
            }
            else if (id == 6)
            {
                T = new Thread(new ParameterizedThreadStart(Rank));
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
            ha = LoginInfo.PrepareHttpAccesser(universe, loginname, password);
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
            pi = ProductivityInfo.AnalyzHtml();

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
                MessageEventHandler(100 / pi.Balllist.Count);
            }
            Thread.Sleep(600);
            referer = ha.AccessUrl;
            ObjectEventHandler(pi);
            Thread.Sleep(200);
            ObjectEventHandler(balls);
            Thread.Sleep(200);
        }

        internal static void Construction(object o)
        {
            ArrayList balls = new ArrayList();
            HttpAccesser ha = ConstructionInfo.PrepareHttpAccesser(universe);
            ha.Referer = referer;
            string baseurl = ha.AccessUrl;
            //ha.Cookies = ccold;
            //IEnumerator i = ccnew.GetEnumerator();
            //while (i.MoveNext())
            //{
            //    ha.Cookies.Add((Cookie)i.Current);
            //}
            //ccold = ha.Cookies;
            //ccnew = ha.access();

            foreach (ProductivityInfo.Ball ball in pi.Balllist)
            {
                ha.AccessUrl = baseurl + ball.AccessParm;
                ha.Cookies = ccold;
                IEnumerator ie = ccnew.GetEnumerator();
                while (ie.MoveNext())
                {
                    ha.Cookies.Add((Cookie)ie.Current);
                }
                ccnew = ha.access();
                ha.Referer = baseurl;
                //取得每一个星球
                ConstructionInfo ciloop = ConstructionInfo.AnalyzHtml();
                ciloop.CurrentBallName = ball.Name;
                balls.Add(ciloop);
            }
            referer = ha.AccessUrl;
            ConstructionEventHandler(balls);
        }

        internal static void Locations(object o)
        {
            HttpAccesser ha = LocationsInfo.PrepareHttpAccesser(universe);
            //ha.Referer = referer;
            ha.Cookies = ccold;
            IEnumerator i = ccnew.GetEnumerator();
            while (i.MoveNext())
            {
                ha.Cookies.Add((Cookie)i.Current);
            }
            ccold = ha.Cookies;
            ccnew = ha.access();
            LocationsInfo[] mylis = LocationsInfo.AnalyzHtml();

            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            ha.AccessUrl = "http://" + universe + ".cicihappy.com/ogame/galaxy.php?mode=1";
            ha.Referer = "http://" + universe + ".cicihappy.com/ogame/galaxy.php?mode=0";
            Txtout.writeA("银河系,太阳系,行星,联盟,玩家,星球名,月球\r\n", "balls.csv");
            for (int yin = yinhe; yin == yinhe; yin++)
            {
                for (int tai = 1; tai < 500; tai++)
                {
                    ha.UrlParam = "galaxyRight=dr&galaxy=" + yin + "&system=" + tai + "&galaxycode=" + LocationsInfo.GALAXY_CODE;

                    ha.Cookies = ccold;
                    IEnumerator ii = ccnew.GetEnumerator();
                    while (ii.MoveNext())
                    {
                        ha.Cookies.Add((Cookie)ii.Current);
                    }
                    ccold = ha.Cookies;
                    ccnew = ha.access();
                    LocationsInfo[] lis = LocationsInfo.AnalyzHtml();
                    for (int dd = 0; dd < lis.Length; dd++)
                    {
                        if (lis[dd] != null)
                        {
                            Txtout.writeA((yin + 1) + "," + tai + "," + (dd + 1) + "," + lis[dd].Union + "," + lis[dd].Player + "," + lis[dd].BallName + "," + lis[dd].HasMoon + "\r\n", "balls.csv");
                        }
                    }
                }
            }
            //ObjectEventHandler(lis);
            //Thread.Sleep(200);
        }

        internal static void Rank1(object o)
        {
            for (int c = 0; c < 15; c++)
            {
                ha = RankInfo.PrepareHttpAccesser(StarScript.ha, universe, c * 100 + 1);
                ha.Cookies = ccold; 
                IEnumerator i = ccnew.GetEnumerator();
                while (i.MoveNext())
                {
                    ha.Cookies.Add((Cookie)i.Current);
                }
                ccold = ha.Cookies;
                ccnew = ha.access();
                RankInfo[] ris = RankInfo.AnalyzHtml();

                for (int j = 0; j < ris.Length; j++)
                {
                    if (ris[j] != null)
                    {
                        Txtout.writeA(c * 100 + j + 1 + "," + ris[j].User + "," + ris[j].Score + "\r\n", "rank.csv");
                    }
                }
            }
        }

        internal static void Rank(object o)
        {
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;data source=rank.accdb";
            try
            {
                using (OleDbConnection dbc = new OleDbConnection(connStr))
                {
                    dbc.Open();
                    DataSet ds = new DataSet();
                    OleDbDataAdapter adp = new OleDbDataAdapter();

                    for (int c = 0; c < 15; c++)
                    {
                        ha = RankInfo.PrepareHttpAccesser(StarScript.ha, universe, c * 100 + 1);
                        ha.Cookies = ccold;
                        IEnumerator i = ccnew.GetEnumerator();
                        while (i.MoveNext())
                        {
                            ha.Cookies.Add((Cookie)i.Current);
                        }
                        ccold = ha.Cookies;
                        ccnew = ha.access();
                        RankInfo[] ris = RankInfo.AnalyzHtml();

                        for (int j = 0; j < ris.Length; j++)
                        {
                            if (ris[j] != null)
                            {
                                adp.InsertCommand = new OleDbCommand(@"insert into rank (player,score,cdate) values ('" + ris[j].User + "','" + ris[j].Score + "',now())", dbc);
                                adp.InsertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (System.InvalidOperationException ioe)
            {
                if (ioe.ToString().Contains("OLEDB"))
                {
                    MessageBox.Show("您很有可能未安装数据库连接程序，建议下载并安装：\r\ndownload.microsoft.com/download/7/0/3/703ffbcb-dc0c-4e19-b0da-1463960fdcdb/AccessDatabaseEngine.exe");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

        internal event MessageSender Msger
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

        internal event ConstructionSender Csender
        {
            add
            {
                ConstructionEventHandler += new ConstructionSender(value);
            }
            remove
            {
                ConstructionEventHandler -= new ConstructionSender(value);
            }
        }
        
    }
}
