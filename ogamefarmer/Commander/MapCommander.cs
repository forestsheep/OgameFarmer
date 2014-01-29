using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    internal delegate void MapMessageSender();
    class MapCommander : Commander
    {
        private MapMessageSender mapEventHandler;

        internal MapMessager Messager;

        internal MapCommander(MapMessager mapMessager, MapMessageSender mms)
        {
            this.Messager = mapMessager;
            this.MapEvent += mms;
        }

        public void Execute()
        {
            MapInfo locationInfo = new MapInfo(this);
            locationInfo.AccessSiteMyPlanet();
            locationInfo.AnalyzResponseMyPlanet();

            if (this.Messager.IsContinueScan)
            {

            }
            else
            {
                // new scan
                DBMap.InsertNewScanProcess();
                string pid = DBMap.SelectMaxScanProcessID();
                for (int galaxy = 1; galaxy <= 9; galaxy++)
                {
                    for (int system = 1; system <= 500; system++)
                    {

                    }
                }
                locationInfo.AccessSite(3, 336);

            }

            //locationInfo.AccessSite(3,336);
            //locationInfo.AnalyzResponse(3, 336);
            //mapEventHandler();
            //string s = DBMap.SelectMaxScanProcessID();
            //int a = 0, b = 0;
            //DBMap.SelectLastScanLocation(s, ref a, ref b);
            //LoggerUtil.Logger.Debug(a);
            //LoggerUtil.Logger.Debug(b);

            //BallStarMap ball = new BallStarMap();
            //ball.Name = "haha";
            //ball.Location = new Coordinate(99, 101, 11);
            //ball.IsU = true;
            //ball.HasMoon = false;
            //ball.Union = "meng";
            //ball.Player = "pplay";
            //DBMap.InsertBall("11", ball);
            //DBMap.ScanOver("12");
        }

        private void findContinueLocation(ref int galaxy, ref int system)
        {

        }

        private void GalaxyLoop(string processid, int galaxyStart, int solarStart, OleDbDataAdapter adp, OleDbConnection dbc)
        {

        }

        internal event MapMessageSender MapEvent
        {
            add
            {
                this.mapEventHandler += new MapMessageSender(value);
            }
            remove
            {
                this.mapEventHandler -= new MapMessageSender(value);
            }
        }
    }
}
