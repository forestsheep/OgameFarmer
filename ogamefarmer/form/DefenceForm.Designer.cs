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
            this.btnMakeTower = new System.Windows.Forms.Button();
            this.gbStrategy = new System.Windows.Forms.GroupBox();
            this.rbMetal = new System.Windows.Forms.RadioButton();
            this.rbPaohui = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.pbDefence = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ss = new System.Windows.Forms.StatusStrip();
            this.tsslStrategyDescription = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbStrategy.SuspendLayout();
            this.ss.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMakeTower
            // 
            this.btnMakeTower.Location = new System.Drawing.Point(435, 197);
            this.btnMakeTower.Name = "btnMakeTower";
            this.btnMakeTower.Size = new System.Drawing.Size(144, 57);
            this.btnMakeTower.TabIndex = 0;
            this.btnMakeTower.Text = "建造炮塔";
            this.btnMakeTower.UseVisualStyleBackColor = true;
            this.btnMakeTower.Click += new System.EventHandler(this.btnMakeTower_Click);
            // 
            // gbStrategy
            // 
            this.gbStrategy.Controls.Add(this.rbMetal);
            this.gbStrategy.Controls.Add(this.rbPaohui);
            this.gbStrategy.Controls.Add(this.rbAll);
            this.gbStrategy.Location = new System.Drawing.Point(435, 39);
            this.gbStrategy.Name = "gbStrategy";
            this.gbStrategy.Size = new System.Drawing.Size(144, 134);
            this.gbStrategy.TabIndex = 1;
            this.gbStrategy.TabStop = false;
            this.gbStrategy.Text = "建造策略";
            // 
            // rbMetal
            // 
            this.rbMetal.AutoSize = true;
            this.rbMetal.Location = new System.Drawing.Point(23, 92);
            this.rbMetal.Name = "rbMetal";
            this.rbMetal.Size = new System.Drawing.Size(83, 16);
            this.rbMetal.TabIndex = 2;
            this.rbMetal.TabStop = true;
            this.rbMetal.Text = "只使用金属";
            this.rbMetal.UseVisualStyleBackColor = true;
            this.rbMetal.CheckedChanged += new System.EventHandler(this.rbMetal_CheckedChanged);
            // 
            // rbPaohui
            // 
            this.rbPaohui.AutoSize = true;
            this.rbPaohui.Location = new System.Drawing.Point(23, 62);
            this.rbPaohui.Name = "rbPaohui";
            this.rbPaohui.Size = new System.Drawing.Size(71, 16);
            this.rbPaohui.TabIndex = 1;
            this.rbPaohui.TabStop = true;
            this.rbPaohui.Text = "炮灰优先";
            this.rbPaohui.UseVisualStyleBackColor = true;
            this.rbPaohui.CheckedChanged += new System.EventHandler(this.rbPaohui_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(23, 32);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(83, 16);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "等离子优先";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // pbDefence
            // 
            this.pbDefence.Location = new System.Drawing.Point(33, 298);
            this.pbDefence.Name = "pbDefence";
            this.pbDefence.Size = new System.Drawing.Size(546, 23);
            this.pbDefence.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(33, 39);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(376, 215);
            this.textBox1.TabIndex = 3;
            // 
            // ss
            // 
            this.ss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStrategyDescription});
            this.ss.Location = new System.Drawing.Point(0, 345);
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(618, 22);
            this.ss.TabIndex = 4;
            // 
            // tsslStrategyDescription
            // 
            this.tsslStrategyDescription.Name = "tsslStrategyDescription";
            this.tsslStrategyDescription.Size = new System.Drawing.Size(0, 17);
            // 
            // DefenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 367);
            this.Controls.Add(this.ss);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pbDefence);
            this.Controls.Add(this.gbStrategy);
            this.Controls.Add(this.btnMakeTower);
            this.Name = "DefenceForm";
            this.Text = "DefenceForm";
            this.Load += new System.EventHandler(this.DefenceForm_Load);
            this.gbStrategy.ResumeLayout(false);
            this.gbStrategy.PerformLayout();
            this.ss.ResumeLayout(false);
            this.ss.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMakeTower;
        private System.Windows.Forms.GroupBox gbStrategy;
        private System.Windows.Forms.RadioButton rbPaohui;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.ProgressBar pbDefence;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.StatusStrip ss;
        private System.Windows.Forms.ToolStripStatusLabel tsslStrategyDescription;
        private System.Windows.Forms.RadioButton rbMetal;
    }
}