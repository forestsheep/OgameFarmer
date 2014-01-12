using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class UrlUtil
    {
        private static string PAGE_URL = "http://{0}.cicihappy.com/ogame/{1}";

        internal static String GetUrl(string pageName)
        {
            return String.Format(PAGE_URL, Profile.UNIVERSE, pageName);            
        }
    }
}
