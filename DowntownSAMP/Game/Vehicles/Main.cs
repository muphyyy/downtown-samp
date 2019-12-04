using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DowntownSAMP.Game.Vehicles
{
    public class Main
    {
        public async static Task despawnVehicle(BasePlayer player)
        {
            foreach(var vehicle in Data.Lists.Vehicles)
            {
                if(vehicle.owner == player)
                {
                    await DbFunctions.SaveVehiclePos(vehicle.veh.Id, vehicle.veh.Position.X, vehicle.veh.Position.Y, vehicle.veh.Position.Z);
                    BaseVehicle.VehicleInternal.Instance.DestroyVehicle(vehicle.veh.Id);
                }
            }
        }
    }
}
