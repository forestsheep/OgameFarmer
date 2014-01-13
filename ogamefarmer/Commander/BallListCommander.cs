using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    internal delegate void BallListMessageSender();
    class BallListCommander : Commander
    {
        private static BallListMessageSender ballListEventHandler;

        internal BallListMessager Messager;

        internal BallListCommander(BallListMessager ballListMessage)
        {
            this.Messager = ballListMessage;
        }

        public void Execute()
        {
            try
            {
                throw new GalaxyFarmerException();
            }
            catch (Exception ee)
            {
                ee.ToString();
            }
            //try
            //{
                //BallListInfo ballListInfo = new BallListInfo(this);
                //ballListInfo.AccessSite();
                //ballListInfo.AnalyzResponse();
            //}
            //catch (GalaxyFarmerException cce)
            //{
            //    Messager.GFE = cce;
            //}
            //ballListEventHandler();
        }

        internal event BallListMessageSender BallListEvent
        {
            add
            {
                ballListEventHandler += new BallListMessageSender(value);
            }
            remove
            {
                ballListEventHandler -= new BallListMessageSender(value);
            }
        }
    }
}
