using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    internal delegate void LoginMessageSenderX();
    class LoginCommander : Commander
    {
        #region 成员
        private static LoginMessageSenderX loginEventHandler;
        #endregion

        #region 属性
        internal LoginMessager Messager;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造一个LoginCommander
        /// </summary>
        /// <param name="loginMessager">login信息</param>
        internal LoginCommander(LoginMessager loginMessager, LoginMessageSenderX lm)
        {
            this.Messager = loginMessager;
            LoginEvent += lm;
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
