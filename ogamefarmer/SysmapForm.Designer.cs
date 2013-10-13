namespace OgameFarmer
{
    partial class SysmapForm
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
            this.b_start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.l_prograss = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.b_csv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_start
            // 
            this.b_start.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_start.Location = new System.Drawing.Point(26, 52);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(390, 106);
            this.b_start.TabIndex = 0;
            this.b_start.Text = "开始";
            this.b_start.UseVisualStyleBackColor = true;
            this.b_start.Click += new System.EventHandler(this.b_start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(262, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "进度：";
            // 
            // l_prograss
            // 
            this.l_prograss.AutoSize = true;
            this.l_prograss.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_prograss.Location = new System.Drawing.Point(339, 176);
            this.l_prograss.Name = "l_prograss";
            this.l_prograss.Size = new System.Drawing.Size(16, 16);
            this.l_prograss.TabIndex = 2;
            this.l_prograss.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(23, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(416, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "会优先继续上次未完成的扫描，否则将开始新的扫描。";
            // 
            // b_csv
            // 
            this.b_csv.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_csv.Location = new System.Drawing.Point(26, 227);
            this.b_csv.Name = "b_csv";
            this.b_csv.Size = new System.Drawing.Size(390, 95);
            this.b_csv.TabIndex = 4;
            this.b_csv.Text = "CSV输出";
            this.b_csv.UseVisualStyleBackColor = true;
            this.b_csv.Click += new System.EventHandler(this.b_csv_Click);
            // 
            // SysmapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 353);
            this.Controls.Add(this.b_csv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.l_prograss);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_start);
            this.Name = "SysmapForm";
            this.Text = "星图";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SysmapForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SysmapForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_prograss;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button b_csv;
    }
}