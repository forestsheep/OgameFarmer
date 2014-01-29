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
        private const string SQL_MAX_SCAN_PROCESS = "select max([_id]) as maxid from scanprocess where not complete and universe = '{0}'";

        private const string SQL_LAST_SCAN_LOCATION = "select top 1 galaxy, solar from(select *,galaxy * 1000 + solar as xuhao from galaxymap where process = {0} and universe = '{1}' )t1 order by xuhao desc";

        private const string SQL_NEW_SCAN_PROCESS = "insert into scanprocess (universe, complete, cdate) values ('{0}', false, now())";

        private const string SQL_INSERT_BALL = "insert into galaxymap (universe, process, galaxy, solar, planet, punion, player, ballname, hasmoon, vacation, cdate) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},{9},{10})";

        private const string SQL_SCAN_OVER = "update scanprocess set complete = true where [_id] = {0}";

        internal static string SelectMaxScanProcessID()
        {
            using (OleDbConnection dbc = new OleDbConnection(DB.CONNECT_STRING))
            {
                dbc.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.SelectCommand = new OleDbCommand(string.Format(SQL_MAX_SCAN_PROCESS, Profile.UNIVERSE), dbc);
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
                adp.SelectCommand = new OleDbCommand(string.Format(SQL_LAST_SCAN_LOCATION, processid, Profile.UNIVERSE), dbc);
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

        internal static void InsertNewScanProcess()
        {
            using (OleDbConnection dbc = new OleDbConnection(DB.CONNECT_STRING))
            {
                dbc.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.InsertCommand = new OleDbCommand(string.Format(SQL_NEW_SCAN_PROCESS, Profile.UNIVERSE), dbc);
                adp.InsertCommand.ExecuteNonQuery();
            }
        }

        internal static void InsertBall(string processid, BallStarMap b)
        {
            using (OleDbConnection dbc = new OleDbConnection(DB.CONNECT_STRING))
            {
                dbc.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.InsertCommand = new OleDbCommand(string.Format(SQL_INSERT_BALL, Profile.UNIVERSE, processid, b.Location.galaxy.ToString(), b.Location.system.ToString(), b.Location.planet.ToString(),b.Union,b.Player,b.Name,b.HasMoon.ToString(),b.IsU.ToString(), "now()"), dbc);
                adp.InsertCommand.ExecuteNonQuery();
            }
        }

        internal static void ScanOver(string processid)
        {
            using (OleDbConnection dbc = new OleDbConnection(DB.CONNECT_STRING))
            {
                dbc.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.InsertCommand = new OleDbCommand(string.Format(SQL_SCAN_OVER, processid), dbc);
                adp.InsertCommand.ExecuteNonQuery();
            }
        }
    }
}
