using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DowntownSAMP.Game.Auth
{
    public class Main
    {
        public async static Task spawnUser(BasePlayer player)
        {
            Data.Textdraws.box.Hide();
            Data.Textdraws.config.Hide();
            Data.Textdraws.downtown.Hide();
            Data.Textdraws.info.Hide();
            Data.Textdraws.login.Hide();
            Data.Textdraws.registro.Hide();
            Data.Textdraws.roleplay.Hide();
            Data.Textdraws.salir.Hide();
            Data.Textdraws.version.Hide();
            Data.Textdraws.web.Hide();

            Data.Classes.Player client = Data.Lists.Players.Find(x => x.client == player);

            player.PutCameraBehindPlayer();
            player.CancelSelectTextDraw();
            player.ToggleSpectating(false);
            player.Spawn();
            player.Position = client.lastPos;
            player.Skin = client.lastSkin;
            player.SendClientMessage("Bienvenido de vuelta a Downtown Roleplay. Recuerda que estamos en version Alpha.");

            await Game.Vehicles.DbFunctions.SpawnVehicles(player, client.idDb);
        }
    }
}
