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
    public partial class DeadSheepForm : Form
    {
        private StarScript ss;
        internal DeadSheepForm(StarScript ss)
        {
            InitializeComponent();
            this.ss = ss;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                ss.run(6);
            }
            catch (Exception ee)
            {
                ee.ToString();
            }
        }
    }
}
