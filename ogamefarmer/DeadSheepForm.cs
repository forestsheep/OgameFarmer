using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OgameFarmer
{
    public partial class DeadSheepForm : Form
    {
        private StarScript ss;
        internal DeadSheepForm(StarScript ss)
        {
            try
            {
                InitializeComponent();
                this.ss = ss;
            }
            catch (Exception ex)
            {
                MessageBox.Show("deadsheepform constructor   " + ex.ToString());
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                btnScan.Enabled = false;
                ss.run(6);
            }
            catch (Exception ee)
            {
                ee.ToString();
            }
        }

        private void bAla_Click(object sender, EventArgs e)
        {
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;data source=rank.accdb";
            try
            {
                using (OleDbConnection dbc = new OleDbConnection(connStr))
                {
                    dbc.Open();
                    DataTable dt = new DataTable();
                    OleDbDataAdapter adp = new OleDbDataAdapter();
                    adp.SelectCommand = new OleDbCommand(@"select * from deadsheep", dbc);
                    adp.SelectCommand.Parameters.AddWithValue("@fd", OleDbType.Date).Value = dtpFromDate.Value.Date.AddDays(-Int32.Parse(mtbBefore.Text));
                    adp.SelectCommand.Parameters.AddWithValue("@ffd", OleDbType.Date).Value = dtpFromDate.Value.Date.AddDays(-Int32.Parse(mtbBefore.Text) + 1);
                    adp.SelectCommand.Parameters.AddWithValue("@ld", OleDbType.Date).Value = dtpFromDate.Value.Date;
                    adp.SelectCommand.Parameters.AddWithValue("@lld", OleDbType.Date).Value = dtpFromDate.Value.Date.AddDays(1);
                    adp.SelectCommand.Parameters.AddWithValue("diffscore", OleDbType.Integer).Value = Int32.Parse(mtbAbsScore.Text);
                    adp.Fill(dt);
                    dgvDeadSheep.DataSource = dt;
                    lSheepCount.Text = dt.Rows.Count.ToString();
                }
            }
            catch (System.InvalidOperationException ioe)
            {
                if (ioe.ToString().Contains("OLEDB"))
                {
                    MessageBox.Show("您很有可能未安装数据库连接程序，建议下载并安装：\r\ndownload.microsoft.com/download/7/0/3/703ffbcb-dc0c-4e19-b0da-1463960fdcdb/AccessDatabaseEngine.exe");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DeadSheepForm_Load(object sender, EventArgs e)
        {
            dgvDeadSheep.ReadOnly = true;
        }
    }
}
