namespace OgameFarmer
{
    partial class DeadSheepForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeadSheepForm));
            this.btnScan = new System.Windows.Forms.Button();
            this.bAla = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mtbBefore = new System.Windows.Forms.MaskedTextBox();
            this.mtbAbsScore = new System.Windows.Forms.MaskedTextBox();
            this.dgvDeadSheep = new System.Windows.Forms.DataGridView();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lSheepCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeadSheep)).BeginInit();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(32, 20);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(112, 78);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "扫描并录入数据";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // bAla
            // 
            this.bAla.Location = new System.Drawing.Point(596, 20);
            this.bAla.Name = "bAla";
            this.bAla.Size = new System.Drawing.Size(112, 78);
            this.bAla.TabIndex = 2;
            this.bAla.Text = "开始分析";
            this.bAla.UseVisualStyleBackColor = true;
            this.bAla.Click += new System.EventHandler(this.bAla_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(556, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "天前";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(395, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "分数相差±";
            // 
            // mtbBefore
            // 
            this.mtbBefore.Location = new System.Drawing.Point(495, 50);
            this.mtbBefore.Mask = "99999";
            this.mtbBefore.Name = "mtbBefore";
            this.mtbBefore.Size = new System.Drawing.Size(48, 21);
            this.mtbBefore.TabIndex = 5;
            this.mtbBefore.ValidatingType = typeof(int);
            // 
            // mtbAbsScore
            // 
            this.mtbAbsScore.Location = new System.Drawing.Point(464, 77);
            this.mtbAbsScore.Mask = "999999999";
            this.mtbAbsScore.Name = "mtbAbsScore";
            this.mtbAbsScore.Size = new System.Drawing.Size(79, 21);
            this.mtbAbsScore.TabIndex = 6;
            // 
            // dgvDeadSheep
            // 
            this.dgvDeadSheep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeadSheep.Location = new System.Drawing.Point(32, 118);
            this.dgvDeadSheep.Name = "dgvDeadSheep";
            this.dgvDeadSheep.RowTemplate.Height = 23;
            this.dgvDeadSheep.Size = new System.Drawing.Size(675, 444);
            this.dgvDeadSheep.TabIndex = 7;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(428, 20);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(115, 21);
            this.dtpFromDate.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(459, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "的";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(556, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "之内";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(594, 576);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "共找到";
            // 
            // lSheepCount
            // 
            this.lSheepCount.AutoSize = true;
            this.lSheepCount.Location = new System.Drawing.Point(657, 575);
            this.lSheepCount.Name = "lSheepCount";
            this.lSheepCount.Size = new System.Drawing.Size(0, 12);
            this.lSheepCount.TabIndex = 13;
            // 
            // DeadSheepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 616);
            this.Controls.Add(this.lSheepCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.dgvDeadSheep);
            this.Controls.Add(this.mtbAbsScore);
            this.Controls.Add(this.mtbBefore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bAla);
            this.Controls.Add(this.btnScan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeadSheepForm";
            this.Text = "死羊分析";
            this.Load += new System.EventHandler(this.DeadSheepForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeadSheep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button bAla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtbBefore;
        private System.Windows.Forms.MaskedTextBox mtbAbsScore;
        private System.Windows.Forms.DataGridView dgvDeadSheep;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lSheepCount;
    }
}