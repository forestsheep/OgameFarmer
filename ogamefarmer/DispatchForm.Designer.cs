namespace OgameFarmer
{
    partial class DispatchForm
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
            this.components = new System.ComponentModel.Container();
            this.lb_ball_list = new System.Windows.Forms.ListBox();
            this.lb_cons_list = new System.Windows.Forms.ListBox();
            this.b_check = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.l_nextM = new System.Windows.Forms.Label();
            this.l_nextC = new System.Windows.Forms.Label();
            this.l_needM = new System.Windows.Forms.Label();
            this.l_needC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_ball_list
            // 
            this.lb_ball_list.FormattingEnabled = true;
            this.lb_ball_list.ItemHeight = 12;
            this.lb_ball_list.Location = new System.Drawing.Point(38, 59);
            this.lb_ball_list.Name = "lb_ball_list";
            this.lb_ball_list.Size = new System.Drawing.Size(182, 340);
            this.lb_ball_list.TabIndex = 28;
            this.lb_ball_list.SelectedIndexChanged += new System.EventHandler(this.lb_ball_list_SelectedIndexChanged);
            // 
            // lb_cons_list
            // 
            this.lb_cons_list.FormattingEnabled = true;
            this.lb_cons_list.ItemHeight = 12;
            this.lb_cons_list.Location = new System.Drawing.Point(256, 59);
            this.lb_cons_list.Name = "lb_cons_list";
            this.lb_cons_list.Size = new System.Drawing.Size(221, 340);
            this.lb_cons_list.TabIndex = 29;
            this.lb_cons_list.SelectedIndexChanged += new System.EventHandler(this.lb_cons_list_SelectedIndexChanged);
            // 
            // b_check
            // 
            this.b_check.Location = new System.Drawing.Point(38, 440);
            this.b_check.Name = "b_check";
            this.b_check.Size = new System.Drawing.Size(118, 56);
            this.b_check.TabIndex = 30;
            this.b_check.Text = "扫描建筑";
            this.b_check.UseVisualStyleBackColor = true;
            this.b_check.Click += new System.EventHandler(this.b_check_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // l_nextM
            // 
            this.l_nextM.AutoSize = true;
            this.l_nextM.Location = new System.Drawing.Point(608, 77);
            this.l_nextM.Name = "l_nextM";
            this.l_nextM.Size = new System.Drawing.Size(41, 12);
            this.l_nextM.TabIndex = 31;
            this.l_nextM.Text = "label1";
            // 
            // l_nextC
            // 
            this.l_nextC.AutoSize = true;
            this.l_nextC.Location = new System.Drawing.Point(764, 77);
            this.l_nextC.Name = "l_nextC";
            this.l_nextC.Size = new System.Drawing.Size(41, 12);
            this.l_nextC.TabIndex = 32;
            this.l_nextC.Text = "label2";
            // 
            // l_needM
            // 
            this.l_needM.AutoSize = true;
            this.l_needM.Location = new System.Drawing.Point(610, 142);
            this.l_needM.Name = "l_needM";
            this.l_needM.Size = new System.Drawing.Size(41, 12);
            this.l_needM.TabIndex = 33;
            this.l_needM.Text = "label3";
            // 
            // l_needC
            // 
            this.l_needC.AutoSize = true;
            this.l_needC.Location = new System.Drawing.Point(766, 142);
            this.l_needC.Name = "l_needC";
            this.l_needC.Size = new System.Drawing.Size(41, 12);
            this.l_needC.TabIndex = 34;
            this.l_needC.Text = "label4";
            // 
            // DispatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 621);
            this.Controls.Add(this.l_needC);
            this.Controls.Add(this.l_needM);
            this.Controls.Add(this.l_nextC);
            this.Controls.Add(this.l_nextM);
            this.Controls.Add(this.b_check);
            this.Controls.Add(this.lb_cons_list);
            this.Controls.Add(this.lb_ball_list);
            this.Name = "DispatchForm";
            this.Text = "快乐的农夫 - 资源调度";
            this.Load += new System.EventHandler(this.DispatchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_ball_list;
        private System.Windows.Forms.ListBox lb_cons_list;
        private System.Windows.Forms.Button b_check;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label l_nextM;
        private System.Windows.Forms.Label l_nextC;
        private System.Windows.Forms.Label l_needM;
        private System.Windows.Forms.Label l_needC;

    }
}