using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class Ball
    {
        #region 属性
        /// <summary>
        /// 获取或设定球名
        /// </summary>
        internal string Name;

        /// <summary>
        /// 获取或设定位置
        /// </summary>
        internal Coordinate Location;

        /// <summary>
        /// 获取或设定球的类型
        /// </summary>
        internal CoordinateType Type;

        /// <summary>
        /// 获取或设定访问此球所需要在url后面加上的参数
        /// </summary>
        internal string Prama;
        #endregion
    }
}
