using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    partial class Main
    {
        private MapCommander mapCommander;

        private void Map_Load()
        {
        }

        private void btn_continue_scan_map_Click(object sender, EventArgs e)
        {
            MapMessager mapMessager = new MapMessager();
            mapMessager.IsContinueScan = true;
            mapCommander = new MapCommander(mapMessager, OnLogin);
        }

        private void btn_scan_new_map_Click(object sender, EventArgs e)
        {
            MapMessager mapMessager = new MapMessager();
            mapMessager.IsContinueScan = false;
            mapCommander = new MapCommander(mapMessager, OnLogin);
            CommandCenter.RUN(mapCommander, this);
        }

        private void btn_map_csv_out_Click(object sender, EventArgs e)
        {

        }

        private void OnLogin()
        {
            this.BeginInvoke(new EventHandler(ResponseMap));
        }

        private void ResponseMap(object sender, EventArgs e)
        {
            l_scan_prograss.Text = mapCommander.Messager.ScanProgress;
        }
    }
}
