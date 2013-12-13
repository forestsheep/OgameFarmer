using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OgameFarmer.form
{
    public partial class DefenceForm : Form
    {
        public DefenceForm()
        {
            InitializeComponent();
        }

        private void DefenceForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnMakeTower_Click(object sender, EventArgs e)
        {
            int i = gbStrategy.Controls.Count;
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            this.tsslStrategyDescription.Text = "优先使用重氢，然后尽可能使用金属和晶体，是一种尽可能使用全部资源的策略。";
        }

        private void rbPaohui_CheckedChanged(object sender, EventArgs e)
        {
            this.tsslStrategyDescription.Text = "按照现有的资源比例,尽可能地使用金属和晶体,来建造火箭炮和轻激光。";
        }

        private void rbMetal_CheckedChanged(object sender, EventArgs e)
        {
            this.tsslStrategyDescription.Text = "只使用金属来建造火箭炮。";
        }
    }
}
