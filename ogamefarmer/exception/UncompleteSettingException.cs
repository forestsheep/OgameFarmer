﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class UncompleteSettingException : OgameFarmerException
    {
        internal UncompleteSettingException()
        { 
            Message = "没有设定url";
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
