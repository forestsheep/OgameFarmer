namespace OgameFarmer
{
    /// <summary>
    /// 翻阅星图时重氢不够
    /// </summary>
    class OutOfHHException : OgameFarmerException
    {
        internal OutOfHHException()
        {
            //翻越星图重氢不够时的错误信息
            Message = "没有足够的重氢，请保证当前星球上有足够的重氢，以保证翻阅星图不被中断。";
        }

        public override string ToString()
        {
            return Message;
        }
    }
}