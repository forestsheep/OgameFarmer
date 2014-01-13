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
            BallListInfo ballListInfo = new BallListInfo(this);
            ballListInfo.AccessSite();
            ballListInfo.AnalyzResponse();
            ballListEventHandler();
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
