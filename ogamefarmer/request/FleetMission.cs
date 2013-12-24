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

        /// <summary>
        /// 目标地
        /// </summary>
        private Coordinate destination;

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
            }
        }
    }
}
