using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace OgameFarmer
{
    public partial class Main : Form
    {
        private StarScript ss;
        private OverviewInfo info;
        private ProductivityInfo pi;
        private ArrayList balls;
        private ArrayList oballs = new ArrayList();

        #region 构造函数
        internal Main(StarScript ss)
        {
            InitializeComponent();
            this.ss = ss;
            this.ss.Osender += this.OnObjectRecived;
            this.ss.Msger += this.OnMessageRecived;
        }
        #endregion

        #region 事件
        System.Timers.Timer autoLoginTimer = new System.Timers.Timer();
        private void Main_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            //Panel p2 = new Panel();
            //Label ll2 = new Label();
            //ll2.Text = "123123123";
            //p2.Width = 500;
            //p2.Height = 500;
            //p2.Left = 10;
            //p2.Top = 10;
            //p2.Visible = true;
            ////p2.AutoSize = true;
            //this.Controls.Add(p2);
            //p2.BackColor = Color.Green;
            //p2.Show();
        }

        protected void TextShow(object sender, EventArgs e)
        {
        }

        protected void ShowInfo(object sender, EventArgs e)
        {
            if (info != null)
            {
                l_ballname.Text = info.CurrentBallName;
                l_metal.Text = string.Format("{0:N0}", info.Metal);
                
                l_metalstroe.Text = string.Format("{0:N0}", info.MetalStore);
                l_crystal.Text = string.Format("{0:N0}", info.Crystal);
                l_crystalstore.Text = string.Format("{0:N0}", info.CrystalStore);
                l_h.Text = string.Format("{0:N0}", info.H);
                l_hstore.Text = string.Format("{0:N0}", info.HStore);
                l_energy.Text = string.Format("{0:N0}", info.Energy);
                l_energystore.Text = string.Format("{0:N0}", info.EnergyStroe);
                lb_ball_list.Items.Clear();
                //foreach (OverviewInfo.Ball b in info.Balllist)
                //{
                    //string s = b.Name;
                    //for (int i = 0; i < 12 - b.Name.Length; i++)
                    //{
                    //    s += " ";
                    //}
                    //s += "[" + b.Location + "]";
                    //lb_balllist.Items.Add(s);
                //}
            }
            if (balls != null)
            {
                int allm = 0;
                int allc = 0;
                int allh = 0;
                foreach (CommonInfo ball in balls)
                {
                    allm += ball.Metal;
                    allc += ball.Crystal;
                    allh += ball.H;
                    lb_ball_list.Items.Add(ball);
                }
                l_metal_all.Text = string.Format("{0:N0}", allm);
                l_crystal_all.Text = string.Format("{0:N0}", allc);
                l_H_all.Text = string.Format("{0:N0}", allh);
            }
        }

        protected void ShowInfo2(object sender, EventArgs e)
        {
            if (pi != null)
            {
                l_ballname.Text = pi.CurrentBallName;
                l_metal.Text = string.Format("{0:N0}", pi.Metal);

                l_metalstroe.Text = string.Format("{0:N0}", pi.MetalStore);
                l_crystal.Text = string.Format("{0:N0}", pi.Crystal);
                l_crystalstore.Text = string.Format("{0:N0}", pi.CrystalStore);
                l_h.Text = string.Format("{0:N0}", pi.H);
                l_hstore.Text = string.Format("{0:N0}", pi.HStore);
                l_energy.Text = string.Format("{0:N0}", pi.Energy);
                l_energystore.Text = string.Format("{0:N0}", pi.EnergyStroe);
                lb_ball_list.Items.Clear();
                //foreach (CommonInfo.Ball b in pi.Balllist)
                //{
                //    string s = b.Name;
                //    for (int i = 0; i < 12 - b.Name.Length; i++)
                //    {
                //        s += " ";
                //    }
                //    s += "[" + b.Location + "]";
                //    lb_balllist.Items.Add(s);
                //}
            }
            if (balls != null)
            {
                int allm = 0;
                int allc = 0;
                int allh = 0;

                int allmh = 0;
                int allch = 0;
                int allhh = 0;
                foreach (ProductivityInfo ball in balls)
                {
                    allm += ball.Metal;
                    allc += ball.Crystal;
                    allh += ball.H;

                    allmh += ball.MetalHour;
                    allch += ball.CrystalHour;
                    allhh += ball.HHour;

                    lb_ball_list.Items.Add(ball);
                }
                l_metal_all.Text = string.Format("{0:N0}", allm);
                l_crystal_all.Text = string.Format("{0:N0}", allc);
                l_H_all.Text = string.Format("{0:N0}", allh);

                l_metalh_all.Text = string.Format("{0:N0}", allmh);
                l_crystalh_all.Text = string.Format("{0:N0}", allch);
                l_hh_all.Text = string.Format("{0:N0}", allhh);

                l_metal_allday.Text = string.Format("{0:N0}", allmh * 24);
                l_crystal_allday.Text = string.Format("{0:N0}", allch * 24);
                l_h_allday.Text = string.Format("{0:N0}", allhh * 24);
            }
            progressBar1.Visible = false;
            btnOverView.Enabled = true;
        }

        protected void ShowMsg(object sender, EventArgs e)
        {
            progressBar1.Increment(progessStep);
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process p = Process.GetCurrentProcess();
            if (p != null)
            {
                p.Kill();
            }
        }

        /// <summary>
        /// 激活窗体时的动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Activated(object sender, EventArgs e)
        {
            this.outputArea.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            this.AccessOverview();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 
        /// </summary>
        private void AccessOverview()
        {
            progressBar1.Increment(-100);
            progressBar1.Visible = true;
            btnOverView.Enabled = false;
            try
            {
                ss.run(3);
            }
            catch (Exception ee)
            {
                ee.ToString();
            }
        }

        private void RankScan()
        {
            //btnRank.Enabled = false;
            try
            {
                ss.run(6);
            }
            catch (Exception ee)
            {
                ee.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void logout()
        {
            try
            {
                ss.run(4);
            }
            catch (Exception ee)
            {
                ee.ToString();
            }
        }

        //private ObjectSender OnObjectSend;
        //internal event ObjectSender OnOnbjectRecive
        //{
        //    add { OnObjectSend += new ObjectSender(value); }
        //    remove { OnObjectSend -= new ObjectSender(value); }
        //}

        
        private void OnObjectRecived(object o)
        {
            if (o.GetType() == typeof(OverviewInfo))
            {
                info = (OverviewInfo)o;
            }
            else if (o.GetType() == typeof(ArrayList))
            {
                balls = (ArrayList)o;
            }
            else if (o.GetType() == typeof(ProductivityInfo))
            {
                pi = (ProductivityInfo)o;
            }
            Object[] list = { this, System.EventArgs.Empty };
            this.outputArea.BeginInvoke(new EventHandler(ShowInfo2), list);
        }

        private int progessStep;
        private void OnMessageRecived(int i)
        {
            progessStep = i;
            Object[] list = { this, System.EventArgs.Empty };
            this.outputArea.BeginInvoke(new EventHandler(ShowMsg), list);
        }
        #endregion

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this.outputArea.AppendText("窗口被激活。\r\n");
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal; 
            this.noti.Visible = false;
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.noti.Visible = true;
            }
        }

        private void lb_balllist_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonInfo ci = ((CommonInfo)lb_ball_list.SelectedItem);
            if (ci != null)
            {
                l_metal.Text = string.Format("{0:N0}", ci.Metal);
                l_metalstroe.Text = string.Format("{0:N0}", ci.MetalStore);
                l_crystal.Text = string.Format("{0:N0}", ci.Crystal);
                l_crystalstore.Text = string.Format("{0:N0}", ci.CrystalStore);
                l_h.Text = string.Format("{0:N0}", ci.H);
                l_hstore.Text = string.Format("{0:N0}", ci.HStore);
                l_energy.Text = string.Format("{0:N0}", ci.Energy);
                l_energystore.Text = string.Format("{0:N0}", ci.EnergyStroe);
            }
        }

        private void b_dispatch_Click(object sender, EventArgs e)
        {
            DispatchForm df = new DispatchForm(ss);
            df.Show();
        }

        private void b_sysmap_Click(object sender, EventArgs e)
        {
            SysmapForm sf = new SysmapForm(ss);
            sf.Show();
        }

        private void b_rank_Click(object sender, EventArgs e)
        {
            //this.RankScan();
            DeadSheepForm dsf = new DeadSheepForm(ss);
            dsf.Show();
        }
    }
}
