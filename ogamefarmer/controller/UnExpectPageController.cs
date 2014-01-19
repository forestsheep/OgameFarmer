using System.Windows.Forms;
namespace GalaxyFarmer
{
    internal class UnExpectPageController
    {
        private static UnExpectPageController INSTANCE;

        internal static void Varify()
        {
            string html = Txtout.Read();
            UnExpectPageController.GetInstance().VarifyAll(html);
        }

        private static UnExpectPageController GetInstance()
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

        internal void VarifyAll(string s)
        {
            this.VarifyCookiePeriod(s);
            this.VarifyOutOfHH(s);
        }

        /// <summary>
        /// 检验当前页面是否正在返回cookie过期
        /// </summary>
        /// <param name="s">页面的html全文</param>
        internal void VarifyCookiePeriod(string s)
        {
            CookieExpireException.Check(s);
        }

        /// <summary>
        /// 检验当前页面是否不够重氢来翻阅星系图
        /// </summary>
        /// <param name="s">页面的html全文</param>
        internal void VarifyOutOfHH(string s)
        {
            OutOfHHException.Check(s);
        }
    }
}