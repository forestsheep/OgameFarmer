namespace OgameFarmer
{
    class CookieExpireException : OgameFarmerException
    {
        //cookie过期导致返错误回页面时的错误信息
        private const string COOKIE_EXPIRE_MESSAGE = "登录已经失效，请重新登录！";

        public override string ToString()
        {
            return COOKIE_EXPIRE_MESSAGE;
        }
    }
}