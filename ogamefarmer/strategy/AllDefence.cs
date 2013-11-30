using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OgameFarmer
{
    class AllDefence
    {
        internal const int MAX_REQUEST_NUMBER = 5000;
        internal static int Metal;
        internal static int Crystal;
        internal static int HH;

        internal static void PrepareAccess(ref HttpAccesser ha,string param)
        {
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            ha.AccessUrl = "http://u8.cicihappy.com/ogame/buildings.php" + param + "&mode=defense&re=0";
            ha.access();
        }

        /// <summary>
        /// 最大化地使用资源去建造防御
        /// <summary>
        internal static void SpendAllOnCurrentPlanet(HttpAccesser ha)
        {
            int fmenge401 = 0;
            int fmenge402 = 0;
            int fmenge405 = 0;
            int fmenge406 = 0;
            // 符合先建造离子炮的条件
            if ( HH >= 30000 && Math.Min(Metal, Crystal) > 50000)
            {
                
                if (Math.Min(Metal, Crystal) / 5 *3 > HH)
                {
                    fmenge406 = HH / 30000;    
                }
                else
                {
                    fmenge406 = Math.Min(Metal, Crystal) / 50000;
                }
                Metal = Metal - 50000 * fmenge406;
                Crystal = Crystal - 50000 * fmenge406;
            }
            // 金属太多
            if (Metal > Crystal)
            {
                fmenge402 = Math.Min(Metal/1500, Crystal /500);
                int metalLeft = Metal - 1500 * fmenge402;
                if (metalLeft >= 2000)
                {
                    fmenge401 = metalLeft / 2000;
                }
            }
            // 水晶太多
            else
            {
                fmenge405 = Math.Min(Metal / 2000, Crystal / 6000);
            }
            // 如果超过上限5000，则分批处理

            ha.AccessUrl = "http://u8.cicihappy.com/ogame/buildings.php?mode=defense";
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            doAccess(ha, fmenge401, fmenge402, fmenge405, fmenge406);
        }

        private static void doAccess(HttpAccesser ha, int f401, int f402, int f405, int f406)
        {
            int fmenge401 = 0;
            int fmenge402 = 0;
            int fmenge405 = 0;
            int fmenge406 = 0;
            if (f401 > MAX_REQUEST_NUMBER)
            {
                fmenge401 = MAX_REQUEST_NUMBER;
            }
            else
            {
                fmenge401 = f401;
            }
            if (f402 > MAX_REQUEST_NUMBER)
            {
                fmenge402 = MAX_REQUEST_NUMBER;
            }
            else
            {
                fmenge402 = f402;
            }
            if (f405 > MAX_REQUEST_NUMBER)
            {
                fmenge405 = MAX_REQUEST_NUMBER;
            }
            else
            {
                fmenge405 = f405;
            }
            if (f406 > MAX_REQUEST_NUMBER)
            {
                fmenge406 = MAX_REQUEST_NUMBER;
            }
            else
            {
                fmenge406 = f406;
            }

            f401 -= fmenge401;
            f402 -= fmenge402;
            f405 -= fmenge405;
            f406 -= fmenge406;

            ha.UrlParam = "fmenge[401]=" + fmenge401 + "&fmenge[402]=" + fmenge402 + "&fmenge[403]=0&fmenge[404]=0&fmenge[405]=" + fmenge405 + "&fmenge[406]=" + fmenge406 + "&fmenge[502]=0&fmenge[503]=0";
            ha.access();
            Thread.Sleep(3000);
            
            if (f401 == 0 && f402 == 0 && f405 == 0 && f406 == 0)
            {
                return;
            }
            else
            {
                doAccess(ha, f401, f402, f405, f406);
            }
        }
    }
}
