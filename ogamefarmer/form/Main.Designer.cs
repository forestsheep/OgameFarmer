namespace GalaxyFarmer
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        } 

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnOverview = new System.Windows.Forms.Button();
            this.noti = new System.Windows.Forms.NotifyIcon(this.components);
            this.b_dispatch = new System.Windows.Forms.Button();
            this.b_sysmap = new System.Windows.Forms.Button();
            this.btnRank = new System.Windows.Forms.Button();
            this.btnAllDefence = new System.Windows.Forms.Button();
            this.btnFleet = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOverview
            // 
            this.btnOverview.Location = new System.Drawing.Point(984, 24);
            this.btnOverview.Name = "btnOverview";
            this.btnOverview.Size = new System.Drawing.Size(78, 42);
            this.btnOverview.TabIndex = 6;
            this.btnOverview.Text = "概况统计";
            this.btnOverview.UseVisualStyleBackColor = true;
            this.btnOverview.Click += new System.EventHandler(this.btnOverview_Click);
            // 
            // noti
            // 
            this.noti.Icon = ((System.Drawing.Icon)(resources.GetObject("noti.Icon")));
            this.noti.Text = "银河农夫";
            this.noti.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // b_dispatch
            // 
            this.b_dispatch.Location = new System.Drawing.Point(935, 88);
            this.b_dispatch.Name = "b_dispatch";
            this.b_dispatch.Size = new System.Drawing.Size(127, 42);
            this.b_dispatch.TabIndex = 48;
            this.b_dispatch.Text = "资源调度(开发中）";
            this.b_dispatch.UseVisualStyleBackColor = true;
            this.b_dispatch.Visible = false;
            this.b_dispatch.Click += new System.EventHandler(this.b_dispatch_Click);
            // 
            // b_sysmap
            // 
            this.b_sysmap.Location = new System.Drawing.Point(984, 148);
            this.b_sysmap.Name = "b_sysmap";
            this.b_sysmap.Size = new System.Drawing.Size(78, 42);
            this.b_sysmap.TabIndex = 49;
            this.b_sysmap.Text = "星系图";
            this.b_sysmap.UseVisualStyleBackColor = true;
            this.b_sysmap.Click += new System.EventHandler(this.b_sysmap_Click);
            // 
            // btnRank
            // 
            this.btnRank.Location = new System.Drawing.Point(984, 212);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(78, 42);
            this.btnRank.TabIndex = 50;
            this.btnRank.Text = "死羊分析";
            this.btnRank.UseVisualStyleBackColor = true;
            this.btnRank.Click += new System.EventHandler(this.b_rank_Click);
            // 
            // btnAllDefence
            // 
            this.btnAllDefence.Location = new System.Drawing.Point(991, 274);
            this.btnAllDefence.Name = "btnAllDefence";
            this.btnAllDefence.Size = new System.Drawing.Size(71, 42);
            this.btnAllDefence.TabIndex = 51;
            this.btnAllDefence.Text = "防御";
            this.btnAllDefence.UseVisualStyleBackColor = true;
            this.btnAllDefence.Click += new System.EventHandler(this.btnAllDefence_Click);
            // 
            // btnFleet
            // 
            this.btnFleet.Location = new System.Drawing.Point(991, 339);
            this.btnFleet.Name = "btnFleet";
            this.btnFleet.Size = new System.Drawing.Size(71, 42);
            this.btnFleet.TabIndex = 52;
            this.btnFleet.Text = "舰队";
            this.btnFleet.UseVisualStyleBackColor = true;
            this.btnFleet.Click += new System.EventHandler(this.btnFleet_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(905, 566);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(897, 540);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 695);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnFleet);
            this.Controls.Add(this.btnAllDefence);
            this.Controls.Add(this.btnRank);
            this.Controls.Add(this.b_sysmap);
            this.Controls.Add(this.b_dispatch);
            this.Controls.Add(this.btnOverview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "Main";
            this.Text = "银河农夫 - 概况";
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Main_KeyPress);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOverview;
        private System.Windows.Forms.NotifyIcon noti;
        private System.Windows.Forms.Button b_dispatch;
        private System.Windows.Forms.Button b_sysmap;
        private System.Windows.Forms.Button btnRank;
        private System.Windows.Forms.Button btnAllDefence;
        private System.Windows.Forms.Button btnFleet;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

