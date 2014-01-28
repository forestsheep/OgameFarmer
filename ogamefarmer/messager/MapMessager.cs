using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class MapMessager
    {
        internal string ScanProgress
        {
            get
            {
                return "银河：" + ScanningGalaxy + " 太阳系：" + ScanningSystem;
            }
        }
        internal int ScanningGalaxy;
        internal int ScanningSystem;

        internal bool IsContinueScan;
    }
}
