using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    /// <summary>
    /// 舰队
    /// </summary>
    class Fleet
    {
        /// <summary>
        /// 舰队列表
        /// </summary>
        private List<Ship> shipList = new List<Ship>();
        /// <summary>
        /// 取得舰队列表
        /// </summary>
		internal List<Ship> ShipList
        {
            get
            {
                return shipList;
            }
        }

        /// <summary>
        /// 构造一支舰队，初期所有舰船数量都为0
        /// </summary>
        internal Fleet()
        {
            IShip202 = new Ship202();
            IShip203 = new Ship203();
            IShip204 = new Ship204();
            IShip205 = new Ship205();
            IShip206 = new Ship206();
            IShip207 = new Ship207();
            IShip208 = new Ship208();
            IShip209 = new Ship209();
            IShip210 = new Ship210();
            IShip211 = new Ship211();
            IShip213 = new Ship213();
            IShip214 = new Ship214();
            IShip215 = new Ship215();
			shipList.Add(IShip202);
			shipList.Add(IShip203);
			shipList.Add(IShip204);
			shipList.Add(IShip205);
			shipList.Add(IShip206);
			shipList.Add(IShip207);
			shipList.Add(IShip208);
			shipList.Add(IShip209);
			shipList.Add(IShip210);
			shipList.Add(IShip211);
			shipList.Add(IShip213);
			shipList.Add(IShip214);
			shipList.Add(IShip215);
        }

        /// <summary>
        /// 获取或设定小型运输舰
        /// </summary>
        internal Ship202 IShip202;

        /// <summary>
        /// 获取或设定大型运输舰
        /// </summary>
        internal Ship203 IShip203;

        /// <summary>
        /// 获取或设定轻型战斗机
        /// </summary>
        internal Ship204 IShip204;

        /// <summary>
        /// 获取或设定重型战斗机
        /// </summary>
        internal Ship205 IShip205;

        /// <summary>
        /// 获取或设定巡洋舰
        /// </summary>
        internal Ship206 IShip206;

        /// <summary>
        /// 获取或设定战列舰
        /// </summary>
        internal Ship207 IShip207;

        /// <summary>
        /// 获取或设定殖民舰
        /// </summary>
        internal Ship208 IShip208;

        /// <summary>
        /// 获取或设定回收舰
        /// </summary>
        internal Ship209 IShip209;

        /// <summary>
        /// 获取或设定间谍卫星
        /// </summary>
        internal Ship210 IShip210;

        /// <summary>
        /// 获取或设定轰炸机
        /// </summary>
        internal Ship211 IShip211;

        /// <summary>
        /// 获取或设定毁灭者
        /// </summary>
        internal Ship213 IShip213;

        /// <summary>
        /// 获取或设定死星
        /// </summary>
        internal Ship214 IShip214;

        /// <summary>
        /// 获取或设定战斗巡洋舰
        /// </summary>
        internal Ship215 IShip215;

        internal class Ship
        {
            internal static string ID = "ship";
            internal static string NAME;
            internal static int CAPACITY;

            internal int Quantity;
            internal string Id;
            internal string SubId;
        }

        /// <summary>
        /// 小型运输舰
        /// </summary>
        internal class Ship202 : Ship
        {
            internal Ship202()
            {
                SubId = "202";
                Id = Fleet.Ship.ID + SubId;
            }
            static Ship202()
            {
                NAME = "小型运输舰";
                CAPACITY = 5000;
            }
        }

        /// <summary>
        /// 大型运输舰
        /// </summary>
        internal class Ship203 : Ship
        {
            internal Ship203()
            {
                SubId = "203";
                Id = Fleet.Ship.ID + SubId;
            }
            static Ship203()
            {
                NAME = "大型运输舰";
                CAPACITY = 25000;
            }
        }

        /// <summary>
        /// 轻型战斗机
        /// </summary>
        internal class Ship204 : Ship
        {
            internal Ship204()
            {
                SubId = "204";
                Id = Fleet.Ship.ID + SubId;
            }
            static Ship204()
            {
                NAME = "轻型战斗机";
                CAPACITY = 50;
            }
        }

        /// <summary>
        /// 重型战斗机
        /// </summary>
        internal class Ship205 : Ship
        {
            internal Ship205()
            {
                SubId = "205";
                Id = Fleet.Ship.ID + SubId;
            }
            static Ship205()
            {
                NAME = "重型战斗机";
                CAPACITY = 100;
            }
        }

        /// <summary>
        /// 巡洋舰
        /// </summary>
        internal class Ship206 : Ship
        {
            internal Ship206()
            {
                SubId = "206";
                Id = Fleet.Ship.ID + SubId;
            }
            static Ship206()
            {
                NAME = "巡洋舰";
                CAPACITY = 800;
            }
        }

        /// <summary>
        /// 战列舰
        /// </summary>
        internal class Ship207 : Ship
        {
            internal Ship207()
            {
                SubId = "207";
                Id = Fleet.Ship.ID + SubId;
            }
            static Ship207()
            {
                NAME = "战列舰";
                CAPACITY = 1500;
            }
        }

        /// <summary>
        /// 殖民舰
        /// </summary>
        internal class Ship208 : Ship
        {
            internal Ship208()
            {
                SubId = "208";
                Id = Fleet.Ship.ID + SubId;
            }
            static Ship208()
            {
                NAME = "殖民舰";
                CAPACITY = 7500;
            }
        }

        /// <summary>
        /// 回收舰
        /// </summary>
        internal class Ship209 : Ship
        {
            internal Ship209()
            {
                SubId = "209";
                Id = Fleet.Ship.ID + SubId;
            }
            static Ship209()
            {
                NAME = "回收舰";
                CAPACITY = 20000;
            }
        }

        /// <summary>
        /// 间谍卫星
        /// </summary>
        internal class Ship210 : Ship
        {
            internal Ship210()
            {
                SubId = "210";
                Id = Fleet.Ship.ID + SubId;
            }
            static Ship210()
            {
                NAME = "间谍卫星";
                CAPACITY = 5;
            }
        }

        /// <summary>
        /// 轰炸机
        /// </summary>
        internal class Ship211 : Ship
        {
            internal Ship211()
            {
                SubId = "211";
                Id = Fleet.Ship.ID + SubId;
            }
            static Ship211()
            {
                NAME = "轰炸机";
                CAPACITY = 500;
            }
        }

        /// <summary>
        /// 毁灭者
        /// </summary>
        internal class Ship213 : Ship
        {
            internal Ship213()
            {
                SubId = "213";
                Id = Fleet.Ship.ID + SubId;
            }
            static Ship213()
            {
                NAME = "毁灭者";
                CAPACITY = 2000;
            }
        }

        /// <summary>
        /// 死星
        /// </summary>
        internal class Ship214 : Ship
        {
            internal Ship214()
            {
                SubId = "214";
                Id = Fleet.Ship.ID + SubId;
            }
            static Ship214()
            {
                NAME = "死星";
                CAPACITY = 1000000;
            }
        }

        /// <summary>
        /// 战斗巡洋舰
        /// </summary>
        internal class Ship215 : Ship
        {
            internal Ship215()
            {
                SubId = "215";
                Id = Fleet.Ship.ID + SubId;
            }
            static Ship215()
            {
                NAME = "战斗巡洋舰";
                CAPACITY = 750;
            }
        }

    }
}
