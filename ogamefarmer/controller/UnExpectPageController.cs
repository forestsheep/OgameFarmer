using System.Windows.Forms;
namespace OgameFarmer
{
    internal class UnExpectPageController
    {
        //cookie过期导致返错误回页面的关键字
        private const string COOKIE_EXPIRE_KEYWORD_1 = "登录验证";
        private const string COOKIE_EXPIRE_KEYWORD_2 = "登录无效";
        private const string COOKIE_EXPIRE_KEYWORD_3 = "重启浏览器";
        private const string COOKIE_EXPIRE_KEYWORD_4 = "重新登录";

        //翻越星图重氢不够的关键字
        private const string NOT_ENOUGH_HH_KEYWORD_1 = "需要消耗50单位的重氢";
        private const string NOT_ENOUGH_HH_KEYWORD_2 = "没有足够的重氢";
        
        private static UnExpectPageController INSTANCE;

        internal static UnExpectPageController GetInstance()
        {
            if (INSTANCE == null)
            {
                return new UnExpectPageController();
            }
            else
            {
                return INSTANCE;
            }
        }

        private UnExpectPageController()
        {
            INSTANCE = this;
        }
        
        /// <summary>
        /// 检验当前页面是否正在返回cookie过期
        /// </summary>
        /// <param name="s">页面的html全文</param>
        internal void VarifyCookiePeriod(string s)
        {
            try
            {
                if (CheckCookieCondition(s))
                {
                    throw new CookieExpireException();
                }
            }
            catch (CookieExpireException ce)
            {
                MessageBox.Show(ce.ToString());
            }
        }

        internal void VarifyOutOfHH(string s)
        {
            try
            {
                if (CheckOutOfHHCondition(s))
                {
                    throw new OutOfHHException();
                }
            }
            catch (OutOfHHException ohe)
            {
                MessageBox.Show(ohe.ToString());
            }
        }

        /// <summary>
        /// cookie过期的验证条件
        /// </summary>
        /// <param name="s">页面的html全文</param>
        /// <returns>是否是cookie过期提示页面</returns>
        private bool CheckCookieCondition(string s)
        {
            //验证条件不是很好，万一有人星球取这个名字的话。。。
            if (s.Contains(COOKIE_EXPIRE_KEYWORD_1) || s.Contains(COOKIE_EXPIRE_KEYWORD_2) || s.Contains(COOKIE_EXPIRE_KEYWORD_3) ||s.Contains(COOKIE_EXPIRE_KEYWORD_4))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 重氢不够的验证条件
        /// </summary>
        /// <param name="s">页面的html全文</param>
        /// <returns>是否是重氢不够的提示页面</returns>
        internal bool CheckOutOfHHCondition(string s)
        {
            if (s.Contains(NOT_ENOUGH_HH_KEYWORD_1) || s.Contains(NOT_ENOUGH_HH_KEYWORD_2))
            {
                //maydo 切换有重氢的星球
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}