using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class LoginMessager
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

        internal LoginMessager()
        {

        }
    }
}
