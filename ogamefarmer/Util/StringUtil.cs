using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class StringUtil
    {
        public static int CommaNumberToInt(string number)
        {
            string n = number.Replace(",", string.Empty);
            int i = 0;
            try
            {
                i = int.Parse(n);
            }
            catch(Exception e)
            {
                LoggerUtil.Logger.Error(e.StackTrace);
                throw new CanContinueException();
            }
            return i;
        }
    }
}
