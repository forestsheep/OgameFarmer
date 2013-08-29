namespace OgameFarmer
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
            this.btnRunLogin = new System.Windows.Forms.Button();
            this.outputArea = new System.Windows.Forms.TextBox();
            this.btnEditAccount = new System.Windows.Forms.Button();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.l_ballname = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.l_metal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.l_metalstroe = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.l_crystal = new System.Windows.Forms.Label();
            this.l_crystalstore = new System.Windows.Forms.Label();
            this.l_hstore = new System.Windows.Forms.Label();
            this.l_h = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.l_energystore = new System.Windows.Forms.Label();
            this.l_energy = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lb_balllist = new System.Windows.Forms.ListBox();
            this.l_metal_all = new System.Windows.Forms.Label();
            this.l_crystal_all = new System.Windows.Forms.Label();
            this.l_H_all = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.l_hh_all = new System.Windows.Forms.Label();
            this.l_crystalh_all = new System.Windows.Forms.Label();
            this.l_metalh_all = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRunLogin
            // 
            this.btnRunLogin.Location = new System.Drawing.Point(12, 12);
            this.btnRunLogin.Name = "btnRunLogin";
            this.btnRunLogin.Size = new System.Drawing.Size(85, 42);
            this.btnRunLogin.TabIndex = 0;
            this.btnRunLogin.Text = "首页";
            this.btnRunLogin.UseVisualStyleBackColor = true;
            // 
            // outputArea
            // 
            this.outputArea.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.outputArea.Location = new System.Drawing.Point(736, 694);
            this.outputArea.Multiline = true;
            this.outputArea.Name = "outputArea";
            this.outputArea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputArea.Size = new System.Drawing.Size(328, 56);
            this.outputArea.TabIndex = 1;
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.Location = new System.Drawing.Point(216, 12);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.Size = new System.Drawing.Size(78, 42);
            this.btnEditAccount.TabIndex = 6;
            this.btnEditAccount.Text = "概况";
            this.btnEditAccount.UseVisualStyleBackColor = true;
            this.btnEditAccount.Click += new System.EventHandler(this.btnEditAccount_Click);
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(318, 12);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(76, 42);
            this.btnDeleteAccount.TabIndex = 6;
            this.btnDeleteAccount.Text = "登出";
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "当前星球名称";
            // 
            // l_ballname
            // 
            this.l_ballname.AutoSize = true;
            this.l_ballname.Location = new System.Drawing.Point(378, 104);
            this.l_ballname.Name = "l_ballname";
            this.l_ballname.Size = new System.Drawing.Size(41, 12);
            this.l_ballname.TabIndex = 8;
            this.l_ballname.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "金属存量";
            // 
            // l_metal
            // 
            this.l_metal.AutoSize = true;
            this.l_metal.Location = new System.Drawing.Point(378, 169);
            this.l_metal.Name = "l_metal";
            this.l_metal.Size = new System.Drawing.Size(41, 12);
            this.l_metal.TabIndex = 10;
            this.l_metal.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "金属仓库";
            // 
            // l_metalstroe
            // 
            this.l_metalstroe.AutoSize = true;
            this.l_metalstroe.Location = new System.Drawing.Point(378, 197);
            this.l_metalstroe.Name = "l_metalstroe";
            this.l_metalstroe.Size = new System.Drawing.Size(41, 12);
            this.l_metalstroe.TabIndex = 14;
            this.l_metalstroe.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(514, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "晶体存量";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(514, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "晶体仓库";
            // 
            // l_crystal
            // 
            this.l_crystal.AutoSize = true;
            this.l_crystal.Location = new System.Drawing.Point(582, 169);
            this.l_crystal.Name = "l_crystal";
            this.l_crystal.Size = new System.Drawing.Size(41, 12);
            this.l_crystal.TabIndex = 17;
            this.l_crystal.Text = "label8";
            // 
            // l_crystalstore
            // 
            this.l_crystalstore.AutoSize = true;
            this.l_crystalstore.Location = new System.Drawing.Point(582, 197);
            this.l_crystalstore.Name = "l_crystalstore";
            this.l_crystalstore.Size = new System.Drawing.Size(41, 12);
            this.l_crystalstore.TabIndex = 18;
            this.l_crystalstore.Text = "label9";
            // 
            // l_hstore
            // 
            this.l_hstore.AutoSize = true;
            this.l_hstore.Location = new System.Drawing.Point(786, 197);
            this.l_hstore.Name = "l_hstore";
            this.l_hstore.Size = new System.Drawing.Size(47, 12);
            this.l_hstore.TabIndex = 22;
            this.l_hstore.Text = "label10";
            // 
            // l_h
            // 
            this.l_h.AutoSize = true;
            this.l_h.Location = new System.Drawing.Point(786, 169);
            this.l_h.Name = "l_h";
            this.l_h.Size = new System.Drawing.Size(47, 12);
            this.l_h.TabIndex = 21;
            this.l_h.Text = "label11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(718, 197);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 20;
            this.label12.Text = "重氢仓库";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(718, 169);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 19;
            this.label13.Text = "重氢存量";
            // 
            // l_energystore
            // 
            this.l_energystore.AutoSize = true;
            this.l_energystore.Location = new System.Drawing.Point(984, 197);
            this.l_energystore.Name = "l_energystore";
            this.l_energystore.Size = new System.Drawing.Size(47, 12);
            this.l_energystore.TabIndex = 26;
            this.l_energystore.Text = "label14";
            // 
            // l_energy
            // 
            this.l_energy.AutoSize = true;
            this.l_energy.Location = new System.Drawing.Point(984, 169);
            this.l_energy.Name = "l_energy";
            this.l_energy.Size = new System.Drawing.Size(47, 12);
            this.l_energy.TabIndex = 25;
            this.l_energy.Text = "label15";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(916, 197);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 24;
            this.label16.Text = "总能量";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(916, 169);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 23;
            this.label17.Text = "当前能量";
            // 
            // lb_balllist
            // 
            this.lb_balllist.FormattingEnabled = true;
            this.lb_balllist.ItemHeight = 12;
            this.lb_balllist.Location = new System.Drawing.Point(12, 104);
            this.lb_balllist.Name = "lb_balllist";
            this.lb_balllist.Size = new System.Drawing.Size(224, 364);
            this.lb_balllist.TabIndex = 27;
            // 
            // l_metal_all
            // 
            this.l_metal_all.AutoSize = true;
            this.l_metal_all.Location = new System.Drawing.Point(304, 317);
            this.l_metal_all.Name = "l_metal_all";
            this.l_metal_all.Size = new System.Drawing.Size(41, 12);
            this.l_metal_all.TabIndex = 28;
            this.l_metal_all.Text = "label5";
            // 
            // l_crystal_all
            // 
            this.l_crystal_all.AutoSize = true;
            this.l_crystal_all.Location = new System.Drawing.Point(419, 317);
            this.l_crystal_all.Name = "l_crystal_all";
            this.l_crystal_all.Size = new System.Drawing.Size(41, 12);
            this.l_crystal_all.TabIndex = 28;
            this.l_crystal_all.Text = "label5";
            // 
            // l_H_all
            // 
            this.l_H_all.AutoSize = true;
            this.l_H_all.Location = new System.Drawing.Point(539, 317);
            this.l_H_all.Name = "l_H_all";
            this.l_H_all.Size = new System.Drawing.Size(41, 12);
            this.l_H_all.TabIndex = 28;
            this.l_H_all.Text = "label5";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(306, 278);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 34;
            this.label9.Text = "金属总量";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(407, 278);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 34;
            this.label10.Text = "晶体总量";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(539, 278);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 34;
            this.label11.Text = "重氢总量";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(537, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 38;
            this.label2.Text = "重氢总产量";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(405, 378);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 39;
            this.label5.Text = "晶体总产量";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(304, 378);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 40;
            this.label8.Text = "金属总产量";
            // 
            // l_hh_all
            // 
            this.l_hh_all.AutoSize = true;
            this.l_hh_all.Location = new System.Drawing.Point(537, 417);
            this.l_hh_all.Name = "l_hh_all";
            this.l_hh_all.Size = new System.Drawing.Size(41, 12);
            this.l_hh_all.TabIndex = 36;
            this.l_hh_all.Text = "label5";
            // 
            // l_crystalh_all
            // 
            this.l_crystalh_all.AutoSize = true;
            this.l_crystalh_all.Location = new System.Drawing.Point(417, 417);
            this.l_crystalh_all.Name = "l_crystalh_all";
            this.l_crystalh_all.Size = new System.Drawing.Size(41, 12);
            this.l_crystalh_all.TabIndex = 35;
            this.l_crystalh_all.Text = "label5";
            // 
            // l_metalh_all
            // 
            this.l_metalh_all.AutoSize = true;
            this.l_metalh_all.Location = new System.Drawing.Point(302, 417);
            this.l_metalh_all.Name = "l_metalh_all";
            this.l_metalh_all.Size = new System.Drawing.Size(41, 12);
            this.l_metalh_all.TabIndex = 37;
            this.l_metalh_all.Text = "label5";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 762);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.l_hh_all);
            this.Controls.Add(this.l_crystalh_all);
            this.Controls.Add(this.l_metalh_all);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.l_H_all);
            this.Controls.Add(this.l_crystal_all);
            this.Controls.Add(this.l_metal_all);
            this.Controls.Add(this.lb_balllist);
            this.Controls.Add(this.l_energystore);
            this.Controls.Add(this.l_energy);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.l_hstore);
            this.Controls.Add(this.l_h);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.l_crystalstore);
            this.Controls.Add(this.l_crystal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.l_metalstroe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.l_metal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.l_ballname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteAccount);
            this.Controls.Add(this.btnEditAccount);
            this.Controls.Add(this.outputArea);
            this.Controls.Add(this.btnRunLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Main";
            this.Text = "Ogame 快乐的农夫";
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Main_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRunLogin;
        private System.Windows.Forms.TextBox outputArea;
        private System.Windows.Forms.Button btnEditAccount;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_ballname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label l_metal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label l_metalstroe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label l_crystal;
        private System.Windows.Forms.Label l_crystalstore;
        private System.Windows.Forms.Label l_hstore;
        private System.Windows.Forms.Label l_h;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label l_energystore;
        private System.Windows.Forms.Label l_energy;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ListBox lb_balllist;
        private System.Windows.Forms.Label l_metal_all;
        private System.Windows.Forms.Label l_crystal_all;
        private System.Windows.Forms.Label l_H_all;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label l_hh_all;
        private System.Windows.Forms.Label l_crystalh_all;
        private System.Windows.Forms.Label l_metalh_all;
    }
}

