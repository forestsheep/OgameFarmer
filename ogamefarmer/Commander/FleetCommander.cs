using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    /// <summary>
    /// 舰队司令
    /// </summary>
    class FleetCommander
    {
        
        #region 成员变量
        private Coordinate coordinate;
        private CoordinateType coordinateType;
        private Fleet1Info fleet1Info;
        #endregion

        #region 构造函数
        internal FleetCommander(CoordinateType coordinateType)
        {

        }
        #endregion


        /// <summary>
        /// 获取发射舰队前的一些必要的情报
        /// </summary>
        internal void GetFleetInfo(ref HttpAccesser ha)
        {
            this.fleet1Info = new Fleet1Info();
            this.fleet1Info.AccessSite(ref ha);
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
    }
}
