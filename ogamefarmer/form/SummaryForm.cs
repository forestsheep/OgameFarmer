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
    public partial class SummaryForm : Form
    {
        private OverviewInfo info;
        private ProductivityInfo pi;
        private ArrayList balls;
        private ArrayList oballs = new ArrayList();

        private ProductivityCommander productivityCommander;
        private int progessStep;

        internal SummaryForm()
        {
            InitializeComponent();
        }

        private void OnProductivityScan()
        {
            Object[] list = { this, System.EventArgs.Empty };
            this.btnOverview.BeginInvoke(new EventHandler(ShowInfo), list);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
        }

        /// <summary>
        /// 扫描键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOverview_Click(object sender, EventArgs e)
        {
            productivityCommander = new ProductivityCommander();
            productivityCommander.ProductivityEvent += OnProductivityScan;
            CommandCenter.RUN(productivityCommander, this);
        }

        

        protected void ShowInfo(object sender, EventArgs e)
        {
            //progressBar1.Increment(progessStep);
            //if (pi != null)
            //{
            //    l_ballname.Text = pi.CurrentBallName;
            //    l_metal.Text = string.Format("{0:N0}", pi.Metal);

            //    l_metalstroe.Text = string.Format("{0:N0}", pi.MetalStore);
            //    l_crystal.Text = string.Format("{0:N0}", pi.Crystal);
            //    l_crystalstore.Text = string.Format("{0:N0}", pi.CrystalStore);
            //    l_h.Text = string.Format("{0:N0}", pi.H);
            //    l_hstore.Text = string.Format("{0:N0}", pi.HStore);
            //    l_energy.Text = string.Format("{0:N0}", pi.Energy);
            //    l_energystore.Text = string.Format("{0:N0}", pi.EnergyStroe);
            //    lb_ball_list.Items.Clear();
            //}
            //if (balls != null)
            //{
            //    int allm = 0;
            //    int allc = 0;
            //    int allh = 0;

            //    int allmh = 0;
            //    int allch = 0;
            //    int allhh = 0;
            //    foreach (ProductivityInfo ball in balls)
            //    {
            //        allm += ball.Metal;
            //        allc += ball.Crystal;
            //        allh += ball.H;

            //        allmh += ball.MetalHour;
            //        allch += ball.CrystalHour;
            //        allhh += ball.HHour;

            //        lb_ball_list.Items.Add(ball);
            //    }
            //    l_metal_all.Text = string.Format("{0:N0}", allm);
            //    l_crystal_all.Text = string.Format("{0:N0}", allc);
            //    l_H_all.Text = string.Format("{0:N0}", allh);

            //    l_metalh_all.Text = string.Format("{0:N0}", allmh);
            //    l_crystalh_all.Text = string.Format("{0:N0}", allch);
            //    l_hh_all.Text = string.Format("{0:N0}", allhh);

            //    l_metal_allday.Text = string.Format("{0:N0}", allmh * 24);
            //    l_crystal_allday.Text = string.Format("{0:N0}", allch * 24);
            //    l_h_allday.Text = string.Format("{0:N0}", allhh * 24);
            //    progressBar1.Visible = false;
            //    btnOverview.Enabled = true;
            //}
            
        }

        protected void ShowMsg(object sender, EventArgs e)
        {
            
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

        
    }
}
