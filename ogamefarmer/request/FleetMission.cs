using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class FleetMission
    {

        /// <summary>
        /// 获取或设定舰队
        /// </summary>
        private Fleet fleet;
        internal Fleet Fleet
        {
            get
            {
                return fleet;
            }
            set
            {
                fleet = value;
            }
        }

        /// <summary>
        /// 获取或设定出发地
        /// </summary>
        private Coordinate depart;
        internal Coordinate Depart
        {
            get
            {
                return depart;
            }
            set
            {
                depart = value;
            }
        }

        /// <summary>
        /// 获取或设定出发地的种类：星球1；月球3
        /// </summary>
        private CoordinateType departType;
        internal CoordinateType DepartType
        {
            get
            {
                return departType;
            }
            set
            {
                departType = value;
            }
        }

        /// <summary>
        /// 获取或设定目标地
        /// </summary>
        private Coordinate destination;
        internal Coordinate Destination
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
            }
        }

        /// <summary>
        /// 获取或设定目标的种类：星球1；废墟2；月球3；
        /// </summary>
        private CoordinateType destinationType;
        internal CoordinateType DestinationType
        {
            get
            {
                return destinationType;
            }
            set
            {
                destinationType = value;
            }
        }

        /// <summary>
        /// 速度 一共10档
        /// </summary>
        private int speed;
        /// <summary>
        /// 获取或设定速度（1-10）
        /// 如超出设定范围，则默认设定为10
        /// </summary>
        internal int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value >= 1 && value <= 10)
                {
                    speed = value;
                }
                else
                {
                    speed = 10;
                }
            }
        }

        private Mission mission;
        /// <summary>
        /// 获取或设定行动的种类
        /// 攻击1，运输3，派遣4，协防5，探测6，回收8，毁月9，探险15
        /// </summary>
        internal Mission Mission
        {
            get
            {
                return mission;
            }
            set
            {
                mission = value;
            }
        }

        private int resource1;
        /// <summary>
        /// 获取或设定携带金属数量
        /// </summary>
        internal int Resource1
        {
            get
            {
                return resource1;
            }
            set
            {
                resource1 = value;
            }
        }

        private int resource2;
        /// <summary>
        /// 获取或设定携带晶体数量
        /// </summary>
        internal int Resource2
        {
            get
            {
                return resource2;
            }
            set
            {
                resource2 = value;
            }
        }

        private int resource3;
        /// <summary>
        /// 获取或设定携带重氢数量
        /// </summary>
        internal int Resource3
        {
            get
            {
                return resource3;
            }
            set
            {
                resource3 = value;
            }
        }

        private int holdingtime;
        /// <summary>
        /// 获取或设定攻击，协防的停留时间
        /// </summary>
        internal int HoldingTime
        {
            get
            {
                return holdingtime;
            }
            set
            {
                holdingtime = value;
            }
        }

        private int expeditiontime;
        /// <summary>
        /// 获取或设定探险的停留时间
        /// </summary>
        internal int ExpeditionTime
        {
            get
            {
                return expeditiontime;
            }
            set
            {
                expeditiontime = value;
            }
        }

        private int tradeid;
        /// <summary>
        /// 获取或设定贸易ID
        /// </summary>
        internal int TradeId
        {
            get
            {
                return tradeid;
            }
            set
            {
                tradeid = value;
            }
        }

        /// <summary>
        /// 最全面的构造函数
        /// </summary>
        /// <param name="fleet">舰队</param>
        /// <param name="depart">出发地</param>
        /// <param name="departType">出发地类型</param>
        /// <param name="destination">目的地</param>
        /// <param name="destinationType">目的地类型</param>
        /// <param name="speed">速度</param>
        /// <param name="mission">任务</param>
        /// <param name="holdingtime">停留时间</param>
        /// <param name="expeditiontime">探险停留时间</param>
        /// <param name="tradeid">贸易番号</param>
        internal FleetMission(Fleet fleet, Coordinate depart, CoordinateType departType, Coordinate destination, CoordinateType destinationType, int speed, Mission mission, int resource1, int resource2, int resource3, int holdingtime, int expeditiontime, int tradeid)
        {
            this.fleet = fleet;
            this.depart = depart;
            this.departType = departType;
            this.destination = destination;
            this.destinationType = destinationType;
            this.speed = speed;
            this.mission = mission;
            this.resource1 = resource1;
            this.resource2 = resource2;
            this.resource3 = resource3;
            this.holdingtime = holdingtime;
            this.expeditiontime = expeditiontime;
            this.tradeid = tradeid;
        }

        /// <summary>
        /// 获得专为运输设计的实例
        /// </summary>
        /// <param name="fleet">舰队</param>
        /// <param name="depart">出发地</param>
        /// <param name="departType">出发地类型</param>
        /// <param name="destination">目的地</param>
        /// <param name="destinationType">目的地类型</param>
        /// <param name="speed">速度</param>
        /// <param name="resource1">金属</param>
        /// <param name="resource2">晶体</param>
        /// <param name="resource3">重氢</param>
        /// <returns></returns>
        internal static FleetMission GetInstance4Transport(Fleet fleet, Coordinate depart, CoordinateType departType, Coordinate destination, CoordinateType destinationType, int speed, int resource1, int resource2, int resource3)
        {
            return new FleetMission(fleet, depart, departType, destination, destinationType, speed, Mission.TRANSPORT, resource1, resource2, resource3, 0, 0, 0);
        }
    }
}
