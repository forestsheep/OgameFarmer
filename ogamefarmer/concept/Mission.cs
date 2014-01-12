using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    enum MissionType
    {
        /// <summary>
        /// 攻击
        /// </summary>
        ATTACK = 1,

        /// <summary>
        /// 运输
        /// </summary>
        TRANSPORT = 3,

        /// <summary>
        /// 派遣
        /// </summary>
        DISPATCH = 4,

        /// <summary>
        /// 协防
        /// </summary>
        DEFENCE = 5,
        
        /// <summary>
        /// 探测
        /// </summary>
        DETECT = 6,

        /// <summary>
        /// 回收
        /// </summary>
        RECYCLE = 8,

        /// <summary>
        /// 毁月
        /// </summary>
        DESTROY_MOON = 9,

        /// <summary>
        /// 探险
        /// </summary>
        EXPEDITION = 15
    }
}
