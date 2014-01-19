using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    internal delegate void DefenceMessageSenderX();
    class DefenceCommander : Commander
    {

        #region 成员
        private static DefenceMessageSenderX DefenceEventHandler;
        #endregion

        #region 属性
        internal DefenceMessager Messager;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造一个DefenceCommander
        /// </summary>
        /// <param name="DefenceMessager">Defence信息</param>
        internal DefenceCommander(DefenceMessager DefenceMessager)
        {
            this.Messager = DefenceMessager;
        }
        #endregion

        public void Execute()
        {
            DefenceInfo DefenceInfo = new DefenceInfo(this);
            DefenceInfo.AccessSite();
            DefenceInfo.AnalyzResponse();
            DefenceEventHandler();
        }

        internal event DefenceMessageSenderX DefenceEvent
        {
            add
            {
                DefenceEventHandler += new DefenceMessageSenderX(value);
            }
            remove
            {
                DefenceEventHandler -= new DefenceMessageSenderX(value);
            }
        }
    }
}
