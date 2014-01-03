using System.Collections;
namespace OgameFarmer
{
    class FleetUtil
    {
        /// <summary>
        /// 把舰队种类和数量转化成http post的参数
        ///</summary>
    	internal static string FleetQuantity2PostParam(Fleet fleet)
    	{
            string returnParamString = string.Empty;
			foreach(Fleet.Ship ship in fleet.ShipList)
    		{
    			if(ship.Quantity != 0)
                {
					returnParamString += "&" + ship.Id + "=" + ship.Quantity;
                }
    		}
			return returnParamString;
    	}

        /// <summary>
        /// 把舰队目的地,目标地种类，速度档位转化成http post的参数
        ///</summary>
        internal static string FleetDestination2PostParam(FleetMission fleetMission)
        {
            string returnParamString = string.Empty;
            foreach(string s in fleetMission.Destination.ToStringArray())
            {
                returnParamString += "&" + s;
            }
            returnParamString += "&planettype=" + (int)fleetMission.DestinationType;
            returnParamString += "&speed=" + fleetMission.Speed;
            return returnParamString;
        }

        /// <summary>
        /// 把一些必要的参数从第一次的param里拷贝过来
        /// capacity2xx,consumption2xx,speed2xx
        /// </summary>
        /// <param name="fleetInfo"></param>
        /// <returns></returns>
        internal static string PullShipFloten1Params2Floten3(FleetInfo fleetInfo)
        {
            string returnParamString = string.Empty;
            foreach(Fleet.Ship ship in fleetInfo.FleetMission.Fleet.ShipList)
            {
                string ships = "ship";
                string capacity = "capacity";
                string consumption = "consumption";
                string speed = "speed";
                if (ship.Quantity > 0)
                {
                    string shipid = ships + ship.SubId;
                    string capacityid = capacity + ship.SubId;
                    string consumptionid = consumption + ship.SubId;
                    string speedid = speed + ship.SubId;
                    foreach (DictionaryEntry de in fleetInfo.FleetParams)
                    {
                        string key = de.Key.ToString();
                        if (key.StartsWith(shipid) || key.StartsWith(capacityid) || key.StartsWith(consumptionid) || key.StartsWith(speedid))
                        {
                            returnParamString += "&" + de.Key.ToString() + "=" + de.Value.ToString();
                        }
                    }
                }
            }
            return returnParamString;
        }
    }
}
