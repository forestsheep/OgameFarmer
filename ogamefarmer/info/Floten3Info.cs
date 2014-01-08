using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class Floten3Info : CommonInfo
    {
        private static HttpAccesser PerpareHttpAccesserFloten3(HttpAccesser ha, FleetInfo fleetInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(StarScript.universe);
            sb.Append(".cicihappy.com/ogame/floten3.php");
            ha.AccessUrl = sb.ToString();
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            int i = 0;
            ha.UrlParam = string.Empty;
            foreach (DictionaryEntry de in fleetInfo.Floten2Params)
            {
                if (i != 0)
                {
                    ha.UrlParam += "&";
                }
                ha.UrlParam += de.Key.ToString() + "=" + de.Value.ToString();
                i++;
            }

            foreach (DictionaryEntry de in fleetInfo.Floten1Params)
            {
                if (de.Key.Equals("thisgalaxy") || de.Key.Equals("thissystem") || de.Key.Equals("thisplanet") || de.Key.Equals("thisplanettype") || de.Key.Equals("usedfleet") || de.Key.Equals("speedfactor") || de.Key.Equals("speedallsmin") || de.Key.Equals("curepedition") || de.Key.ToString().StartsWith("ship2"))
                {
                    ha.UrlParam += "&" + de.Key.ToString() + "=" + de.Value.ToString();
                    i++;
                }
            }
            foreach (DictionaryEntry de in fleetInfo.FleetParams)
            {
                if (de.Key.Equals("maxepedition"))
                {
                    ha.UrlParam += "&" + de.Key.ToString() + "=" + de.Value.ToString();
                    i++;
                }
            }
            //资源为0可以只传变量名
            ha.UrlParam += FleetUtil.PullShipFloten1ParamsToFloten3(fleetInfo);
            return ha;
        }

        private static void AnalyzHtmlFloten3(FleetInfo fleetInfo)
        {
            // 验证页面是否是未期待页面
            UnExpectPageController.Varify();
        }
    }
}
