using SampSharp.GameMode;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace DowntownSAMP.Data.Classes
{
    public class Player
    {
        public BasePlayer client { get; set; }
        public int idDb { get; set; }
        public string username { get; set; }
        public int age { get; set; }
        public int genre { get; set; }
        public Vector3 lastPos { get; set; }
        public int lastSkin { get; set; }
        public bool isMenuOpen { get; set; }
        public Business business { get; set; } = null;
        public Inventory inventory { get; set; }
    }
}
