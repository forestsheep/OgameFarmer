using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace OgameFarmer
{
    class AccessDB
    {
        private void connect()
        {
            string ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;data source=Location.mdb";

            OleDbConnection con = new OleDbConnection(ConStr);
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                MessageBox.Show("连接数据库成功");
            }
            else
            {
                MessageBox.Show("连接数据库失败");
            }
            con.Close();
        }
    }
}
