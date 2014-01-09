using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    internal delegate void LoginMessageSenderX();
    class LoginCommander : Commander
    {
        #region 成员
        private static LoginMessageSenderX loginEventHandler;
        #endregion

        #region 属性
        internal LoginMessager loginMessager;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造一个LoginCommander
        /// </summary>
        /// <param name="loginMessager">login信息</param>
        internal LoginCommander(LoginMessager loginMessager)
        {
            this.loginMessager = loginMessager;
        }
        #endregion

        public void Execute()
        {
            LoginInfoX loginInfoX = new LoginInfoX(this);
            loginInfoX.AccessSite();
            loginInfoX.AnalyzResponse();
            loginEventHandler();
        }

        internal event LoginMessageSenderX LoginEvent
        {
            add
            {
                loginEventHandler += new LoginMessageSenderX(value);
            }
            remove
            {
                loginEventHandler -= new LoginMessageSenderX(value);
            }
        }
    }
}
