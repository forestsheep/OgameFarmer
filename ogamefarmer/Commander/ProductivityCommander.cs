using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    internal delegate void ProductivityMessageSender();
    internal delegate void ProductivityStepMessageSender();
    class ProductivityCommander : Commander
    {
        private ProductivityMessageSender productivityEventHandler;
        private ProductivityStepMessageSender productivityStepEventHandler;
        internal ProductivityMessager Messager;

        internal ProductivityCommander(ProductivityMessageSender productivityMessageSender, ProductivityStepMessageSender productivityStepMessageSender)
        {
            productivityEventHandler += productivityMessageSender;
            productivityStepEventHandler += productivityStepMessageSender;
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
            List<BallProductivity> bps = new List<BallProductivity>();
            foreach (BallProductivity bp in this.Messager.BallProductivityList)
            {
                productivityInfo.AccessByBall(bp.Prama);
                BallProductivity bpcopy = bp;
                productivityInfo.AnalyzByBall(ref bpcopy);
                bps.Add(bpcopy);
                productivityStepEventHandler();
            }
            this.Messager.BallProductivityList = bps;
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

        internal event ProductivityStepMessageSender ProductivityStepEvent
        {
            add
            {
                productivityStepEventHandler += new ProductivityStepMessageSender(value);
            }
            remove
            {
                productivityStepEventHandler -= new ProductivityStepMessageSender(value);
            }
        }
    }
}
