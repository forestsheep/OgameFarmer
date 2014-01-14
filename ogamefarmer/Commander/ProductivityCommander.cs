using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    internal delegate void ProductivityMessageSender();
    class ProductivityCommander : Commander
    {
        private ProductivityMessageSender productivityEventHandler;
        internal ProductivityMessager Messager;

        internal ProductivityCommander()
        {
            Messager = new ProductivityMessager();
            Messager.BallProductivityList = new List<BallProductivity>();
            foreach (Ball ball in Profile.BallList)
            {
                BallProductivity bp = new BallProductivity(ball);
                Messager.BallProductivityList.Add(bp);
            }
        }

        public void Execute()
        {
            ProductivityInfoX productivityInfo = new ProductivityInfoX(this);
            productivityInfo.AnalyzBalls();
            productivityEventHandler();
        }

        internal event ProductivityMessageSender ProductivityEvent
        {
            add
            {
                productivityEventHandler += new ProductivityMessageSender(value);
            }
            remove
            {
                productivityEventHandler -= new ProductivityMessageSender(value);
            }
        }
    }
}
