using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class UncompleteSettingException : OgameFarmerException
    {
        private const string NO_URL = "没有设定url";
        public override string ToString()
        {
            return NO_URL;
        }
    }
}
