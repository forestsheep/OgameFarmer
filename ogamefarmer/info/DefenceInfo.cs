using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class DefenceInfo : PageInfo
    {
        private const string PAGE_NAME = "buildings.php{0}?mode=defense&re=0";

        private DefenceCommander defenceCommander;

        internal DefenceInfo(DefenceCommander defenceCommander)
        {
            this.defenceCommander = defenceCommander;
        }

        public void AccessSite()
        {
            
        }

        public void AccessSite(string ballPram)
        {
            HttpAccesser ha = HttpAccesser.GetInstance();
            ha.AccessUrl = UrlUtil.GetUrl(String.Format(PAGE_NAME, ballPram));
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            ha.UrlParam = "";
            ha.Access();
        }

        public void AnalyzResponse()
        {

        }
    }
}
