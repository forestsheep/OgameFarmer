using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class SendFleetFailedException : GalaxyFarmerException
    {
        internal SendFleetFailedException()
        {
            Message = "发送舰队失败";
        }

        public override string ToString()
        {
            return Message + base.ToString();
        }
    }
}
