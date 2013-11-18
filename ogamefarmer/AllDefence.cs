using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class AllDefence
    {
        internal static void PrepareAccess(ref HttpAccesser ha)
        {
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            ha.AccessUrl = "http://u8.cicihappy.com/ogame/buildings.php?mode=defense";
            ha.access();
        }

        internal static void spend()
        {
            //fmenge[401] 2000
            //fmenge[402] 1500 500
            //fmenge[405 2000 6000
            //fmenge[406]]  50000 50000 30000
        }
    }
}
