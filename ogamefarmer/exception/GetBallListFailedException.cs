using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class GetBallListFailedException : CannotContinueException
    {
        private const string message = "获取星球列表失败，无法继续运行银河农夫。";

        public override string ToString()
        {
            return message + base.ToString();
        }
    }
}
