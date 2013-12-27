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
using OgameFarmer.messager;

namespace OgameFarmer
{
    internal delegate void LoginMessageSender(LoginMessager mm);
    internal delegate void MainMessageSender(MainMessager mm);
    internal delegate void RankScanOverNoti(int overtype);
    internal delegate void ConstructionSender(ArrayList al);
    internal delegate void GalaxyScanNoti(int scanstatus);

    internal delegate void DefenceMessageSender(DefenceMessager defenceMessager);

    public class StarScript
    {
        private static LoginMessageSender LoginEventHandler;
        private static MainMessageSender MainEventHandler;
        private static RankScanOverNoti RankScanOverHandler;
        private static ConstructionSender ConstructionEventHandler;
        private static GalaxyScanNoti GalaxyScanEventHandler;
        private static DefenceMessageSender DefenceEventHandler;

        private static Thread T;

        private static HttpAccesser ha;
        private static ProductivityInfo pi;

        internal AllDefence defenceStrategy;

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
                    MessageBox.Show(ConstString.CANNOT_DO_MUTLTI_THINGS);
                    GalaxyScanEventHandler(-1);
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
            else if (id == 7)
            {
                T = new Thread(new ParameterizedThreadStart(SpendAllToDefence));
            }
            else if (id == 8)
            {
                T = new Thread(new ParameterizedThreadStart(FleetTest));
            }
            
        }

        private void homepage(object o)
        {
            StringBuilder sb = new StringBuilder();
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
            ha.access();
            Thread.Sleep(200);
        }

        internal void login(object o)
        {
            LoginMessager lm = new LoginMessager();
            ha = LoginInfo.PrepareHttpAccesser(universe, loginname, password);
            ha.access();
            lm.loginInfo = LoginInfo.AnalyzHtml();
            LoginEventHandler(lm);
            Thread.Sleep(200);
        }

        internal void overview(object o)
        {
            MainMessager mm = new MainMessager();
            ArrayList balls = new ArrayList();
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(universe);
            sb.Append(".cicihappy.com/ogame/overview.php");
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            string baseurl = ha.AccessUrl;
            ha.access();
            //取得第一个星球的总星球列表
            OverviewInfo ovf = OverviewInfo.AnalyzHtml();
            foreach (OverviewInfo.Ball ball in ovf.Balllist)
            {
                ha.AccessUrl = baseurl + ball.AccessParm;
                ha.access();
                //取得每一个星球
                OverviewInfo ovfloop = OverviewInfo.AnalyzHtml();
                balls.Add(ovfloop);
            }
            mm.ovf = ovf;
            mm.balls = balls;
            MainEventHandler(mm);
            Thread.Sleep(200);
            MainEventHandler(mm);
            Thread.Sleep(200);
        }

        internal void Productivity(object o)
        {
            MainMessager mm = new MainMessager();
            ArrayList balls = new ArrayList();
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(universe);
            sb.Append(".cicihappy.com/ogame/resources.php");
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            string baseurl = ha.AccessUrl;
            ha.access();
            //取得第一个星球的总星球列表
            pi = ProductivityInfo.AnalyzHtml();
            Thread.Sleep(5000);
            foreach (ProductivityInfo.Ball ball in pi.Balllist)
            {
                ha.AccessUrl = baseurl + ball.AccessParm;
                ha.access();
                //取得每一个星球
                ProductivityInfo piloop = ProductivityInfo.AnalyzHtml();
                balls.Add(piloop);
                mm.progressBarStep = 100 / pi.Balllist.Count;
                MainEventHandler(mm);
            }
            mm.progressBarStep = 0;
            Thread.Sleep(600);
            mm.productivityInfo = pi;
            MainEventHandler(mm);
            Thread.Sleep(200);
            mm.balls = balls;
            MainEventHandler(mm);
            Thread.Sleep(200);
        }

        internal void Construction(object o)
        {
            ArrayList balls = new ArrayList();
            //ha = ConstructionInfo.PrepareHttpAccesser(universe);
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(universe);
            sb.Append(".cicihappy.com/ogame/buildings.php");
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            string baseurl = ha.AccessUrl;
            foreach (ProductivityInfo.Ball ball in pi.Balllist)
            {
                ha.AccessUrl = baseurl + ball.AccessParm;
                ha.access();
                ha.Referer = baseurl;
                //取得每一个星球
                ConstructionInfo ciloop = ConstructionInfo.AnalyzHtml();
                ciloop.CurrentBallName = ball.Name;
                balls.Add(ciloop);
            }
            ConstructionEventHandler(balls);
        }

        internal void Locations(object o)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(universe);
            sb.Append(".cicihappy.com/ogame/galaxy.php?mode=0");
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            ha.access();
            LocationsInfo[] mylis = LocationsInfo.AnalyzHtml();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            ha.AccessUrl = "http://" + universe + ".cicihappy.com/ogame/galaxy.php?mode=1";
            ha.Referer = "http://" + universe + ".cicihappy.com/ogame/galaxy.php?mode=0";
            //Txtout.writeA("银河系,太阳系,行星,联盟,玩家,星球名,月球,度假\r\n", "balls.csv");
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;data source=rank.accdb";
            try
            {
                using (OleDbConnection dbc = new OleDbConnection(connStr))
                {
                    dbc.Open();
                    OleDbDataAdapter adp = new OleDbDataAdapter();
                    adp.SelectCommand = new OleDbCommand(@"select max([_id]) as maxid from scanprocess where not complete", dbc);
                    DataTable dt = new DataTable();
                    string processid = string.Empty;
                    bool usecontinue;
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0 && !dt.Rows[0][0].ToString().Equals(string.Empty))
                    {
                        usecontinue = true;
                        processid = dt.Rows[0][0].ToString();
                    }
                    else
                    {
                        usecontinue = false;
                    }
                    if (usecontinue)
                    {
                        //找到最后一次扫描的最后一个球的坐标 -- galaxy and solar index
                        adp.SelectCommand = new OleDbCommand(@"select top 1 galaxy, solar from 
    (select *,galaxy * 1000 + solar as xuhao from galaxymap where process = " + processid + @")t1 order by xuhao desc", dbc);
                        dt.Columns.Clear();
                        dt.Clear();
                        adp.Fill(dt);
                        int galaxyStart;
                        int solarStart;
                        if (dt.Rows.Count == 0)
                        {
                            galaxyStart = 1;
                            solarStart = 1;
                        }
                        else
                        {
                            galaxyStart = ProductivityInfo.ToInt(dt.Rows[0][0].ToString());
                            solarStart = ProductivityInfo.ToInt(dt.Rows[0][1].ToString());
                        }
                        //根据坐标继续扫描
                        GalaxyLoop(processid, galaxyStart, solarStart, adp, dbc);
                    }
                    else
                    {
                        //创建一个新的扫描过程
                        adp.InsertCommand = new OleDbCommand(@"insert into scanprocess (complete, cdate) values (false, now())", dbc);
                        adp.InsertCommand.ExecuteNonQuery();
                        adp.SelectCommand = new OleDbCommand(@"select max([_id]) as maxid from scanprocess where not complete", dbc);
                        dt.Columns.Clear();
                        dt.Clear();
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            processid = dt.Rows[0][0].ToString();
                            //从头扫描
                            GalaxyLoop(processid, 1, 1, adp, dbc);
                        }
                    }
                }
            }
            catch (System.InvalidOperationException ioe)
            {
                if (ioe.ToString().Contains("OLEDB"))
                {
                    MessageBox.Show(ConstString.suggest_db_conn_program_not_install);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        internal void Rank(object o)
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
                        ha.access();
                        RankInfo[] ris = RankInfo.AnalyzHtml();

                        for (int j = 0; j < ris.Length; j++)
                        {
                            if (ris[j] != null)
                            {
                                adp.InsertCommand = new OleDbCommand(@"insert into rank (rank,player,score,cdate) values ('" + ris[j].Rank + "','" + ris[j].User + "','" + ris[j].Score + "',now())", dbc);
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
                    MessageBox.Show(ConstString.suggest_db_conn_program_not_install);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            RankScanOverHandler(0);
        }

        private void GalaxyLoop(string processid, int galaxyStart, int solarStart, OleDbDataAdapter adp, OleDbConnection dbc)
        {
            bool firstScan = true;
            for (int yin = galaxyStart - 1; yin < 9; yin++)
            {
                //第一次不完整的扫描
                if (!firstScan)
                {
                    solarStart = 1;
                }
                for (int tai = solarStart; tai < 500; tai++)
                {
                    GalaxyScanEventHandler((yin + 1) * 10000 + tai);
                    ha.UrlParam = "galaxyRight=dr&galaxy=" + yin + "&system=" + tai + "&galaxycode=" + LocationsInfo.GALAXY_CODE;
                    ha.access();
                    // Issue #4 
                    try
                    {
                        LocationsInfo[] lis = LocationsInfo.AnalyzHtml();
                        for (int pnt = 0; pnt < lis.Length; pnt++)
                        {
                            if (lis[pnt] != null)
                            {
                                adp.InsertCommand = new OleDbCommand(@"insert into galaxymap (process, galaxy, solar, planet, punion, player, ballname, hasmoon, vacation, cdate) values ('" + processid + "','" + (yin + 1) + "','" + tai + "','" + (pnt + 1) + "','" + lis[pnt].Union + "','" + lis[pnt].Player + "','" + lis[pnt].BallName + "'," + (lis[pnt].HasMoon ? "true" : "false") + "," + (lis[pnt].IsU ? "true" : "false") + ", now())", dbc);
                                adp.InsertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (OgameFarmerException ofe)
                    {
                        MessageBox.Show(ofe.ToString());
                        return;
                    }
                }
                firstScan = false;
            }
            //扫描结束process打上结束符
            adp.InsertCommand = new OleDbCommand(@"update scanprocess set complete = true where [_id] =" + processid, dbc);
            adp.InsertCommand.ExecuteNonQuery();
            GalaxyScanEventHandler(0);
        }

        private void SpendAllToDefence(object o)
        {
            DefenceMessager dm = new DefenceMessager();
            dm.isBuildOver = false;
            ArrayList balls = new ArrayList();
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(universe);
            sb.Append(".cicihappy.com/ogame/resources.php");
            ha.AccessUrl = sb.ToString();
            string baseurl = ha.AccessUrl;
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            ha.access();
            //取得第一个星球的总星球列表
            pi = ProductivityInfo.AnalyzHtml();
            Thread.Sleep(3000);
            int i = 0;
            foreach (ProductivityInfo.Ball ball in pi.Balllist)
            {
                ha.AccessUrl = baseurl + ball.AccessParm;
                ha.access();
                //取得每一个星球
                ProductivityInfo piloop = ProductivityInfo.AnalyzHtml();
                dm.ballname = piloop.CurrentBallName;
                defenceStrategy.Metal = piloop.Metal;
                defenceStrategy.Crystal = piloop.Crystal;
                defenceStrategy.HH = piloop.H;

                defenceStrategy.PrepareAccess(ref ha, ball.AccessParm);
                Thread.Sleep(3000);
                defenceStrategy.MakeDefenceTower(ha, dm);
                Thread.Sleep(3000);
                dm.progress += 100 / pi.Balllist.Count;
                if (100 - dm.progress < 100 / pi.Balllist.Count)
                {
                    dm.progress = 100;
                }
                DefenceEventHandler(dm);
                i++;
                //if (i > 1)
                //{
                //    break;
                //}
            }
            dm.isBuildOver = true;
            DefenceEventHandler(dm);
        }

        private void FleetTest(object o)
        {
			//FleetInfo.SendFleet(ha);
			Console.WriteLine (Fleet.Ship202.id);
			System.Windows.Forms.MessageBox.Show (Fleet.Ship202.id);
			Console.WriteLine (Fleet.Ship203.id);
			System.Windows.Forms.MessageBox.Show (Fleet.Ship203.id);
        }

        internal event LoginMessageSender LoginEvent
        {
            add
            {
                LoginEventHandler += new LoginMessageSender(value);
            }
            remove
            {
                LoginEventHandler -= new LoginMessageSender(value);
            }
        }

        internal event MainMessageSender MainEvent
        {
            add
            {
                MainEventHandler += new MainMessageSender(value);
            }
            remove
            {
                MainEventHandler -= new MainMessageSender(value);
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

        internal event RankScanOverNoti Rsosender
        {
            add
            {
                RankScanOverHandler += new RankScanOverNoti(value);
            }
            remove
            {
                RankScanOverHandler -= new RankScanOverNoti(value);
            }
        }

        internal event GalaxyScanNoti GalaxyScanSender
        {
            add
            {
                GalaxyScanEventHandler += new GalaxyScanNoti(value);
            }
            remove
            {
                GalaxyScanEventHandler -= new GalaxyScanNoti(value);
            }
        }

        internal event DefenceMessageSender DefenceEvent
        {
            add
            {
                DefenceEventHandler += new DefenceMessageSender(value);
            }
            remove
            {
                DefenceEventHandler -= new DefenceMessageSender(value);
            }
        }
    }
}
