using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    public class StringUtil
    {
        public static int CommaNumberToInt(string number)
        {
            string n = number.Replace(",", string.Empty);
            int i = 0;
            try
            {
                i = int.Parse(n);
            }
            catch (Exception e)
            {
                throw new CanContinueException(e);
            }
            return i;
        }

        public static string SetToZeroIfEmpty(string s)
        {
            if (string.Empty.Equals(s))
            {
                return "0";
            }
            else
            { 
                return s; 
            }
        }
    }
}
