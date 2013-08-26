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
        private string logMessage;
        private StarScript lt;

        #region 构造函数
        public Main()
        {
            InitializeComponent();
            //this.Icon = Properties.Resources.MainIcon;
        }
        #endregion

        #region 事件
        System.Timers.Timer autoLoginTimer = new System.Timers.Timer();
        //private Boolean autoRunning = false;
        private void Main_Load(object sender, EventArgs e)
        {
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

        private void daka(object source, System.Timers.ElapsedEventArgs e)
        {
            this.AccessHomePage();
        }

        private void btnRunLogin_Click(object sender, EventArgs e)
        {
            this.AccessHomePage();
        }

        protected void TextShow(object sender, EventArgs e)
        {
            this.outputArea.AppendText(logMessage);
        }

        protected void ShowInfo(object sender, EventArgs e)
        {
            if(islogin)
            {
                l_islogin.Text = "登陆成功";
            }
            if (info != null)
            {
                l_ballname.Text = info.CurrentBallName;
                l_metal.Text = info.Metal;
                l_metalstroe.Text = info.MetalStore;
                l_crystal.Text = info.Crystal;
                l_crystalstore.Text = info.CrystalStore;
                l_h.Text = info.H;
                l_hstore.Text = info.HStore;
                l_energy.Text = info.Energy;
                l_energystore.Text = info.EnergyStroe;
            }
        }

        private void appendAccountBtn_Click(object sender, EventArgs e)
        {
            this.login();
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
        /// 账号被选中时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkedListBox_accounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 编辑账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            this.AccessOverview();
        }

        /// <summary>
        /// 删除账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            this.logout();
        }

        #endregion

        #region 方法

        
        /// <summary>
        /// 
        /// </summary>
        private void AccessHomePage()
        {
            if (this.lt == null)
            {
                this.lt = new StarScript();
                lt.Login += this.OnLogin;
                lt.Osender += this.OnReciveObject;
            }
            try
            {
                lt.run(1);
                
            }
            catch (Exception ee)
            {
                MessageHandler(ee.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void login()
        {
            if (this.lt == null)
            {
                this.lt = new StarScript();
                lt.Login += this.OnLogin;
                lt.Osender += this.OnReciveObject;
            }
            try
            {
                lt.run(2);
            }
            catch (Exception ee)
            {
                MessageHandler(ee.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void AccessOverview()
        {
            if (this.lt == null)
            {
                this.lt = new StarScript();
                lt.Login += this.OnLogin;
                lt.Osender += this.OnReciveObject;
            }
            try
            {
                lt.run(3);
            }
            catch (Exception ee)
            {
                MessageHandler(ee.ToString() + "\r\n");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void logout()
        {
            if (this.lt == null)
            {
                this.lt = new StarScript();
                lt.Login += this.OnLogin;
                lt.Osender += this.OnReciveObject;
            }
            try
            {
                lt.run(4);
            }
            catch (Exception ee)
            {
                MessageHandler(ee.ToString() + "\r\n");
            }
        }

        private MessageSender MessageHandler;
        internal event MessageSender Login
        {
            add
            {
                MessageHandler += new MessageSender(value);
            }
            remove
            {
                MessageHandler -= new MessageSender(value);
            }
        }

        private void OnLogin(string s)
        {
            logMessage = s;
            Object[] list = { this, System.EventArgs.Empty };
            this.outputArea.BeginInvoke(new EventHandler(TextShow), list);
        }

        private ObjectSender OnObjectSend;
        internal event ObjectSender OnOnbjectRecive
        {
            add { OnObjectSend += new ObjectSender(value); }
            remove { OnObjectSend -= new ObjectSender(value); }
        }

        private OverviewInfo info;
        private bool islogin = false;
        private void OnReciveObject(object o)
        {
            if (o.GetType() == typeof(LoginInfo))
            {
                islogin = ((LoginInfo)o).LoginSuccess;
            }
            else if (o.GetType() == typeof(OverviewInfo))
            {
                info = (OverviewInfo)o;
            }

            Object[] list = { this, System.EventArgs.Empty };
            this.outputArea.BeginInvoke(new EventHandler(ShowInfo), list);
        }
        #endregion

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this.outputArea.AppendText("窗口被激活。\r\n");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
