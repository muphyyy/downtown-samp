using SampSharp.GameMode;
using System;
using System.Collections.Generic;
using System.Text;

namespace DowntownSAMP.Data.Classes
{
    public class Business
    {
        public int idDb { get; set; }
        public int owner { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int safe { get; set; }
        public Vector3 position { get; set; }
        public SampSharp.Streamer.World.DynamicTextLabel label { get; set; }
        public SampSharp.Streamer.World.DynamicPickup pickup { get; set; }
        public SampSharp.Streamer.World.DynamicMapIcon icon { get; set; }
    }
}
