using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.Display;

namespace DowntownSAMP
{
    public class Commands : BaseMode
    {
        [Command("veh")]
        private static void CMD_testvehicle(BasePlayer sender, VehicleModelType model)
        {
            BaseVehicle veh = BaseVehicle.CreateStatic(model, sender.Position, sender.Rotation.Z, 1, 1);
        }

        [Command("lol")]
        private static void CMD_lol(BasePlayer sender, int money)
        {
            sender.Money = money;
            Game.Inventory.Inventory.OpenInventory(sender);
        }
    }
}
