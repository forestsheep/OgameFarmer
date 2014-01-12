using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class LoggerUtil
    {
        internal static log4net.ILog Logger = log4net.LogManager.GetLogger("galaxylog");
    }
}
