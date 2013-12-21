namespace OgameFarmer.form
{
    partial class DefenceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefenceForm));
            this.btnMakeTower = new System.Windows.Forms.Button();
            this.gbStrategy = new System.Windows.Forms.GroupBox();
            this.rbMetal = new System.Windows.Forms.RadioButton();
            this.rbPaohui = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.pbDefence = new System.Windows.Forms.ProgressBar();
            this.tbLogBox = new System.Windows.Forms.TextBox();
            this.ss = new System.Windows.Forms.StatusStrip();
            this.tsslStrategyDescription = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbCapacity = new System.Windows.Forms.GroupBox();
            this.tbDenominator = new System.Windows.Forms.TextBox();
            this.tbNumerator = new System.Windows.Forms.TextBox();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rb13 = new System.Windows.Forms.RadioButton();
            this.rb21 = new System.Windows.Forms.RadioButton();
            this.rb23 = new System.Windows.Forms.RadioButton();
            this.gbReserve = new System.Windows.Forms.GroupBox();
            this.tbHHReserve = new System.Windows.Forms.TextBox();
            this.tbCrystalReserve = new System.Windows.Forms.TextBox();
            this.lHHReserve = new System.Windows.Forms.Label();
            this.lCrystalReserve = new System.Windows.Forms.Label();
            this.tbMetalReserve = new System.Windows.Forms.TextBox();
            this.lMetalReserve = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbStrategy.SuspendLayout();
            this.ss.SuspendLayout();
            this.gbCapacity.SuspendLayout();
            this.gbReserve.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMakeTower
            // 
            this.btnMakeTower.Location = new System.Drawing.Point(639, 220);
            this.btnMakeTower.Name = "btnMakeTower";
            this.btnMakeTower.Size = new System.Drawing.Size(144, 57);
            this.btnMakeTower.TabIndex = 8;
            this.btnMakeTower.Text = "建造炮塔";
            this.btnMakeTower.UseVisualStyleBackColor = true;
            this.btnMakeTower.Click += new System.EventHandler(this.btnMakeTower_Click);
            // 
            // gbStrategy
            // 
            this.gbStrategy.Controls.Add(this.rbMetal);
            this.gbStrategy.Controls.Add(this.rbPaohui);
            this.gbStrategy.Controls.Add(this.rbAll);
            this.gbStrategy.Location = new System.Drawing.Point(639, 39);
            this.gbStrategy.Name = "gbStrategy";
            this.gbStrategy.Size = new System.Drawing.Size(144, 162);
            this.gbStrategy.TabIndex = 7;
            this.gbStrategy.TabStop = false;
            this.gbStrategy.Text = "建造策略";
            // 
            // rbMetal
            // 
            this.rbMetal.AutoSize = true;
            this.rbMetal.Location = new System.Drawing.Point(23, 126);
            this.rbMetal.Name = "rbMetal";
            this.rbMetal.Size = new System.Drawing.Size(83, 16);
            this.rbMetal.TabIndex = 71;
            this.rbMetal.TabStop = true;
            this.rbMetal.Text = "只使用金属";
            this.rbMetal.UseVisualStyleBackColor = true;
            this.rbMetal.CheckedChanged += new System.EventHandler(this.rbMetal_CheckedChanged);
            // 
            // rbPaohui
            // 
            this.rbPaohui.AutoSize = true;
            this.rbPaohui.Location = new System.Drawing.Point(23, 77);
            this.rbPaohui.Name = "rbPaohui";
            this.rbPaohui.Size = new System.Drawing.Size(71, 16);
            this.rbPaohui.TabIndex = 7;
            this.rbPaohui.TabStop = true;
            this.rbPaohui.Text = "炮灰优先";
            this.rbPaohui.UseVisualStyleBackColor = true;
            this.rbPaohui.CheckedChanged += new System.EventHandler(this.rbPaohui_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(23, 28);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(83, 16);
            this.rbAll.TabIndex = 7;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "等离子优先";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // pbDefence
            // 
            this.pbDefence.Location = new System.Drawing.Point(33, 368);
            this.pbDefence.Name = "pbDefence";
            this.pbDefence.Size = new System.Drawing.Size(750, 23);
            this.pbDefence.TabIndex = 2;
            // 
            // tbLogBox
            // 
            this.tbLogBox.Location = new System.Drawing.Point(33, 39);
            this.tbLogBox.Multiline = true;
            this.tbLogBox.Name = "tbLogBox";
            this.tbLogBox.ReadOnly = true;
            this.tbLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLogBox.Size = new System.Drawing.Size(376, 238);
            this.tbLogBox.TabIndex = 20;
            // 
            // ss
            // 
            this.ss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStrategyDescription});
            this.ss.Location = new System.Drawing.Point(0, 423);
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(795, 22);
            this.ss.TabIndex = 4;
            // 
            // tsslStrategyDescription
            // 
            this.tsslStrategyDescription.Name = "tsslStrategyDescription";
            this.tsslStrategyDescription.Size = new System.Drawing.Size(0, 17);
            // 
            // gbCapacity
            // 
            this.gbCapacity.Controls.Add(this.label1);
            this.gbCapacity.Controls.Add(this.tbDenominator);
            this.gbCapacity.Controls.Add(this.tbNumerator);
            this.gbCapacity.Controls.Add(this.rbCustom);
            this.gbCapacity.Controls.Add(this.rb13);
            this.gbCapacity.Controls.Add(this.rb21);
            this.gbCapacity.Controls.Add(this.rb23);
            this.gbCapacity.Location = new System.Drawing.Point(433, 39);
            this.gbCapacity.Name = "gbCapacity";
            this.gbCapacity.Size = new System.Drawing.Size(176, 162);
            this.gbCapacity.TabIndex = 1;
            this.gbCapacity.TabStop = false;
            this.gbCapacity.Text = "资源用量";
            // 
            // tbDenominator
            // 
            this.tbDenominator.Location = new System.Drawing.Point(97, 131);
            this.tbDenominator.Name = "tbDenominator";
            this.tbDenominator.Size = new System.Drawing.Size(65, 21);
            this.tbDenominator.TabIndex = 3;
            // 
            // tbNumerator
            // 
            this.tbNumerator.Location = new System.Drawing.Point(23, 131);
            this.tbNumerator.Name = "tbNumerator";
            this.tbNumerator.Size = new System.Drawing.Size(47, 21);
            this.tbNumerator.TabIndex = 2;
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(23, 106);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(59, 16);
            this.rbCustom.TabIndex = 1;
            this.rbCustom.TabStop = true;
            this.rbCustom.Text = "自定义";
            this.rbCustom.UseVisualStyleBackColor = true;
            // 
            // rb13
            // 
            this.rb13.AutoSize = true;
            this.rb13.Location = new System.Drawing.Point(23, 80);
            this.rb13.Name = "rb13";
            this.rb13.Size = new System.Drawing.Size(41, 16);
            this.rb13.TabIndex = 1;
            this.rb13.TabStop = true;
            this.rb13.Text = "1/3";
            this.rb13.UseVisualStyleBackColor = true;
            // 
            // rb21
            // 
            this.rb21.AutoSize = true;
            this.rb21.Location = new System.Drawing.Point(23, 54);
            this.rb21.Name = "rb21";
            this.rb21.Size = new System.Drawing.Size(41, 16);
            this.rb21.TabIndex = 1;
            this.rb21.TabStop = true;
            this.rb21.Text = "1/2";
            this.rb21.UseVisualStyleBackColor = true;
            // 
            // rb23
            // 
            this.rb23.AutoSize = true;
            this.rb23.Location = new System.Drawing.Point(23, 28);
            this.rb23.Name = "rb23";
            this.rb23.Size = new System.Drawing.Size(41, 16);
            this.rb23.TabIndex = 1;
            this.rb23.TabStop = true;
            this.rb23.Text = "2/3";
            this.rb23.UseVisualStyleBackColor = true;
            // 
            // gbReserve
            // 
            this.gbReserve.Controls.Add(this.tbHHReserve);
            this.gbReserve.Controls.Add(this.tbCrystalReserve);
            this.gbReserve.Controls.Add(this.lHHReserve);
            this.gbReserve.Controls.Add(this.lCrystalReserve);
            this.gbReserve.Controls.Add(this.tbMetalReserve);
            this.gbReserve.Controls.Add(this.lMetalReserve);
            this.gbReserve.Location = new System.Drawing.Point(433, 220);
            this.gbReserve.Name = "gbReserve";
            this.gbReserve.Size = new System.Drawing.Size(176, 108);
            this.gbReserve.TabIndex = 3;
            this.gbReserve.TabStop = false;
            this.gbReserve.Text = "资源保留";
            // 
            // tbHHReserve
            // 
            this.tbHHReserve.Location = new System.Drawing.Point(55, 78);
            this.tbHHReserve.Name = "tbHHReserve";
            this.tbHHReserve.Size = new System.Drawing.Size(109, 21);
            this.tbHHReserve.TabIndex = 7;
            // 
            // tbCrystalReserve
            // 
            this.tbCrystalReserve.Location = new System.Drawing.Point(55, 48);
            this.tbCrystalReserve.Name = "tbCrystalReserve";
            this.tbCrystalReserve.Size = new System.Drawing.Size(109, 21);
            this.tbCrystalReserve.TabIndex = 6;
            // 
            // lHHReserve
            // 
            this.lHHReserve.AutoSize = true;
            this.lHHReserve.Location = new System.Drawing.Point(20, 81);
            this.lHHReserve.Name = "lHHReserve";
            this.lHHReserve.Size = new System.Drawing.Size(29, 12);
            this.lHHReserve.TabIndex = 2;
            this.lHHReserve.Text = "重氢";
            // 
            // lCrystalReserve
            // 
            this.lCrystalReserve.AutoSize = true;
            this.lCrystalReserve.Location = new System.Drawing.Point(20, 51);
            this.lCrystalReserve.Name = "lCrystalReserve";
            this.lCrystalReserve.Size = new System.Drawing.Size(29, 12);
            this.lCrystalReserve.TabIndex = 1;
            this.lCrystalReserve.Text = "晶体";
            // 
            // tbMetalReserve
            // 
            this.tbMetalReserve.Location = new System.Drawing.Point(55, 18);
            this.tbMetalReserve.Name = "tbMetalReserve";
            this.tbMetalReserve.Size = new System.Drawing.Size(109, 21);
            this.tbMetalReserve.TabIndex = 5;
            // 
            // lMetalReserve
            // 
            this.lMetalReserve.AutoSize = true;
            this.lMetalReserve.Location = new System.Drawing.Point(20, 21);
            this.lMetalReserve.Name = "lMetalReserve";
            this.lMetalReserve.Size = new System.Drawing.Size(29, 12);
            this.lMetalReserve.TabIndex = 0;
            this.lMetalReserve.Text = "金属";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "/";
            // 
            // DefenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 445);
            this.Controls.Add(this.gbReserve);
            this.Controls.Add(this.gbCapacity);
            this.Controls.Add(this.ss);
            this.Controls.Add(this.tbLogBox);
            this.Controls.Add(this.pbDefence);
            this.Controls.Add(this.gbStrategy);
            this.Controls.Add(this.btnMakeTower);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DefenceForm";
            this.Text = "防御";
            this.Load += new System.EventHandler(this.DefenceForm_Load);
            this.gbStrategy.ResumeLayout(false);
            this.gbStrategy.PerformLayout();
            this.ss.ResumeLayout(false);
            this.ss.PerformLayout();
            this.gbCapacity.ResumeLayout(false);
            this.gbCapacity.PerformLayout();
            this.gbReserve.ResumeLayout(false);
            this.gbReserve.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMakeTower;
        private System.Windows.Forms.GroupBox gbStrategy;
        private System.Windows.Forms.RadioButton rbPaohui;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.ProgressBar pbDefence;
        private System.Windows.Forms.TextBox tbLogBox;
        private System.Windows.Forms.StatusStrip ss;
        private System.Windows.Forms.ToolStripStatusLabel tsslStrategyDescription;
        private System.Windows.Forms.RadioButton rbMetal;
        private System.Windows.Forms.GroupBox gbCapacity;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rb13;
        private System.Windows.Forms.RadioButton rb21;
        private System.Windows.Forms.RadioButton rb23;
        private System.Windows.Forms.TextBox tbDenominator;
        private System.Windows.Forms.TextBox tbNumerator;
        private System.Windows.Forms.GroupBox gbReserve;
        private System.Windows.Forms.TextBox tbHHReserve;
        private System.Windows.Forms.TextBox tbCrystalReserve;
        private System.Windows.Forms.Label lHHReserve;
        private System.Windows.Forms.Label lCrystalReserve;
        private System.Windows.Forms.TextBox tbMetalReserve;
        private System.Windows.Forms.Label lMetalReserve;
        private System.Windows.Forms.Label label1;
    }
}