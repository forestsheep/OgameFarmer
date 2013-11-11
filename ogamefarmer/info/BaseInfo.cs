using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    /// <summary>
    /// 最基础的信息
    /// </summary>
    class BaseInfo
    {
        private bool loginSuccess;

        internal bool LoginSuccess
        {
            get { return loginSuccess; }
            set { loginSuccess = value; }
        }
    }
}
