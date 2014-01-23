using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    public class DefenceStrategy
    {
        /// <summary>
        /// 防御类型
        /// </summary>
        public enum DefenceType
        {
            ALL,
            PAOHUI,
            METAL
        }
        internal DefenceType defenceType;
        

        public DefenceStrategy(DefenceType defenceType)
        {
            this.defenceType = defenceType;
        }

        internal void ComputeTowerAmount(BallProductivity bp, ref DefenceMessager dm)
        {
            dm.Fmenge401 = 0;
            dm.Fmenge402 = 0;
            dm.Fmenge405 = 0;
            dm.Fmenge406 = 0;
            int m = bp.Metal;
            int c = bp.Crystal;
            int h = bp.HH;
            PreCompute(bp, dm, ref m, ref c, ref h);

            switch (this.defenceType)
            {
                case DefenceType.ALL:
                    StrategyAll(m, c, h, ref dm);
                    break;
                case DefenceType.PAOHUI:
                    StrategyPaohui(m, c, ref dm);
                    break;
                case DefenceType.METAL:
                    StrategyMetal(m, ref dm);
                    break;
            }
            //StrategyMetal(m, ref dm);
        }

        private void PreCompute(BallProductivity bp, DefenceMessager dm, ref int m, ref int c, ref int h)
        {
            m -= Math.Min(m, dm.MetalCapacity);
            c -= Math.Min(c, dm.CrystalCapacity);
            h -= Math.Min(h, dm.HHCapacity);

            m = (Int32)(m * dm.RatioNumerator / dm.RatioDenominator);
            c = (Int32)(c * dm.RatioNumerator / dm.RatioDenominator);
            h = (Int32)(h * dm.RatioNumerator / dm.RatioDenominator);
        }

        /// <summary>
        /// 战术：尽可能使用资源
        /// </summary>
        /// <param name="fmenge401"></param>
        /// <param name="fmenge402"></param>
        /// <param name="fmenge405"></param>
        /// <param name="fmenge406"></param>
        public void StrategyAll(int m, int c, int h, ref DefenceMessager dm)
        {
            int metal = m;
            int crystal = c;
            // 符合先建造离子炮的条件
            if (h >= 30000 && Math.Min(metal, crystal) > 50000)
            {

                if (Math.Min(metal, crystal) / 5 * 3 > h)
                {
                    dm.Fmenge406 = h / 30000;
                }
                else
                {
                    dm.Fmenge406 = Math.Min(metal, crystal) / 50000;
                }
                metal = metal - 50000 * dm.Fmenge406;
                crystal = crystal - 50000 * dm.Fmenge406;
            }
            // 金属太多
            if (metal > crystal * 2)
            {
                dm.Fmenge402 = Math.Min(metal / 1500, crystal / 500);
                int metalLeft = metal - 1500 * dm.Fmenge402;
                if (metalLeft >= 2000)
                {
                    dm.Fmenge401 = metalLeft / 2000;
                }
            }
            // 水晶太多
            else
            {
                dm.Fmenge405 = Math.Min(metal / 2000, crystal / 6000);
            }
        }

        /// <summary>
        /// 战术：尽可能建造炮灰，也就是先轻型激光炮，再火箭发射装置
        /// </summary>
        /// <param name="fmenge401"></param>
        /// <param name="fmenge402"></param>
        /// <param name="fmenge405"></param>
        /// <param name="fmenge406"></param>
        public void StrategyPaohui(int m, int c, ref DefenceMessager dm)
        {

            int metal = m;
            int crystal = c;
            if (metal >= 1500 && crystal >= 500)
            {
                dm.Fmenge402 = Math.Min(metal / 1500, crystal / 500);
                int metalLeft = metal - 1500 * dm.Fmenge402;
                if (metalLeft >= 2000)
                {
                    dm.Fmenge401 = metalLeft / 2000;
                }
            }
        }

        /// <summary>
        /// 战术：只建造火箭发射装置
        /// </summary>
        /// <param name="fmenge401"></param>
        /// <param name="fmenge402"></param>
        /// <param name="fmenge405"></param>
        /// <param name="fmenge406"></param>
        public void StrategyMetal(int m, ref DefenceMessager dm)
        {
            if (m > 2000)
            {
                dm.Fmenge401 = m / 2000;
            }
        }
    }
}
