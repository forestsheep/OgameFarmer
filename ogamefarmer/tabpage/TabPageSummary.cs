using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GalaxyFarmer
{
    partial class Main
    {
        private ProductivityCommander productivityCommander;

        private void Summary_Load()
        {
            this.pbScanProductivityProgress.Visible = false;
        }
        /// <summary>
        /// 扫描个星球库存及产量按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfoCollect_Click(object sender, EventArgs e)
        {
            productivityCommander = new ProductivityCommander();
            productivityCommander.ProductivityEvent += OnProductivityScanOver;
            productivityCommander.ProductivityStepEvent += OnProductivityScanStepOver;
            pbScanProductivityProgress.Visible = true;
            pbScanProductivityProgress.Maximum = Profile.BallList.Count * 100;
            pbScanProductivityProgress.Value = 0;
            btnInfoCollect.Enabled = false;
            CommandCenter.RUN(productivityCommander, this);
        }

        private void OnProductivityScanStepOver()
        {
            this.BeginInvoke(new EventHandler(ResponseProductivityStepScan));
        }

        private void OnProductivityScanOver()
        {
            this.BeginInvoke(new EventHandler(ResponseProductivityScan));
        }

        protected void ResponseProductivityStepScan(object sender, EventArgs e)
        {
            pbScanProductivityProgress.Increment(100);
        }
        protected void ResponseProductivityScan(object sender, EventArgs e)
        {
            int allm = 0;
            int allc = 0;
            int allh = 0;
            int allmh = 0;
            int allch = 0;
            int allhh = 0;
            lb_ball_list.Items.Clear();
            foreach(BallProductivity ballProductivity in productivityCommander.Messager.BallProductivityList)
            {
                lb_ball_list.Items.Add(ballProductivity);
                allm += ballProductivity.Metal;
                allc += ballProductivity.Crystal;
                allh += ballProductivity.HH;
                allmh += ballProductivity.MetalHour;
                allch += ballProductivity.CrystalHour;
                allhh += ballProductivity.HHHour;
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

            btnInfoCollect.Enabled = true;
            pbScanProductivityProgress.Visible = false;
        }

        /// <summary>
        /// 列表切换触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_ball_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            BallProductivity bp = ((BallProductivity)lb_ball_list.SelectedItem);
            if (bp != null)
            {
                l_metal.Text = string.Format("{0:N0}", bp.Metal);
                l_metalstroe.Text = string.Format("{0:N0}", bp.MetalStore);
                l_crystal.Text = string.Format("{0:N0}", bp.Crystal);
                l_crystalstore.Text = string.Format("{0:N0}", bp.CrystalStore);
                l_h.Text = string.Format("{0:N0}", bp.HH);
                l_hstore.Text = string.Format("{0:N0}", bp.HHStore);
                l_energy.Text = string.Format("{0:N0}", bp.Energy);
                l_energystore.Text = string.Format("{0:N0}", bp.EnergyStroe);
            }
        }
    }
}
