using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class LoginMessager : Messager
    {
        internal LoginInfo loginInfo;

        internal string ReqLoginName;
        internal string ReqPassword;
        internal string ReqUniverse;
        internal bool ResIsLoginSuccess;

        internal LoginMessager(string loginName, string password, string universe)
        {
            this.ReqLoginName = loginName;
            this.ReqPassword = password;
            this.ReqUniverse = universe;
        }

    }
}
