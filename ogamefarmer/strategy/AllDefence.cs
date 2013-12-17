using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OgameFarmer
{
    public class AllDefence
    {
        internal const int MAX_REQUEST_NUMBER = 5000;
        public int Metal;
        public int Crystal;
        public int HH;

        internal DefenceType defenceType;

        internal enum DefenceType
        {
            ALL,
            PAOHUI,
            METAL
        }


        /// <summary>
        /// 访问一次防御页面（以防服务器验证）
        /// </summary>
        /// <param name="ha">HttpAccesser</param>
        /// <param name="param">星球代码</param>
        internal void PrepareAccess(ref HttpAccesser ha, string param)
        {
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            ha.AccessUrl = "http://u8.cicihappy.com/ogame/buildings.php" + param + "&mode=defense&re=0";
            ha.access();
        }

        /// <summary>
        /// 最大化地使用资源去建造防御
        /// <summary>
        internal void MakeDefenceTower(HttpAccesser ha, DefenceMessager dm)
        {
            int fmenge401 = 0, fmenge402 = 0, fmenge405 = 0, fmenge406 = 0;
            switch (defenceType)
            {
                case DefenceType.ALL:
                    StrategyAll(ref fmenge401, ref fmenge402, ref fmenge405, ref fmenge406);
                    break;
                case DefenceType.PAOHUI:
                    
                    break;
                case DefenceType.METAL:

                    break;
            }
            dm.f401 = fmenge401;
            dm.f402 = fmenge402;
            dm.f405 = fmenge405;
            dm.f406 = fmenge406;
            // 如果超过上限5000，则分批处理
            ha.AccessUrl = "http://u8.cicihappy.com/ogame/buildings.php?mode=defense";
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            doAccess(ha, fmenge401, fmenge402, fmenge405, fmenge406);
        }


        /// <summary>
        /// 去建造炮台，如果超过5000则使用多次的访问来实现。
        /// </summary>
        /// <param name="ha"></param>
        /// <param name="f401"></param>
        /// <param name="f402"></param>
        /// <param name="f405"></param>
        /// <param name="f406"></param>
        private void doAccess(HttpAccesser ha, int f401, int f402, int f405, int f406)
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

        /// <summary>
        /// 战术：尽可能使用资源
        /// </summary>
        /// <param name="fmenge401"></param>
        /// <param name="fmenge402"></param>
        /// <param name="fmenge405"></param>
        /// <param name="fmenge406"></param>
        public void StrategyAll(ref int fmenge401, ref int fmenge402, ref int fmenge405, ref int fmenge406)
        {
            // 符合先建造离子炮的条件
            if (HH >= 30000 && Math.Min(Metal, Crystal) > 50000)
            {

                if (Math.Min(Metal, Crystal) / 5 * 3 > HH)
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
                fmenge402 = Math.Min(Metal / 1500, Crystal / 500);
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
        }

        /// <summary>
        /// 战术：尽可能建造炮灰，也就是先轻型激光炮，再火箭发射装置
        /// </summary>
        /// <param name="fmenge401"></param>
        /// <param name="fmenge402"></param>
        /// <param name="fmenge405"></param>
        /// <param name="fmenge406"></param>
        public void StrategyPaohui(ref int fmenge401, ref int fmenge402, ref int fmenge405, ref int fmenge406)
        {
            
        }

        /// <summary>
        /// 战术：尽可能建造炮灰，也就是先轻型激光炮，再火箭发射装置
        /// </summary>
        /// <param name="fmenge401"></param>
        /// <param name="fmenge402"></param>
        /// <param name="fmenge405"></param>
        /// <param name="fmenge406"></param>
        public void StrategyMetal(ref int fmenge401, ref int fmenge402, ref int fmenge405, ref int fmenge406)
        {

        }
    }
}
