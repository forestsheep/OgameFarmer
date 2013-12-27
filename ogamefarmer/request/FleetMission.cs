using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class FleetMission
    {

        /// <summary>
        /// 舰队 各种舰队的总和
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
        /// 出发地
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
        /// 目标地
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
        /// 速度 一共10档
        /// </summary>
        private int speed;
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
        internal FleetMission(Fleet fleet, Coordinate destination, int speed)
        {
            this.fleet = fleet;
            this.Destination = destination;
            this.speed = speed;
        }
    }
}
