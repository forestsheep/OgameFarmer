using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class DefenceInfo
    {
        private const string PAGE_NAME = "buildings.php{0}?mode=defense&re=0";

        private DefenceCommander defenceCommander;

        internal DefenceInfo(DefenceCommander defenceCommander)
        {
            this.defenceCommander = defenceCommander;
        }


        internal void AccessSite(string ballPram)
        {
            HttpAccesser ha = HttpAccesser.GetInstance();
            ha.AccessUrl = UrlUtil.GetUrl(String.Format(PAGE_NAME, ballPram));
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
            doAccess(defenceCommander.Messager.Fmenge401, defenceCommander.Messager.Fmenge402, defenceCommander.Messager.Fmenge405, defenceCommander.Messager.Fmenge406);
        }

        /// <summary>
        /// 去建造炮台，如果超过5000则使用多次的访问来实现。(递归)
        /// </summary>
        /// <param name="ha"></param>
        /// <param name="f401"></param>
        /// <param name="f402"></param>
        /// <param name="f405"></param>
        /// <param name="f406"></param>
        internal void doAccess(int f401, int f402, int f405, int f406)
        {
            int fmenge401 = 0;
            int fmenge402 = 0;
            int fmenge405 = 0;
            int fmenge406 = 0;
            if (f401 > ProgramStatic.MAX_DEFENCE_TOWER_NUMBER_IN_ONCE_REQUEST)
            {
                fmenge401 = ProgramStatic.MAX_DEFENCE_TOWER_NUMBER_IN_ONCE_REQUEST;
            }
            else
            {
                fmenge401 = f401;
            }
            if (f402 > ProgramStatic.MAX_DEFENCE_TOWER_NUMBER_IN_ONCE_REQUEST)
            {
                fmenge402 = ProgramStatic.MAX_DEFENCE_TOWER_NUMBER_IN_ONCE_REQUEST;
            }
            else
            {
                fmenge402 = f402;
            }
            if (f405 > ProgramStatic.MAX_DEFENCE_TOWER_NUMBER_IN_ONCE_REQUEST)
            {
                fmenge405 = ProgramStatic.MAX_DEFENCE_TOWER_NUMBER_IN_ONCE_REQUEST;
            }
            else
            {
                fmenge405 = f405;
            }
            if (f406 > ProgramStatic.MAX_DEFENCE_TOWER_NUMBER_IN_ONCE_REQUEST)
            {
                fmenge406 = ProgramStatic.MAX_DEFENCE_TOWER_NUMBER_IN_ONCE_REQUEST;
            }
            else
            {
                fmenge406 = f406;
            }

            f401 -= fmenge401;
            f402 -= fmenge402;
            f405 -= fmenge405;
            f406 -= fmenge406;

            HttpAccesser.GetInstance().UrlParam = "fmenge[401]=" + fmenge401 + "&fmenge[402]=" + fmenge402 + "&fmenge[403]=0&fmenge[404]=0&fmenge[405]=" + fmenge405 + "&fmenge[406]=" + fmenge406 + "&fmenge[502]=0&fmenge[503]=0";
            HttpAccesser.GetInstance().Access();

            if (f401 == 0 && f402 == 0 && f405 == 0 && f406 == 0)
            {
                return;
            }
            else
            {
                doAccess(f401, f402, f405, f406);
            }
        }

        internal void AnalyzResponse()
        {

        }
    }
}
