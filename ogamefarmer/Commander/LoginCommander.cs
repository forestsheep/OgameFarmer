using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class LoginCommander : Commander
    {
        #region 属性
        internal string Username;
        internal string Password;
        internal string Universe;

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造一个LoginCommander
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="universe">宇宙</param>
        internal LoginCommander(string username, string password, string universe)
        {
            this.Username = username;
            this.Password = password;
            this.Universe = universe;
        }
        #endregion

        public void Execute()
        {
            LoginInfoX loginInfoX = new LoginInfoX(this);
            loginInfoX.AccessSite();
            loginInfoX.AnalyzResponse();
        }
    }
}
