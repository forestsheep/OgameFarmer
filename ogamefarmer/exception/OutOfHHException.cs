namespace GalaxyFarmer
{
    /// <summary>
    /// 翻阅星图时重氢不够
    /// </summary>
    class OutOfHHException : GalaxyFarmerException
    {
        //翻越星图重氢不够的关键字
        private const string NOT_ENOUGH_HH_KEYWORD_1 = "需要消耗50单位的重氢";
        private const string NOT_ENOUGH_HH_KEYWORD_2 = "没有足够的重氢";

        // TODO 不应该写在exception类里
        internal static bool Check(string s)
        {
            if (s.Contains(NOT_ENOUGH_HH_KEYWORD_1) || s.Contains(NOT_ENOUGH_HH_KEYWORD_2))
            {
                //MAYDO 切换有重氢的星球
                return true;
            }
            else
            {
                return false;
            }
        }

        internal OutOfHHException()
        {
            //翻越星图重氢不够时的错误信息
            Message = "没有足够的重氢，请保证当前星球上有足够的重氢，以保证翻阅星图不被中断。";
        }

        public override string ToString()
        {
            return Message + base.ToString();
        }
    }
}