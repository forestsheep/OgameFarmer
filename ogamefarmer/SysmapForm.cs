using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace OgameFarmer
{
    public partial class SysmapForm : Form
    {
        private StarScript ss;
        private int scanStatus;
        internal SysmapForm(StarScript ss)
        {
            InitializeComponent();
            this.ss = ss;
            this.ss.GalaxyScanSender += this.OnScanStep;
        }

        private void OnScanStep(int scanstatus)
        {
            this.scanStatus = scanstatus;
            Object[] list = { this, EventArgs.Empty };
            this.b_start.BeginInvoke(new EventHandler(ScanStepOver), list);
        }

        private void ScanStepOver(object sender, EventArgs e)
        {
            l_prograss.Text = this.scanStatus.ToString();
            if (this.scanStatus == 90499)
            {
                b_start.Enabled = true;
            }
        }

        private void b_start_Click(object sender, EventArgs e)
        {
            try
            {
                ss.run(5);
                b_start.Enabled = false;
            }
            catch (Exception ee)
            {
                ee.ToString();
            }
        }

        private void b_csv_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;data source=rank.accdb";
            try
            {
                using (OleDbConnection dbc = new OleDbConnection(connStr))
                {
                    dbc.Open();
                    OleDbDataAdapter adp = new OleDbDataAdapter();
                    adp.SelectCommand = new OleDbCommand(@"select * from newmap", dbc);
                    adp.Fill(dt);
                }
            }
            catch (System.InvalidOperationException ioe)
            {
                if (ioe.ToString().Contains("OLEDB"))
                {
                    MessageBox.Show(ConstString.suggest_db_conn_program_not_install);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            File.WriteAllText("galaxymap.csv", sb.ToString());
            MessageBox.Show("输出完毕");
        }

        private void SysmapForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void SysmapForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
