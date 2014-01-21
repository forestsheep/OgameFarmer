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
        internal DefenceCommander(DefenceMessager defenceMessage)
        {
            this.Messager = defenceMessage;
        }
        #endregion

        public void Execute()
        {
            DefenceInfo DefenceInfo = new DefenceInfo(this);

            // 取得每个星球的资源量
            ProductivityCommander producitivityCommander = new ProductivityCommander();
            producitivityCommander.ProductivityStepEvent += OnScanStepOver;
            producitivityCommander.ProductivityEvent += OnScanOver;
            producitivityCommander.Execute();

            DefenceStrategy defenceStrategy = new DefenceStrategy(Messager.defenceType);
            foreach (BallProductivity bp in producitivityCommander.Messager.BallProductivityList)
            {
                Messager.ballname = bp.Name;
                defenceStrategy.ComputeTowerAmount(bp, ref Messager);
                DefenceInfo.AccessSite(bp.Prama);
                DefenceEventHandler();
            }
            Messager.isBuildOver = true;
            DefenceEventHandler();
        }

        private void OnScanStepOver()
        {
            DefenceEventHandler();
        }

        private void OnScanOver()
        {
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
