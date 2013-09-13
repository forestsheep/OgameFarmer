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
        internal SysmapForm(StarScript ss)
        {
            InitializeComponent();
            this.ss = ss;
        }

        private void b_start_Click(object sender, EventArgs e)
        {
            try
            {
                StarScript.yinhe = Int32.Parse(tb_yinhe.Text) - 1;
            }
            catch (FormatException)
            {
                return;
            }
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
