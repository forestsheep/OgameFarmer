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
using GalaxyFarmer.form;
using GalaxyFarmer.messager;

namespace GalaxyFarmer
{
    public partial class Main : Form
    {

        #region 构造函数
        internal Main()
        {
            InitializeComponent();
        }
        #endregion

        #region 事件
        private void Main_Load(object sender, EventArgs e)
        {
            Summary_Load();
            Defenece_Load();
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOverview_Click(object sender, EventArgs e)
        {
            SummaryForm sf = new SummaryForm();
            //sf.MdiParent = this;
            sf.Show();
        }

        #endregion

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void b_dispatch_Click(object sender, EventArgs e)
        {
            DispatchForm df = new DispatchForm();
            df.Show();
        }

        private SysmapForm sf;
        private void b_sysmap_Click(object sender, EventArgs e)
        {
            if (sf == null)
            {
                sf = new SysmapForm();
            }
            sf.Show();
        }

        private void b_rank_Click(object sender, EventArgs e)
        {
            //this.RankScan();
            try
            {
                DeadSheepForm dsf = new DeadSheepForm();
                dsf.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("rankbtnclicked   " + ex.ToString());
            }
        }

        private void btnAllDefence_Click(object sender, EventArgs e)
        {
            DefenceForm dff = new DefenceForm();
            dff.Show();
        }

        private void btnFleet_Click(object sender, EventArgs e)
        {
            FleetForm ff = new FleetForm();
            ff.Show();
        }

        private void rbMetal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbPaohui_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
