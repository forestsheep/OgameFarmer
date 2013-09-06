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
            this.lb_ball_list = new System.Windows.Forms.ListBox();
            this.lb_cons_list = new System.Windows.Forms.ListBox();
            this.b_check = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_ball_list
            // 
            this.lb_ball_list.FormattingEnabled = true;
            this.lb_ball_list.ItemHeight = 12;
            this.lb_ball_list.Location = new System.Drawing.Point(38, 59);
            this.lb_ball_list.Name = "lb_ball_list";
            this.lb_ball_list.Size = new System.Drawing.Size(224, 340);
            this.lb_ball_list.TabIndex = 28;
            this.lb_ball_list.SelectedIndexChanged += new System.EventHandler(this.lb_ball_list_SelectedIndexChanged);
            // 
            // lb_cons_list
            // 
            this.lb_cons_list.FormattingEnabled = true;
            this.lb_cons_list.ItemHeight = 12;
            this.lb_cons_list.Location = new System.Drawing.Point(350, 59);
            this.lb_cons_list.Name = "lb_cons_list";
            this.lb_cons_list.Size = new System.Drawing.Size(224, 340);
            this.lb_cons_list.TabIndex = 29;
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
            // DispatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 621);
            this.Controls.Add(this.b_check);
            this.Controls.Add(this.lb_cons_list);
            this.Controls.Add(this.lb_ball_list);
            this.Name = "DispatchForm";
            this.Text = "快乐的农夫 - 资源调度";
            this.Load += new System.EventHandler(this.DispatchForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_ball_list;
        private System.Windows.Forms.ListBox lb_cons_list;
        private System.Windows.Forms.Button b_check;

    }
}