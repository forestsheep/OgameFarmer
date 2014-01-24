using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GalaxyFarmer
{
    partial class Main
    {
        private DefenceCommander defenceCommander;
        private void Defenece_Load()
        {
            pbDefence.Visible = false;
            tbMetalReserve.Text = "0";
            tbCrystalReserve.Text = "0";
            tbHHReserve.Text = "0";
            rb1.Checked = true;
            rbAll.Checked = true;
            tbNumerator.Enabled = false;
            tbDenominator.Enabled = false;
        }

        private void btnMakeTower_Click(object sender, EventArgs e)
        {
            DefenceMessager defenceMessager = new DefenceMessager();
            try
            {
                tbMetalReserve.Text = StringUtil.SetToZeroIfEmpty(tbMetalReserve.Text);
                defenceMessager.MetalCapacity = int.Parse(tbMetalReserve.Text);
                defenceMessager.CrystalCapacity = int.Parse(tbCrystalReserve.Text);
                defenceMessager.HHCapacity = int.Parse(tbHHReserve.Text);
                if (rb13.Checked)
                {
                    defenceMessager.RatioNumerator = 1;
                    defenceMessager.RatioDenominator = 3;
                }
                else if (rb1.Checked)
                {
                    defenceMessager.RatioNumerator = 1;
                    defenceMessager.RatioDenominator = 1;
                }
                else if (rb23.Checked)
                {
                    defenceMessager.RatioNumerator = 2;
                    defenceMessager.RatioDenominator = 3;
                }
                else if (rbCustom.Checked)
                {
                    defenceMessager.RatioNumerator = Double.Parse(tbNumerator.Text);
                    defenceMessager.RatioDenominator = Double.Parse(tbDenominator.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            if (rbAll.Checked)
            {
                defenceMessager.defenceType = DefenceStrategy.DefenceType.ALL;
            }
            else if (rbPaohui.Checked)
            {
                defenceMessager.defenceType = DefenceStrategy.DefenceType.PAOHUI;
            }
            else if (rbMetal.Checked)
            {
                defenceMessager.defenceType = DefenceStrategy.DefenceType.METAL;
            }

            defenceCommander = new DefenceCommander(defenceMessager, OnDefenceBuildOver);
            pbDefence.Maximum = Profile.BallList.Count * 200;
            pbDefence.Value = 0;
            CommandCenter.RUN(defenceCommander, this);
        }

        private void OnDefenceBuildOver()
        {
            this.BeginInvoke(new EventHandler(ResponseDefence));
        }

        protected void ResponseDefence(object sender, EventArgs e)
        {
            this.pbDefence.Value = defenceCommander.Messager.Progress;
            this.tbDefenceLog.AppendText(defenceCommander.Messager.PostBuildLog());
            if (!defenceCommander.Messager.IsScaning && !defenceCommander.Messager.IsBuilding)
            {
                this.pbDefence.Visible = false;
                this.pbDefence.Value = 0;
                this.btnMakeTower.Enabled = true;
            }
        }

        #region 画面触发事件
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

        private void rbCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCustom.Checked)
            {
                tbNumerator.Enabled = true;
                tbDenominator.Enabled = true;
            }
            else
            {
                tbNumerator.Enabled = false;
                tbDenominator.Enabled = false;
            }
        }
        #endregion
    }
}
