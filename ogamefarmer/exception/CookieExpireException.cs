namespace OgameFarmer
{
    class CookieExpireException : OgameFarmerException
    {
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