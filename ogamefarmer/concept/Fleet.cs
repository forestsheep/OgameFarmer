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

        internal Ship202 ship202;
        internal Ship203 ship203;
        internal Ship204 ship204;
        internal Ship205 ship205;
        internal Ship206 ship206;
        internal Ship207 ship207;
        internal Ship208 ship208;
        internal Ship209 ship209;
        internal Ship210 ship210;
        internal Ship211 ship211;
        internal Ship213 ship213;
        internal Ship214 ship214;
        internal Ship215 ship215;

        internal class Ship
        {
            internal static string id;
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
        }

        /// <summary>
        /// 小型运输舰
        /// </summary>
        internal class Ship202 : Ship
        {
            static Ship202()
            {
                id = "ship202";
                NAME = "小型运输舰";
                CAPACITY = 5000;
            }
        }

        /// <summary>
        /// 大型运输舰
        /// </summary>
        internal class Ship203 : Ship
        {
            static Ship203()
            {
                id = "ship203";
                NAME = "大型运输舰";
                CAPACITY = 25000;
            }
        }

        /// <summary>
        /// 轻型战斗机
        /// </summary>
        internal class Ship204 : Ship
        {
            static Ship204()
            {
                id = "ship204";
                NAME = "轻型战斗机";
                CAPACITY = 50;
            }
        }

        /// <summary>
        /// 重型战斗机
        /// </summary>
        internal class Ship205 : Ship
        {
            static Ship205()
            {
                id = "ship205";
                NAME = "重型战斗机";
                CAPACITY = 100;
            }
        }

        /// <summary>
        /// 巡洋舰
        /// </summary>
        internal class Ship206 : Ship
        {
            static Ship206()
            {
                id = "ship206";
                NAME = "巡洋舰";
                CAPACITY = 800;
            }
        }

        /// <summary>
        /// 战列舰
        /// </summary>
        internal class Ship207 : Ship
        {
            static Ship207()
            {
                id = "ship207";
                NAME = "战列舰";
                CAPACITY = 1500;
            }
        }

        /// <summary>
        /// 殖民舰
        /// </summary>
        internal class Ship208 : Ship
        {
            static Ship208()
            {
                id = "ship208";
                NAME = "殖民舰";
                CAPACITY = 7500;
            }
        }

        /// <summary>
        /// 回收舰
        /// </summary>
        internal class Ship209 : Ship
        {
            static Ship209()
            {
                id = "ship209";
                NAME = "回收舰";
                CAPACITY = 20000;
            }
        }

        /// <summary>
        /// 间谍卫星
        /// </summary>
        internal class Ship210 : Ship
        {
            static Ship210()
            {
                id = "ship210";
                NAME = "间谍卫星";
                CAPACITY = 5;
            }
        }

        /// <summary>
        /// 轰炸机
        /// </summary>
        internal class Ship211 : Ship
        {
            static Ship211()
            {
                id = "ship211";
                NAME = "轰炸机";
                CAPACITY = 500;
            }
        }

        /// <summary>
        /// 毁灭者
        /// </summary>
        internal class Ship213 : Ship
        {
            static Ship213()
            {
                id = "ship213";
                NAME = "毁灭者";
                CAPACITY = 2000;
            }
        }

        /// <summary>
        /// 死星
        /// </summary>
        internal class Ship214 : Ship
        {
            static Ship214()
            {
                id = "ship214";
                NAME = "死星";
                CAPACITY = 1000000;
            }
        }

        /// <summary>
        /// 战斗巡洋舰
        /// </summary>
        internal class Ship215 : Ship
        {
            static Ship215()
            {
                id = "ship215";
                NAME = "战斗巡洋舰";
                CAPACITY = 750;
            }
        }

    }
}
