namespace OgameFarmer
{
    class CookieExpireException : OgameFarmerException
    {
        //cookie过期导致返错误回页面的关键字
        private const string COOKIE_EXPIRE_KEYWORD_1 = "登录验证";
        private const string COOKIE_EXPIRE_KEYWORD_2 = "登录无效";
        private const string COOKIE_EXPIRE_KEYWORD_3 = "重启浏览器";
        private const string COOKIE_EXPIRE_KEYWORD_4 = "重新登录";

        internal static bool Check(string s)
        {
            //TODO 验证条件不是很好，万一有人星球取这个名字的话。。。
            if (s.Contains(COOKIE_EXPIRE_KEYWORD_1) || s.Contains(COOKIE_EXPIRE_KEYWORD_2) || s.Contains(COOKIE_EXPIRE_KEYWORD_3) || s.Contains(COOKIE_EXPIRE_KEYWORD_4))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal CookieExpireException()
        { 
            //cookie过期导致返错误回页面时的错误信息
            Message = "登录已经失效，请重新登录！";
        }

        public override string ToString()
        {
            return Message;
        }

    }
}