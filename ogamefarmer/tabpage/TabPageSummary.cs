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
        private void btnInfoCollect_Click(object sender, EventArgs e)
        {
            productivityCommander = new ProductivityCommander();
            productivityCommander.ProductivityEvent += OnProductivityScan;
            CommandCenter.RUN(productivityCommander, this);
        }

        private void OnProductivityScan()
        {
            this.BeginInvoke(new EventHandler(ResponseProductivityScan));
        }

        protected void ResponseProductivityScan(object sender, EventArgs e)
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
    }
}
