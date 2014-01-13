using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GalaxyFarmer.form
{
    public partial class FleetForm : Form
    {
        private StarScript ss;
        public FleetForm()
        {
            InitializeComponent();
            //this.ss = ss;
        }

        private void btnFleetTest_Click(object sender, EventArgs e)
        {
            try
            {
                ss.run(8);
            }
            catch (Exception ee)
            {
                ee.ToString();
            }
        }
    }
}
