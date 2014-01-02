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
        /// 攻击1，运输3，派遣4，协防5，回收8，探险15
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

        internal FleetMission(Fleet fleet, Coordinate depart, CoordinateType departType, Coordinate destination, CoordinateType destinationType, int speed, Mission mission, int holdingtime, int expeditiontime, int tradeid)
        {
            this.fleet = fleet;
            this.depart = depart;
            this.departType = departType;
            this.destination = destination;
            this.destinationType = destinationType;
            this.speed = speed;
            this.mission = mission;
            this.holdingtime = holdingtime;
            this.expeditiontime = expeditiontime;
            this.tradeid = tradeid;
        }

        internal static FleetMission GetInstance4Transport(Fleet fleet, Coordinate depart, CoordinateType departType, Coordinate destination, CoordinateType destinationType, int speed, int tradeid)
        {
            return new FleetMission(fleet, depart, departType, destination, destinationType, speed, Mission.TRANSPORT, 0, 0, tradeid);
        }
    }
}
