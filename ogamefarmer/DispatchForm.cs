using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace OgameFarmer
{
    public partial class DispatchForm : Form
    {
        private StarScript ss;
        internal DispatchForm(StarScript ss)
        {
            InitializeComponent();
            this.ss = ss;
            this.ss.Csender += this.OnConRecived;
        }

        private void DispatchForm_Load(object sender, EventArgs e)
        {

        }

        private void b_check_Click(object sender, EventArgs e)
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
        ArrayList balls;
        private void OnConRecived(ArrayList al)
        {
            balls = al;
            Object[] list = { this, System.EventArgs.Empty };
            this.lb_ball_list.BeginInvoke(new EventHandler(ShowMsg), list);
        }

        private void ShowMsg(object sender, EventArgs e)
        {
            if (balls != null)
            {
                foreach (ConstructionInfo ci in balls)
                {
                    lb_ball_list.Items.Add(ci);
                }
            }
        }

        private void lb_ball_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConstructionInfo ci = ((ConstructionInfo)lb_ball_list.SelectedItem);
            if (ci != null)
            {
                lb_cons_list.Items.Clear();
                foreach (Construction c in ci.allCons)
                {
                    lb_cons_list.Items.Add(c);
                }
            }
        }
    }
}
