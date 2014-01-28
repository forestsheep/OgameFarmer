using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class DBMap
    {
        private const string SQL_MAX_SCAN_PROCESS = "select max([_id]) as maxid from scanprocess where not complete";

            private const string SQL_LAST_SCAN_LOCATION = "select top 1 galaxy, solar from(select *,galaxy * 1000 + solar as xuhao from galaxymap where process = {0} )t1 order by xuhao desc";

        internal static string SelectMaxScanProcessID()
        {
            using (OleDbConnection dbc = new OleDbConnection(DB.CONNECT_STRING))
            {
                dbc.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.SelectCommand = new OleDbCommand(SQL_MAX_SCAN_PROCESS, dbc);
                DataTable dt = new DataTable();
                string processid = string.Empty;
                adp.Fill(dt);
                if (dt.Rows.Count > 0 && !dt.Rows[0][0].ToString().Equals(string.Empty))
                {
                    processid = dt.Rows[0][0].ToString();
                }
                return processid;
            }
        }

        internal static void SelectLastScanLocation(string processid, ref int startGalaxy, ref int startSystem)
        {
            using (OleDbConnection dbc = new OleDbConnection(DB.CONNECT_STRING))
            {
                dbc.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.SelectCommand = new OleDbCommand(String.Format(SQL_LAST_SCAN_LOCATION, processid), dbc);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    startGalaxy = 1;
                    startSystem = 1;
                }
                else
                {
                    startGalaxy = StringUtil.ToInt(dt.Rows[0][0].ToString());
                    startSystem = StringUtil.ToInt(dt.Rows[0][1].ToString());
                }
            }
        }
    }
}
