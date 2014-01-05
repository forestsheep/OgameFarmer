using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class Fleet
    {
        private List<Ship> shipList = new List<Ship>();
		internal List<Ship> ShipList
        {
            get
            {
                return shipList;
            }
        }
        internal Fleet()
        {
            ship202 = new Ship202();
            ship203 = new Ship203();
            ship204 = new Ship204();
            ship205 = new Ship205();
            ship206 = new Ship206();
            ship207 = new Ship207();
            ship208 = new Ship208();
            ship209 = new Ship209();
            ship210 = new Ship210();
            ship211 = new Ship211();
            ship213 = new Ship213();
            ship214 = new Ship214();
            ship215 = new Ship215();
			shipList.Add(ship202);
			shipList.Add(ship203);
			shipList.Add(ship204);
			shipList.Add(ship205);
			shipList.Add(ship206);
			shipList.Add(ship207);
			shipList.Add(ship208);
			shipList.Add(ship209);
			shipList.Add(ship210);
			shipList.Add(ship211);
			shipList.Add(ship213);
			shipList.Add(ship214);
			shipList.Add(ship215);
        }
        /// <summary>
        /// 获取或设定小型运输舰
        /// </summary>
        internal Ship202 ship202;

        /// <summary>
        /// 获取或设定大型运输舰
        /// </summary>
        internal Ship203 ship203;

        /// <summary>
        /// 获取或设定轻型战斗机
        /// </summary>
        internal Ship204 ship204;

        /// <summary>
        /// 获取或设定重型战斗机
        /// </summary>
        internal Ship205 ship205;

        /// <summary>
        /// 获取或设定巡洋舰
        /// </summary>
        internal Ship206 ship206;

        /// <summary>
        /// 获取或设定战列舰
        /// </summary>
        internal Ship207 ship207;

        /// <summary>
        /// 获取或设定殖民舰
        /// </summary>
        internal Ship208 ship208;

        /// <summary>
        /// 获取或设定回收舰
        /// </summary>
        internal Ship209 ship209;

        /// <summary>
        /// 获取或设定间谍卫星
        /// </summary>
        internal Ship210 ship210;

        /// <summary>
        /// 获取或设定轰炸机
        /// </summary>
        internal Ship211 ship211;

        /// <summary>
        /// 获取或设定毁灭者
        /// </summary>
        internal Ship213 ship213;

        /// <summary>
        /// 获取或设定死星
        /// </summary>
        internal Ship214 ship214;

        /// <summary>
        /// 获取或设定战斗巡洋舰
        /// </summary>
        internal Ship215 ship215;

        internal class Ship
        {
            internal static string ID = "ship";
            internal static string NAME;
            internal static int CAPACITY;
            private int quantity;
            internal int Quantity
            {
                get
                {
                    return quantity;
                }
                set
                {
                    quantity = value;
                }
            }
            internal string id;
            internal string subid;
        }

        /// <summary>
        /// 小型运输舰
        /// </summary>
        internal class Ship202 : Ship
        {
            internal Ship202()
            {
                subid = "202";
                id = Fleet.Ship.ID + subid;
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
                subid = "203";
                id = Fleet.Ship.ID + subid;
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
                subid = "204";
                id = Fleet.Ship.ID + subid;
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
                subid = "205";
                id = Fleet.Ship.ID + subid;
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
                subid = "206";
                id = Fleet.Ship.ID + subid;
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
                subid = "207";
                id = Fleet.Ship.ID + subid;
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
                subid = "208";
                id = Fleet.Ship.ID + subid;
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
                subid = "209";
                id = Fleet.Ship.ID + subid;
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
                subid = "210";
                id = Fleet.Ship.ID + subid;
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
                subid = "211";
                id = Fleet.Ship.ID + subid;
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
                subid = "213";
                id = Fleet.Ship.ID + subid;
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
                subid = "214";
                id = Fleet.Ship.ID + subid;
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
                subid = "215";
                id = Fleet.Ship.ID + subid;
            }
            static Ship215()
            {
                NAME = "战斗巡洋舰";
                CAPACITY = 750;
            }
        }

    }
}
