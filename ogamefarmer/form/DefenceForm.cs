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
    public partial class DefenceForm : Form
    {
        private StarScript starScript;
        private AllDefence defenceStrategy;
        private DefenceMessager defenceMessager;

        public DefenceForm()
        {
            InitializeComponent();
            defenceStrategy = new AllDefence();
            //ss.defenceStrategy = defenceStrategy;
            //ss.DefenceEvent += this.OnMessageRecived;
        }

        private void OnMessageRecived(DefenceMessager dm)
        {
            this.defenceMessager = dm;
            Object[] list = { this, System.EventArgs.Empty };
            this.pbDefence.BeginInvoke(new EventHandler(DoAfterRecivedMessage), list);
        }

        private void DoAfterRecivedMessage(object sender, EventArgs args)
        {
            this.pbDefence.Value = this.defenceMessager.Progress;
            this.tbLogBox.AppendText(defenceMessager.PostBuildLog() + "\r\n");
            if (this.defenceMessager.IsBuildOver)
            {
                this.pbDefence.Value = 0;
                this.btnMakeTower.Enabled = true;
            }
        }

        private void DefenceForm_Load(object sender, EventArgs e)
        {
            rb23.Checked = true;
            rbAll.Checked = true;
            tbMetalReserve.Text = "0";
            tbCrystalReserve.Text = "0";
            tbHHReserve.Text = "0";
        }

        private void btnMakeTower_Click(object sender, EventArgs e)
        {
        //    defenceStrategy.MetalCapacity = 0;
        //    defenceStrategy.CrystalCapacity = 0;
        //    defenceStrategy.HHCapacity = 0;
        //    try
        //    {
        //        defenceStrategy.MetalCapacity = Int32.Parse(tbMetalReserve.Text);
        //        defenceStrategy.CrystalCapacity = Int32.Parse(tbCrystalReserve.Text);
        //        defenceStrategy.HHCapacity = Int32.Parse(tbHHReserve.Text);

        //        if (rb13.Checked)
        //        {
        //            defenceStrategy.RatioNumerator = 1;
        //            defenceStrategy.RatioDenominator = 3;
        //        }
        //        else if (rb21.Checked)
        //        {
        //            defenceStrategy.RatioNumerator = 1;
        //            defenceStrategy.RatioDenominator = 2;
        //        }
        //        else if (rb23.Checked)
        //        {
        //            defenceStrategy.RatioNumerator = 2;
        //            defenceStrategy.RatioDenominator = 3;
        //        }
        //        else if (rbCustom.Checked)
        //        {
        //            defenceStrategy.RatioNumerator = Double.Parse(tbNumerator.Text);
        //            defenceStrategy.RatioDenominator = Double.Parse(tbDenominator.Text);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

        //    btnMakeTower.Enabled = false;
        //    if (rbAll.Checked)
        //    {
        //        defenceStrategy.defenceType = AllDefence.DefenceType.ALL;
        //    }
        //    else if (rbPaohui.Checked)
        //    {
        //        defenceStrategy.defenceType = AllDefence.DefenceType.PAOHUI;
        //    }
        //    else if (rbMetal.Checked)
        //    {
        //        defenceStrategy.defenceType = AllDefence.DefenceType.METAL;
        //    }
        //    starScript.run(7);
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
