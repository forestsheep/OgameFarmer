namespace OgameFarmer
{
    internal class UnExpectPageController
    {
        //cookie过期导致返错误回页面的关键字
        private const string COOKIE_EXPIRE_KEYWORD_1 = "登录验证";
        private const string COOKIE_EXPIRE_KEYWORD_2 = "登录无效";
        private const string COOKIE_EXPIRE_KEYWORD_3 = "重启浏览器";
        private const string COOKIE_EXPIRE_KEYWORD_4 = "重新登录";

        //cookie过期导致返错误回页面时的错误信息
        private const string COOKIE_EXPIRE_MESSAGE = "登录已经失效，请重新登录！";

        //翻越星图重氢不够的关键字
        private const string NOT_ENOUGH_HH_KEYWORD_1 = "需要消耗50单位的重氢";
        private const string NOT_ENOUGH_HH_KEYWORD_2 = "没有足够的重氢";
        //翻越星图重氢不够时的错误信息
        private const string NOT_ENOUGH_HH_MESSAGE = "没有足够的重氢，请保证当前星球上有足够的重氢，以保证翻阅星图不被中断。";
        private static UnExpectPageController INSTANCE;

        internal static UnExpectPageController GetINSTANCE()
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
        /// </description>>
        /// <returns>cookie过期提示给用户的错误信息。null为未检测到。</returns>
        internal string VarifyCookiePeriod()
        {
            string s = Txtout.Read();
            if (CookieCheckCondition(s))
            {
                return COOKIE_EXPIRE_MESSAGE;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// cookie过期的验证条件
        /// </summary>
        /// <param name="s">页面的html全文</param>
        /// <returns>是否是cookie过期提示页面</returns>
        private bool CheckCookieCondition(string s)
        {
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
        internal string CheckOutOfHHCondition(string s)
        {
            if (s.Contains(NOT_ENOUGH_HH_KEYWORD_1) || s.Contains(NOT_ENOUGH_HH_KEYWORD_2))
            {
                //maydo 切换有重氢的星球
                return NOT_ENOUGH_HH_MESSAGE;
            }
            else
            {
                return null;
            }
        }
    }
}