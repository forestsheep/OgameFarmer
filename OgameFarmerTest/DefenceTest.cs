using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaxyFarmer;

namespace OgameFarmerTest
{
    class DefenceTest
    {
        // test method perpare
        delegate void Method1(ref int a, ref int b, ref int c, ref int d); 
        

        internal void RunTest()
        {
            Test_strategyAll();
        }
        
        /// <summary>
        /// 测试所有防御的各种炮台数量计算
        /// </summary>
        internal void Test_strategyAll()
        {
            while (true)
            {
                Console.WriteLine("Starting Test Method: ");
                DefenceMessager dm = new DefenceMessager();
                DefenceStrategy ds = new DefenceStrategy(DefenceStrategy.DefenceType.ALL);
                ds.StrategyMetal(100000, ref dm);
                Console.WriteLine("火箭发射装置: " + dm.Fmenge401);
                Console.WriteLine("轻型激光炮: " + dm.Fmenge402);
                Console.WriteLine("中子炮: " + dm.Fmenge405);
                Console.WriteLine("等离子炮: " + dm.Fmenge406);
            }
        }
    }
}
