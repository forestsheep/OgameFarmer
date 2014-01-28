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

            //locationInfo.AccessSite();
            locationInfo.AnalyzResponse();
            mapEventHandler();
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
