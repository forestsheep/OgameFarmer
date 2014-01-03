using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    /// <summary>
    /// 页面访问参数设定不完全
    /// </summary>
    class UncompleteSettingException : OgameFarmerException
    {
        //TODO 怎么没有其他的变量的未设定？
        private const string NO_URL = "没有设定url";
        public override string ToString()
        {
            return NO_URL;
        }
    }
}
