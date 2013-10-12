using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OgameFarmer
{
    public partial class SysmapForm : Form
    {
        private StarScript ss;
        private int scanStatus;
        internal SysmapForm(StarScript ss)
        {
            InitializeComponent();
            this.ss = ss;
            this.ss.GalaxyScanSender += this.OnScanStep;
        }

        private void OnScanStep(int scanstatus)
        {
            this.scanStatus = scanstatus;
            Object[] list = { this, EventArgs.Empty };
            this.b_start.BeginInvoke(new EventHandler(ScanStepOver), list);
        }

        private void ScanStepOver(object sender, EventArgs e)
        {
            l_prograss.Text = this.scanStatus.ToString();
        }

        private void b_start_Click(object sender, EventArgs e)
        {
            try
            {
                ss.run(5);
            }
            catch (Exception ee)
            {
                ee.ToString();
            }
        }
    }
}
