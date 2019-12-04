using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace DowntownSAMP.Data.Classes
{
    public class RegisterProcess
    {
        public BasePlayer player { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public int genero { get; set; } = 0;
        public int skin { get; set; }
        public int skinStatus { get; set; }

        public RegisterProcess(BasePlayer client, string pass)
        {
            player = client;
            password = pass;
        }
    }
}
