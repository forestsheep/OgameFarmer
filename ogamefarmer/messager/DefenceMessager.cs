using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class DefenceMessager
    {
        internal int progress = 0;
        internal bool isBuildOver = true;

        internal int f401;
        internal int f402;
        internal int f405;
        internal int f406;
        internal string ballname;
        
        internal String PostBuildLog()
        {
            return "在星球《" + ballname + "》上一共建造了 火箭发射装置:" + f401 + "个;轻型激光炮:" + f402 + "个;中子炮:" + f405 + "个;等离子炮:" + f406 + "个";
        }
    }
}
