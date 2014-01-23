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
            this.noti = new System.Windows.Forms.NotifyIcon(this.components);
            this.b_dispatch = new System.Windows.Forms.Button();
            this.b_sysmap = new System.Windows.Forms.Button();
            this.btnRank = new System.Windows.Forms.Button();
            this.btnAllDefence = new System.Windows.Forms.Button();
            this.btnFleet = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_summary = new System.Windows.Forms.TabPage();
            this.pbScanProductivityProgress = new System.Windows.Forms.ProgressBar();
            this.l_energystore = new System.Windows.Forms.Label();
            this.l_energy = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.l_h_allday = new System.Windows.Forms.Label();
            this.l_crystal_allday = new System.Windows.Forms.Label();
            this.l_metal_allday = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.l_hh_all = new System.Windows.Forms.Label();
            this.l_crystalh_all = new System.Windows.Forms.Label();
            this.l_metalh_all = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.l_H_all = new System.Windows.Forms.Label();
            this.l_crystal_all = new System.Windows.Forms.Label();
            this.l_metal_all = new System.Windows.Forms.Label();
            this.lb_ball_list = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.l_hstore = new System.Windows.Forms.Label();
            this.l_h = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.l_crystalstore = new System.Windows.Forms.Label();
            this.l_crystal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.l_metalstroe = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.l_metal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInfoCollect = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbReserve = new System.Windows.Forms.GroupBox();
            this.tbHHReserve = new System.Windows.Forms.TextBox();
            this.tbCrystalReserve = new System.Windows.Forms.TextBox();
            this.lHHReserve = new System.Windows.Forms.Label();
            this.lCrystalReserve = new System.Windows.Forms.Label();
            this.tbMetalReserve = new System.Windows.Forms.TextBox();
            this.lMetalReserve = new System.Windows.Forms.Label();
            this.gbCapacity = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDenominator = new System.Windows.Forms.TextBox();
            this.tbNumerator = new System.Windows.Forms.TextBox();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rb13 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rb23 = new System.Windows.Forms.RadioButton();
            this.tbDefenceLog = new System.Windows.Forms.TextBox();
            this.pbDefence = new System.Windows.Forms.ProgressBar();
            this.ss = new System.Windows.Forms.StatusStrip();
            this.tsslStrategyDescription = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbStrategy = new System.Windows.Forms.GroupBox();
            this.rbMetal = new System.Windows.Forms.RadioButton();
            this.rbPaohui = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.btnMakeTower = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage_summary.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbReserve.SuspendLayout();
            this.gbCapacity.SuspendLayout();
            this.ss.SuspendLayout();
            this.gbStrategy.SuspendLayout();
            this.SuspendLayout();
            // 
            // noti
            // 
            this.noti.Icon = ((System.Drawing.Icon)(resources.GetObject("noti.Icon")));
            this.noti.Text = "银河农夫";
            this.noti.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // b_dispatch
            // 
            this.b_dispatch.Location = new System.Drawing.Point(1262, 126);
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
            this.b_sysmap.Location = new System.Drawing.Point(1311, 186);
            this.b_sysmap.Name = "b_sysmap";
            this.b_sysmap.Size = new System.Drawing.Size(78, 42);
            this.b_sysmap.TabIndex = 49;
            this.b_sysmap.Text = "星系图";
            this.b_sysmap.UseVisualStyleBackColor = true;
            this.b_sysmap.Click += new System.EventHandler(this.b_sysmap_Click);
            // 
            // btnRank
            // 
            this.btnRank.Location = new System.Drawing.Point(1311, 250);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(78, 42);
            this.btnRank.TabIndex = 50;
            this.btnRank.Text = "死羊分析";
            this.btnRank.UseVisualStyleBackColor = true;
            this.btnRank.Click += new System.EventHandler(this.b_rank_Click);
            // 
            // btnAllDefence
            // 
            this.btnAllDefence.Location = new System.Drawing.Point(1318, 312);
            this.btnAllDefence.Name = "btnAllDefence";
            this.btnAllDefence.Size = new System.Drawing.Size(71, 42);
            this.btnAllDefence.TabIndex = 51;
            this.btnAllDefence.Text = "防御";
            this.btnAllDefence.UseVisualStyleBackColor = true;
            this.btnAllDefence.Click += new System.EventHandler(this.btnAllDefence_Click);
            // 
            // btnFleet
            // 
            this.btnFleet.Location = new System.Drawing.Point(1318, 377);
            this.btnFleet.Name = "btnFleet";
            this.btnFleet.Size = new System.Drawing.Size(71, 42);
            this.btnFleet.TabIndex = 52;
            this.btnFleet.Text = "舰队";
            this.btnFleet.UseVisualStyleBackColor = true;
            this.btnFleet.Click += new System.EventHandler(this.btnFleet_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_summary);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ItemSize = new System.Drawing.Size(72, 25);
            this.tabControl1.Location = new System.Drawing.Point(12, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1170, 720);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage_summary
            // 
            this.tabPage_summary.Controls.Add(this.pbScanProductivityProgress);
            this.tabPage_summary.Controls.Add(this.l_energystore);
            this.tabPage_summary.Controls.Add(this.l_energy);
            this.tabPage_summary.Controls.Add(this.label14);
            this.tabPage_summary.Controls.Add(this.label15);
            this.tabPage_summary.Controls.Add(this.label18);
            this.tabPage_summary.Controls.Add(this.l_h_allday);
            this.tabPage_summary.Controls.Add(this.l_crystal_allday);
            this.tabPage_summary.Controls.Add(this.l_metal_allday);
            this.tabPage_summary.Controls.Add(this.label2);
            this.tabPage_summary.Controls.Add(this.label5);
            this.tabPage_summary.Controls.Add(this.label8);
            this.tabPage_summary.Controls.Add(this.l_hh_all);
            this.tabPage_summary.Controls.Add(this.l_crystalh_all);
            this.tabPage_summary.Controls.Add(this.l_metalh_all);
            this.tabPage_summary.Controls.Add(this.label11);
            this.tabPage_summary.Controls.Add(this.label10);
            this.tabPage_summary.Controls.Add(this.label9);
            this.tabPage_summary.Controls.Add(this.l_H_all);
            this.tabPage_summary.Controls.Add(this.l_crystal_all);
            this.tabPage_summary.Controls.Add(this.l_metal_all);
            this.tabPage_summary.Controls.Add(this.lb_ball_list);
            this.tabPage_summary.Controls.Add(this.label16);
            this.tabPage_summary.Controls.Add(this.label17);
            this.tabPage_summary.Controls.Add(this.l_hstore);
            this.tabPage_summary.Controls.Add(this.l_h);
            this.tabPage_summary.Controls.Add(this.label12);
            this.tabPage_summary.Controls.Add(this.label13);
            this.tabPage_summary.Controls.Add(this.l_crystalstore);
            this.tabPage_summary.Controls.Add(this.l_crystal);
            this.tabPage_summary.Controls.Add(this.label7);
            this.tabPage_summary.Controls.Add(this.label6);
            this.tabPage_summary.Controls.Add(this.l_metalstroe);
            this.tabPage_summary.Controls.Add(this.label4);
            this.tabPage_summary.Controls.Add(this.l_metal);
            this.tabPage_summary.Controls.Add(this.label3);
            this.tabPage_summary.Controls.Add(this.btnInfoCollect);
            this.tabPage_summary.Location = new System.Drawing.Point(4, 29);
            this.tabPage_summary.Name = "tabPage_summary";
            this.tabPage_summary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_summary.Size = new System.Drawing.Size(1162, 687);
            this.tabPage_summary.TabIndex = 0;
            this.tabPage_summary.Text = "概况";
            this.tabPage_summary.UseVisualStyleBackColor = true;
            // 
            // pbScanProductivityProgress
            // 
            this.pbScanProductivityProgress.Location = new System.Drawing.Point(233, 654);
            this.pbScanProductivityProgress.Name = "pbScanProductivityProgress";
            this.pbScanProductivityProgress.Size = new System.Drawing.Size(905, 23);
            this.pbScanProductivityProgress.TabIndex = 86;
            // 
            // l_energystore
            // 
            this.l_energystore.AutoSize = true;
            this.l_energystore.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_energystore.Location = new System.Drawing.Point(1016, 149);
            this.l_energystore.Name = "l_energystore";
            this.l_energystore.Size = new System.Drawing.Size(0, 16);
            this.l_energystore.TabIndex = 85;
            // 
            // l_energy
            // 
            this.l_energy.AutoSize = true;
            this.l_energy.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_energy.Location = new System.Drawing.Point(1016, 59);
            this.l_energy.Name = "l_energy";
            this.l_energy.Size = new System.Drawing.Size(0, 16);
            this.l_energy.TabIndex = 84;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(780, 519);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 16);
            this.label14.TabIndex = 81;
            this.label14.Text = "重氢总产量(日）";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(536, 519);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(128, 16);
            this.label15.TabIndex = 82;
            this.label15.Text = "晶体总产量(日）";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label18.Location = new System.Drawing.Point(296, 519);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(128, 16);
            this.label18.TabIndex = 83;
            this.label18.Text = "金属总产量(日）";
            // 
            // l_h_allday
            // 
            this.l_h_allday.AutoSize = true;
            this.l_h_allday.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_h_allday.Location = new System.Drawing.Point(780, 551);
            this.l_h_allday.Name = "l_h_allday";
            this.l_h_allday.Size = new System.Drawing.Size(0, 16);
            this.l_h_allday.TabIndex = 79;
            // 
            // l_crystal_allday
            // 
            this.l_crystal_allday.AutoSize = true;
            this.l_crystal_allday.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_crystal_allday.Location = new System.Drawing.Point(536, 551);
            this.l_crystal_allday.Name = "l_crystal_allday";
            this.l_crystal_allday.Size = new System.Drawing.Size(0, 16);
            this.l_crystal_allday.TabIndex = 78;
            // 
            // l_metal_allday
            // 
            this.l_metal_allday.AutoSize = true;
            this.l_metal_allday.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_metal_allday.Location = new System.Drawing.Point(296, 551);
            this.l_metal_allday.Name = "l_metal_allday";
            this.l_metal_allday.Size = new System.Drawing.Size(0, 16);
            this.l_metal_allday.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(780, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 75;
            this.label2.Text = "重氢总产量(时）";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(536, 429);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 16);
            this.label5.TabIndex = 76;
            this.label5.Text = "晶体总产量(时）";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(296, 429);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 16);
            this.label8.TabIndex = 77;
            this.label8.Text = "金属总产量(时）";
            // 
            // l_hh_all
            // 
            this.l_hh_all.AutoSize = true;
            this.l_hh_all.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_hh_all.Location = new System.Drawing.Point(780, 459);
            this.l_hh_all.Name = "l_hh_all";
            this.l_hh_all.Size = new System.Drawing.Size(0, 16);
            this.l_hh_all.TabIndex = 73;
            // 
            // l_crystalh_all
            // 
            this.l_crystalh_all.AutoSize = true;
            this.l_crystalh_all.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_crystalh_all.Location = new System.Drawing.Point(536, 459);
            this.l_crystalh_all.Name = "l_crystalh_all";
            this.l_crystalh_all.Size = new System.Drawing.Size(0, 16);
            this.l_crystalh_all.TabIndex = 72;
            // 
            // l_metalh_all
            // 
            this.l_metalh_all.AutoSize = true;
            this.l_metalh_all.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_metalh_all.Location = new System.Drawing.Point(296, 459);
            this.l_metalh_all.Name = "l_metalh_all";
            this.l_metalh_all.Size = new System.Drawing.Size(0, 16);
            this.l_metalh_all.TabIndex = 74;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Fuchsia;
            this.label11.Location = new System.Drawing.Point(780, 292);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 16);
            this.label11.TabIndex = 71;
            this.label11.Text = "重氢总量";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Fuchsia;
            this.label10.Location = new System.Drawing.Point(536, 292);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 70;
            this.label10.Text = "晶体总量";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Fuchsia;
            this.label9.Location = new System.Drawing.Point(295, 292);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 69;
            this.label9.Text = "金属总量";
            // 
            // l_H_all
            // 
            this.l_H_all.AutoSize = true;
            this.l_H_all.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_H_all.Location = new System.Drawing.Point(780, 331);
            this.l_H_all.Name = "l_H_all";
            this.l_H_all.Size = new System.Drawing.Size(0, 16);
            this.l_H_all.TabIndex = 67;
            // 
            // l_crystal_all
            // 
            this.l_crystal_all.AutoSize = true;
            this.l_crystal_all.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_crystal_all.Location = new System.Drawing.Point(536, 331);
            this.l_crystal_all.Name = "l_crystal_all";
            this.l_crystal_all.Size = new System.Drawing.Size(0, 16);
            this.l_crystal_all.TabIndex = 68;
            // 
            // l_metal_all
            // 
            this.l_metal_all.AutoSize = true;
            this.l_metal_all.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_metal_all.Location = new System.Drawing.Point(295, 331);
            this.l_metal_all.Name = "l_metal_all";
            this.l_metal_all.Size = new System.Drawing.Size(0, 16);
            this.l_metal_all.TabIndex = 66;
            // 
            // lb_ball_list
            // 
            this.lb_ball_list.FormattingEnabled = true;
            this.lb_ball_list.ItemHeight = 21;
            this.lb_ball_list.Location = new System.Drawing.Point(19, 40);
            this.lb_ball_list.Name = "lb_ball_list";
            this.lb_ball_list.Size = new System.Drawing.Size(189, 634);
            this.lb_ball_list.TabIndex = 65;
            this.lb_ball_list.SelectedIndexChanged += new System.EventHandler(this.lb_ball_list_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.Coral;
            this.label16.Location = new System.Drawing.Point(902, 149);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 16);
            this.label16.TabIndex = 64;
            this.label16.Text = "总能量";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.Coral;
            this.label17.Location = new System.Drawing.Point(902, 59);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 16);
            this.label17.TabIndex = 63;
            this.label17.Text = "当前能量";
            // 
            // l_hstore
            // 
            this.l_hstore.AutoSize = true;
            this.l_hstore.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_hstore.Location = new System.Drawing.Point(788, 149);
            this.l_hstore.Name = "l_hstore";
            this.l_hstore.Size = new System.Drawing.Size(0, 16);
            this.l_hstore.TabIndex = 62;
            // 
            // l_h
            // 
            this.l_h.AutoSize = true;
            this.l_h.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_h.Location = new System.Drawing.Point(788, 59);
            this.l_h.Name = "l_h";
            this.l_h.Size = new System.Drawing.Size(0, 16);
            this.l_h.TabIndex = 61;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(695, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 16);
            this.label12.TabIndex = 60;
            this.label12.Text = "重氢仓库";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(695, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 16);
            this.label13.TabIndex = 59;
            this.label13.Text = "重氢存量";
            // 
            // l_crystalstore
            // 
            this.l_crystalstore.AutoSize = true;
            this.l_crystalstore.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_crystalstore.Location = new System.Drawing.Point(589, 151);
            this.l_crystalstore.Name = "l_crystalstore";
            this.l_crystalstore.Size = new System.Drawing.Size(0, 16);
            this.l_crystalstore.TabIndex = 58;
            // 
            // l_crystal
            // 
            this.l_crystal.AutoSize = true;
            this.l_crystal.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_crystal.Location = new System.Drawing.Point(589, 61);
            this.l_crystal.Name = "l_crystal";
            this.l_crystal.Size = new System.Drawing.Size(0, 16);
            this.l_crystal.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(499, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 56;
            this.label7.Text = "晶体仓库";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(499, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 55;
            this.label6.Text = "晶体存量";
            // 
            // l_metalstroe
            // 
            this.l_metalstroe.AutoSize = true;
            this.l_metalstroe.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_metalstroe.Location = new System.Drawing.Point(380, 149);
            this.l_metalstroe.Name = "l_metalstroe";
            this.l_metalstroe.Size = new System.Drawing.Size(0, 16);
            this.l_metalstroe.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(296, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 53;
            this.label4.Text = "金属仓库";
            // 
            // l_metal
            // 
            this.l_metal.AutoSize = true;
            this.l_metal.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_metal.Location = new System.Drawing.Point(380, 59);
            this.l_metal.Name = "l_metal";
            this.l_metal.Size = new System.Drawing.Size(0, 16);
            this.l_metal.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(296, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 51;
            this.label3.Text = "金属存量";
            // 
            // btnInfoCollect
            // 
            this.btnInfoCollect.Location = new System.Drawing.Point(1009, 555);
            this.btnInfoCollect.Name = "btnInfoCollect";
            this.btnInfoCollect.Size = new System.Drawing.Size(129, 83);
            this.btnInfoCollect.TabIndex = 48;
            this.btnInfoCollect.Text = "收集情报";
            this.btnInfoCollect.UseVisualStyleBackColor = true;
            this.btnInfoCollect.Click += new System.EventHandler(this.btnInfoCollect_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbReserve);
            this.tabPage2.Controls.Add(this.gbCapacity);
            this.tabPage2.Controls.Add(this.tbDefenceLog);
            this.tabPage2.Controls.Add(this.pbDefence);
            this.tabPage2.Controls.Add(this.ss);
            this.tabPage2.Controls.Add(this.gbStrategy);
            this.tabPage2.Controls.Add(this.btnMakeTower);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1162, 687);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "防御";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gbReserve
            // 
            this.gbReserve.Controls.Add(this.tbHHReserve);
            this.gbReserve.Controls.Add(this.tbCrystalReserve);
            this.gbReserve.Controls.Add(this.lHHReserve);
            this.gbReserve.Controls.Add(this.lCrystalReserve);
            this.gbReserve.Controls.Add(this.tbMetalReserve);
            this.gbReserve.Controls.Add(this.lMetalReserve);
            this.gbReserve.Location = new System.Drawing.Point(433, 31);
            this.gbReserve.Name = "gbReserve";
            this.gbReserve.Size = new System.Drawing.Size(209, 229);
            this.gbReserve.TabIndex = 23;
            this.gbReserve.TabStop = false;
            this.gbReserve.Text = "资源保留";
            // 
            // tbHHReserve
            // 
            this.tbHHReserve.Location = new System.Drawing.Point(80, 183);
            this.tbHHReserve.Name = "tbHHReserve";
            this.tbHHReserve.Size = new System.Drawing.Size(109, 29);
            this.tbHHReserve.TabIndex = 7;
            // 
            // tbCrystalReserve
            // 
            this.tbCrystalReserve.Location = new System.Drawing.Point(80, 106);
            this.tbCrystalReserve.Name = "tbCrystalReserve";
            this.tbCrystalReserve.Size = new System.Drawing.Size(109, 29);
            this.tbCrystalReserve.TabIndex = 6;
            // 
            // lHHReserve
            // 
            this.lHHReserve.AutoSize = true;
            this.lHHReserve.Location = new System.Drawing.Point(20, 186);
            this.lHHReserve.Name = "lHHReserve";
            this.lHHReserve.Size = new System.Drawing.Size(42, 21);
            this.lHHReserve.TabIndex = 2;
            this.lHHReserve.Text = "重氢";
            // 
            // lCrystalReserve
            // 
            this.lCrystalReserve.AutoSize = true;
            this.lCrystalReserve.Location = new System.Drawing.Point(20, 109);
            this.lCrystalReserve.Name = "lCrystalReserve";
            this.lCrystalReserve.Size = new System.Drawing.Size(42, 21);
            this.lCrystalReserve.TabIndex = 1;
            this.lCrystalReserve.Text = "晶体";
            // 
            // tbMetalReserve
            // 
            this.tbMetalReserve.Location = new System.Drawing.Point(80, 29);
            this.tbMetalReserve.Name = "tbMetalReserve";
            this.tbMetalReserve.Size = new System.Drawing.Size(109, 29);
            this.tbMetalReserve.TabIndex = 5;
            // 
            // lMetalReserve
            // 
            this.lMetalReserve.AutoSize = true;
            this.lMetalReserve.Location = new System.Drawing.Point(20, 32);
            this.lMetalReserve.Name = "lMetalReserve";
            this.lMetalReserve.Size = new System.Drawing.Size(42, 21);
            this.lMetalReserve.TabIndex = 0;
            this.lMetalReserve.Text = "金属";
            // 
            // gbCapacity
            // 
            this.gbCapacity.Controls.Add(this.label1);
            this.gbCapacity.Controls.Add(this.tbDenominator);
            this.gbCapacity.Controls.Add(this.tbNumerator);
            this.gbCapacity.Controls.Add(this.rbCustom);
            this.gbCapacity.Controls.Add(this.rb13);
            this.gbCapacity.Controls.Add(this.rb1);
            this.gbCapacity.Controls.Add(this.rb23);
            this.gbCapacity.Location = new System.Drawing.Point(711, 31);
            this.gbCapacity.Name = "gbCapacity";
            this.gbCapacity.Size = new System.Drawing.Size(191, 229);
            this.gbCapacity.TabIndex = 21;
            this.gbCapacity.TabStop = false;
            this.gbCapacity.Text = "资源用量";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "/";
            // 
            // tbDenominator
            // 
            this.tbDenominator.Location = new System.Drawing.Point(101, 184);
            this.tbDenominator.Name = "tbDenominator";
            this.tbDenominator.Size = new System.Drawing.Size(65, 29);
            this.tbDenominator.TabIndex = 3;
            // 
            // tbNumerator
            // 
            this.tbNumerator.Location = new System.Drawing.Point(23, 183);
            this.tbNumerator.Name = "tbNumerator";
            this.tbNumerator.Size = new System.Drawing.Size(47, 29);
            this.tbNumerator.TabIndex = 2;
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(23, 141);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(76, 25);
            this.rbCustom.TabIndex = 1;
            this.rbCustom.Text = "自定义";
            this.rbCustom.UseVisualStyleBackColor = true;
            this.rbCustom.CheckedChanged += new System.EventHandler(this.rbCustom_CheckedChanged);
            // 
            // rb13
            // 
            this.rb13.AutoSize = true;
            this.rb13.Location = new System.Drawing.Point(23, 104);
            this.rb13.Name = "rb13";
            this.rb13.Size = new System.Drawing.Size(53, 25);
            this.rb13.TabIndex = 1;
            this.rb13.Text = "1/3";
            this.rb13.UseVisualStyleBackColor = true;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(23, 30);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(60, 25);
            this.rb1.TabIndex = 1;
            this.rb1.TabStop = true;
            this.rb1.Text = "全部";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // rb23
            // 
            this.rb23.AutoSize = true;
            this.rb23.Location = new System.Drawing.Point(23, 67);
            this.rb23.Name = "rb23";
            this.rb23.Size = new System.Drawing.Size(53, 25);
            this.rb23.TabIndex = 1;
            this.rb23.Text = "2/3";
            this.rb23.UseVisualStyleBackColor = true;
            // 
            // tbDefenceLog
            // 
            this.tbDefenceLog.Location = new System.Drawing.Point(33, 21);
            this.tbDefenceLog.Multiline = true;
            this.tbDefenceLog.Name = "tbDefenceLog";
            this.tbDefenceLog.ReadOnly = true;
            this.tbDefenceLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDefenceLog.Size = new System.Drawing.Size(357, 582);
            this.tbDefenceLog.TabIndex = 27;
            // 
            // pbDefence
            // 
            this.pbDefence.Location = new System.Drawing.Point(33, 626);
            this.pbDefence.Name = "pbDefence";
            this.pbDefence.Size = new System.Drawing.Size(1108, 23);
            this.pbDefence.TabIndex = 22;
            // 
            // ss
            // 
            this.ss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStrategyDescription});
            this.ss.Location = new System.Drawing.Point(3, 662);
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(1156, 22);
            this.ss.TabIndex = 24;
            // 
            // tsslStrategyDescription
            // 
            this.tsslStrategyDescription.Name = "tsslStrategyDescription";
            this.tsslStrategyDescription.Size = new System.Drawing.Size(0, 17);
            // 
            // gbStrategy
            // 
            this.gbStrategy.Controls.Add(this.rbMetal);
            this.gbStrategy.Controls.Add(this.rbPaohui);
            this.gbStrategy.Controls.Add(this.rbAll);
            this.gbStrategy.Location = new System.Drawing.Point(971, 31);
            this.gbStrategy.Name = "gbStrategy";
            this.gbStrategy.Size = new System.Drawing.Size(169, 229);
            this.gbStrategy.TabIndex = 25;
            this.gbStrategy.TabStop = false;
            this.gbStrategy.Text = "建造策略";
            // 
            // rbMetal
            // 
            this.rbMetal.AutoSize = true;
            this.rbMetal.Location = new System.Drawing.Point(23, 184);
            this.rbMetal.Name = "rbMetal";
            this.rbMetal.Size = new System.Drawing.Size(108, 25);
            this.rbMetal.TabIndex = 71;
            this.rbMetal.TabStop = true;
            this.rbMetal.Text = "只使用金属";
            this.rbMetal.UseVisualStyleBackColor = true;
            this.rbMetal.CheckedChanged += new System.EventHandler(this.rbMetal_CheckedChanged);
            // 
            // rbPaohui
            // 
            this.rbPaohui.AutoSize = true;
            this.rbPaohui.Location = new System.Drawing.Point(23, 106);
            this.rbPaohui.Name = "rbPaohui";
            this.rbPaohui.Size = new System.Drawing.Size(92, 25);
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
            this.rbAll.Size = new System.Drawing.Size(108, 25);
            this.rbAll.TabIndex = 7;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "等离子优先";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // btnMakeTower
            // 
            this.btnMakeTower.Location = new System.Drawing.Point(997, 546);
            this.btnMakeTower.Name = "btnMakeTower";
            this.btnMakeTower.Size = new System.Drawing.Size(144, 57);
            this.btnMakeTower.TabIndex = 26;
            this.btnMakeTower.Text = "建造炮塔";
            this.btnMakeTower.UseVisualStyleBackColor = true;
            this.btnMakeTower.Click += new System.EventHandler(this.btnMakeTower_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 755);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnFleet);
            this.Controls.Add(this.btnAllDefence);
            this.Controls.Add(this.btnRank);
            this.Controls.Add(this.b_sysmap);
            this.Controls.Add(this.b_dispatch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Main";
            this.Text = "银河农夫 - 概况";
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Main_KeyPress);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_summary.ResumeLayout(false);
            this.tabPage_summary.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.gbReserve.ResumeLayout(false);
            this.gbReserve.PerformLayout();
            this.gbCapacity.ResumeLayout(false);
            this.gbCapacity.PerformLayout();
            this.ss.ResumeLayout(false);
            this.ss.PerformLayout();
            this.gbStrategy.ResumeLayout(false);
            this.gbStrategy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon noti;
        private System.Windows.Forms.Button b_dispatch;
        private System.Windows.Forms.Button b_sysmap;
        private System.Windows.Forms.Button btnRank;
        private System.Windows.Forms.Button btnAllDefence;
        private System.Windows.Forms.Button btnFleet;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_summary;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label l_h_allday;
        private System.Windows.Forms.Label l_crystal_allday;
        private System.Windows.Forms.Label l_metal_allday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label l_hh_all;
        private System.Windows.Forms.Label l_crystalh_all;
        private System.Windows.Forms.Label l_metalh_all;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label l_H_all;
        private System.Windows.Forms.Label l_crystal_all;
        private System.Windows.Forms.Label l_metal_all;
        private System.Windows.Forms.ListBox lb_ball_list;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label l_hstore;
        private System.Windows.Forms.Label l_h;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label l_crystalstore;
        private System.Windows.Forms.Label l_crystal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label l_metalstroe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label l_metal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInfoCollect;
        private System.Windows.Forms.Label l_energystore;
        private System.Windows.Forms.Label l_energy;
        private System.Windows.Forms.ProgressBar pbScanProductivityProgress;
        private System.Windows.Forms.GroupBox gbReserve;
        private System.Windows.Forms.TextBox tbHHReserve;
        private System.Windows.Forms.TextBox tbCrystalReserve;
        private System.Windows.Forms.Label lHHReserve;
        private System.Windows.Forms.Label lCrystalReserve;
        private System.Windows.Forms.TextBox tbMetalReserve;
        private System.Windows.Forms.Label lMetalReserve;
        private System.Windows.Forms.GroupBox gbCapacity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDenominator;
        private System.Windows.Forms.TextBox tbNumerator;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rb13;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb23;
        private System.Windows.Forms.TextBox tbDefenceLog;
        private System.Windows.Forms.ProgressBar pbDefence;
        private System.Windows.Forms.StatusStrip ss;
        private System.Windows.Forms.ToolStripStatusLabel tsslStrategyDescription;
        private System.Windows.Forms.GroupBox gbStrategy;
        private System.Windows.Forms.RadioButton rbMetal;
        private System.Windows.Forms.RadioButton rbPaohui;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.Button btnMakeTower;
    }
}

