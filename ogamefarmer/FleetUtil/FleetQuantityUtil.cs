
namespace OgameFarmer
{
    class FleetQuantityUtil
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
					returnParamString += "&" + Fleet.Ship.id + "=" + ship.Quantity;
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
            return returnParamString;
        }
    }
}
