using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace DowntownSAMP.Data.Classes
{
    public class Vehicle
    {
        public int idDb { get; set; }
        public BasePlayer owner { get; set; }
        public BaseVehicle veh { get; set; }
    }
}
