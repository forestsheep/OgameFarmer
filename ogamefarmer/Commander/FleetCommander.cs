using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    /// <summary>
    /// 舰队司令
    /// </summary>
    class FleetCommander : Commander
    {
        
        #region 成员变量
        private Fleet1Info fleet1Info;
        #endregion

        #region 属性
        internal Ball Base;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造一个舰队司令
        /// 一个球给配一个舰队司令应该是一个好的选择
        /// </summary>
        /// <param name="coordinateType"></param>
        internal FleetCommander(Ball ball)
        {
            this.Base = ball;
        }
        #endregion


        /// <summary>
        /// 获取发射舰队前的一些必要的情报
        /// </summary>
        internal void GetFleetInfo(ref HttpAccesser ha)
        {
            this.fleet1Info = new Fleet1Info();
            this.fleet1Info.AccessSite();
            this.fleet1Info.AnalyzResponse();
        }

        /// <summary>
        /// 发射舰队
        /// </summary>
        internal void SendFleet(FleetMission fleetMission)
        {
            //TODO 发射舰队
            throw new SendFleetFailedException();
        }

        public void Execute()
        {

        }
    }
}
