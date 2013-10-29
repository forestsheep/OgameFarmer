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
        private const string NOT_ENOUGH_HH_DEYWORD_2 = "没有足够的重氢";

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

        // 验证当前页面，发现已知错误的话，返回错误信息。
        internal string VarifyPageContent()
        {
            string s = Txtout.Read();
            if (s.contains(COOKIE_EXPIRE_KEYWORD_1) || s.contains(COOKIE_EXPIRE_KEYWORD_2) || s.contains(COOKIE_EXPIRE_KEYWORD_3) ||s.contains(COOKIE_EXPIRE_KEYWORD_4))
            {
                return COOKIE_EXPIRE_MESSAGE;
            }
            else if (s.contains(NOT_ENOUGH_HH_KEYWORD_1) || s.contains(NOT_ENOUGH_HH_KEYWORD_2))
            {
                //maydo 切换有重氢的星球
                return NOT_ENOUGH_HH_MESSAGE;
            }
        }
    }
}