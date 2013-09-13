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
            this.tb_yinhe = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // b_start
            // 
            this.b_start.Location = new System.Drawing.Point(21, 48);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(119, 106);
            this.b_start.TabIndex = 0;
            this.b_start.Text = "开始";
            this.b_start.UseVisualStyleBackColor = true;
            this.b_start.Click += new System.EventHandler(this.b_start_Click);
            // 
            // tb_yinhe
            // 
            this.tb_yinhe.Location = new System.Drawing.Point(21, 21);
            this.tb_yinhe.Name = "tb_yinhe";
            this.tb_yinhe.Size = new System.Drawing.Size(119, 21);
            this.tb_yinhe.TabIndex = 1;
            // 
            // SysmapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(164, 174);
            this.Controls.Add(this.tb_yinhe);
            this.Controls.Add(this.b_start);
            this.Name = "SysmapForm";
            this.Text = "SysmapForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.TextBox tb_yinhe;
    }
}