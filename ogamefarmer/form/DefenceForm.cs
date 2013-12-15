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
        private StarScript starScript;
        private AllDefence defenceStrategy;
        private DefenceMessager defenceMessager;

        public DefenceForm(StarScript ss)
        {               
            InitializeComponent();
            defenceStrategy = new AllDefence();
            starScript = ss;
            ss.defenceStrategy = defenceStrategy;
            ss.DefenceEvent += this.OnMessageRecived;
        }

        private void OnMessageRecived(DefenceMessager dm)
        {
            this.defenceMessager = dm;
            Object[] list = { this, System.EventArgs.Empty };
            this.pbDefence.BeginInvoke(new EventHandler(DoAfterRecivedMessage), list);
        }

        private void DoAfterRecivedMessage(object sender, EventArgs args)
        {
            this.pbDefence.Value = this.defenceMessager.progress;
        }

        private void DefenceForm_Load(object sender, EventArgs e)
        {

        }

        private void btnMakeTower_Click(object sender, EventArgs e)
        {
            btnMakeTower.Enabled = false;
            if (rbAll.Checked)
            {
                defenceStrategy.defenceType = AllDefence.DefenceType.ALL;
            }
            else if (rbPaohui.Checked)
            {
                defenceStrategy.defenceType = AllDefence.DefenceType.PAOHUI;
            }
            else if (rbMetal.Checked)
            {
                defenceStrategy.defenceType = AllDefence.DefenceType.METAL;
            }
            starScript.run(7);
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
