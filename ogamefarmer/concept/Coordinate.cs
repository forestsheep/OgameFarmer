using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    /// <summary>
    /// 星系坐标
    /// </summary>
    class Coordinate
    {
        /// <summary>
        /// 银河
        /// </summary>
        private int galaxy;

        /// <summary>
        /// 星系
        /// </summary>
        private int system;

        /// <summary>
        /// 星球
        /// </summary>
        private int planet;

        /// <summary>
        /// 构造一个星系坐标
        /// </summary>
        /// <param name="galaxy">银河</param>
        /// <param name="system">太阳系</param>
        /// <param name="planet">星球</param>
        internal Coordinate(int galaxy, int system, int planet)
        {
            this.galaxy = galaxy;
            this.system = system;
            this.planet = planet;
        }

        /// <summary>
        /// 作为字符串输出
        /// </summary>
        /// <returns>将以这种格式输出 银河:太阳系:星球</returns>
        public override string ToString()
        {
            return galaxy.ToString() + ":" + system.ToString() + ":" + planet.ToString();
        }

        /// <summary>
        /// 以数组的形式返回
        /// </summary>
        /// <returns>
        /// galaxy=xxx
        /// system=xxx
        /// planet=xxx
        /// </returns>
        public string[] ToStringArray()
        {
            string[] returnString = new string[3];
			returnString[0] = "galaxy=" + galaxy.ToString();
			returnString[1] = "system=" + system.ToString();
			returnString[2] = "planet=" + planet.ToString();
            return returnString;
        }

    }
}
