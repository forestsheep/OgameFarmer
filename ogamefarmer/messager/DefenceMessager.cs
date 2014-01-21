using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class DefenceMessager
    {
        internal DefenceStrategy.DefenceType defenceType;

        /// <summary>
        /// 金属上限
        /// </summary>
        internal int MetalCapacity;
        /// <summary>
        /// 晶体上限
        /// </summary>
        internal int CrystalCapacity;
        /// <summary>
        /// 重氢上限
        /// </summary>
        internal int HHCapacity;

        /// <summary>
        /// 比例 分子
        /// </summary>
        internal double RatioNumerator;
        /// <summary>
        /// 比例 分母
        /// </summary>
        internal double RatioDenominator;

        internal int progress = 0;
        internal bool isBuildOver = false;

        internal int fmenge401;
        internal int fmenge402;
        internal int fmenge405;
        internal int fmenge406;
        internal string ballname;
        
        internal String PostBuildLog()
        {
            return "在星球《" + ballname + "》上一共建造了 火箭发射装置:" + fmenge401 + "个;轻型激光炮:" + fmenge402 + "个;中子炮:" + fmenge405 + "个;等离子炮:" + fmenge406 + "个";
        }
    }
}
