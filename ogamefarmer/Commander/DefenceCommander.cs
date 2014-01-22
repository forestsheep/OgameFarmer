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

        private ProductivityCommander producitivityCommander;
        #endregion

        #region 属性
        internal DefenceMessager Messager;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造一个DefenceCommander
        /// </summary>
        /// <param name="DefenceMessager">Defence信息</param>
        internal DefenceCommander(DefenceMessager defenceMessage, DefenceMessageSenderX defenceMessageSenderX)
        {
            this.Messager = defenceMessage;
            this.DefenceEvent += defenceMessageSenderX; 
        }
        #endregion

        public void Execute()
        {
            DefenceInfo DefenceInfo = new DefenceInfo(this);

            // 取得每个星球的资源量
            producitivityCommander = new ProductivityCommander(OnScanOver, OnScanStepOver);
            producitivityCommander.Execute();

            DefenceStrategy defenceStrategy = new DefenceStrategy(Messager.defenceType);
            foreach (BallProductivity bp in producitivityCommander.Messager.BallProductivityList)
            {
                Messager.Ballname = bp.Name;
                defenceStrategy.ComputeTowerAmount(bp, ref Messager);
                DefenceInfo.AccessSite(bp.Prama);
                DefenceEventHandler();
            }
            Messager.IsBuildOver = true;
            DefenceEventHandler();
        }

        private void OnScanStepOver()
        {
            this.Messager.Ballname = producitivityCommander.Messager.CurrentScanBallName;
            this.Messager.IsScaning = true;
            DefenceEventHandler();
        }

        private void OnScanOver()
        {
            this.Messager.IsScaning = false;
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
