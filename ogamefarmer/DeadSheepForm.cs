using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace OgameFarmer
{
    public partial class DeadSheepForm : Form
    {
        private StarScript ss;
        private DataTable dt = new DataTable();
        internal DeadSheepForm(StarScript ss)
        {
                InitializeComponent();
                this.ss = ss;
                this.ss.Rsosender += OnScanOver; 

        }

        private void ScanOver(object sender, EventArgs e)
        {
            btnScan.Enabled = true;
            btnScan.Text = "扫描最新积分";
        }

        private void OnScanOver(int overtype)
        {
            Object[] list = { this, System.EventArgs.Empty };
            this.btnScan.BeginInvoke(new EventHandler(ScanOver), list);
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                btnScan.Enabled = false;
                btnScan.Text = "正在扫描请耐心等待";
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
                    OleDbDataAdapter adp = new OleDbDataAdapter();
                    adp.SelectCommand = new OleDbCommand(@"select * from deadsheep", dbc);
                    try
                    {
                        adp.SelectCommand.Parameters.AddWithValue("@fd", OleDbType.Date).Value = dtpFromDate.Value.Date.AddDays(-Int32.Parse(tbBeforedays.Text));
                        adp.SelectCommand.Parameters.AddWithValue("@ffd", OleDbType.Date).Value = dtpFromDate.Value.Date.AddDays(-Int32.Parse(tbBeforedays.Text) + 1);
                        adp.SelectCommand.Parameters.AddWithValue("@ld", OleDbType.Date).Value = dtpFromDate.Value.Date;
                        adp.SelectCommand.Parameters.AddWithValue("@lld", OleDbType.Date).Value = dtpFromDate.Value.Date.AddDays(1);
                        adp.SelectCommand.Parameters.AddWithValue("diffscore", OleDbType.Integer).Value = Int32.Parse(tbDiffscore.Text);
                        dt.Clear();
                        adp.Fill(dt);
                        dgvDeadSheep.DataSource = dt;
                        lSheepCount.Text = dt.Rows.Count.ToString();
                    }
                    catch (FormatException fe)
                    {
                        fe.ToString();
                        MessageBox.Show("请输入数字");
                    }
                    
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

        private void ToCsv()
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("没有数据可以输出");
                return;
            }
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }
            File.WriteAllText("deadsheep.csv", sb.ToString());
            MessageBox.Show("输出完毕");
        }

        private void DeadSheepForm_Load(object sender, EventArgs e)
        {
            dgvDeadSheep.ReadOnly = true;
        }

        private void bToCsv_Click(object sender, EventArgs e)
        {
            ToCsv();
        }
    }
}
