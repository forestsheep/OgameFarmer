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
            //AllDefence allDefenceInstance = new AllDefence();
            //Method1 m1 = allDefenceInstance.StrategyAll;    
            //Console.WriteLine("Starting Test Method: " + m1.ToString() );
            
            //allDefenceInstance.Metal = 0;
            //allDefenceInstance.Crystal = 0;
            //allDefenceInstance.HH = 0;
            //Test_strategyAll_data(ref allDefenceInstance.Metal, ref allDefenceInstance.Crystal, ref allDefenceInstance.HH);
            //int f401 = 0;
            //int f402 = 0;
            //int f405 = 0;
            //int f406 = 0;
            //allDefenceInstance.StrategyAll(ref f401, ref f402, ref f405, ref f406);
            //Console.WriteLine("火箭发射装置: " + f401);
            //Console.WriteLine("轻型激光炮: " + f402);
            //Console.WriteLine("中子炮: " + f405);
            //Console.WriteLine("等离子炮: " + f406);
        }

        private void Test_strategyAll_data(ref int metal, ref int crystal, ref int hh)
        {
            metal = 473000;
            crystal = 1000000;
            hh = 255500;
            Console.WriteLine("input metal: " + metal);
            Console.WriteLine("input crystal: " + crystal);
            Console.WriteLine("input hh: " + hh);
        }
    }
}
