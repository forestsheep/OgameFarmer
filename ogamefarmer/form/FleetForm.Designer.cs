namespace GalaxyFarmer.form
{
    partial class FleetForm
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
            this.btnFleetTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFleetTest
            // 
            this.btnFleetTest.Font = new System.Drawing.Font("方正中倩繁体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFleetTest.Location = new System.Drawing.Point(86, 62);
            this.btnFleetTest.Name = "btnFleetTest";
            this.btnFleetTest.Size = new System.Drawing.Size(219, 129);
            this.btnFleetTest.TabIndex = 0;
            this.btnFleetTest.Text = "舰队测试";
            this.btnFleetTest.UseVisualStyleBackColor = true;
            this.btnFleetTest.Click += new System.EventHandler(this.btnFleetTest_Click);
            // 
            // FleetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 572);
            this.Controls.Add(this.btnFleetTest);
            this.Name = "FleetForm";
            this.Text = "FleetForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFleetTest;
    }
}