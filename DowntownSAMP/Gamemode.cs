using System;
using System.Collections.Generic;
using System.Text;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.Definitions;

namespace DowntownSAMP
{
    public class GameMode : BaseMode
    {

        protected async override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            SetGameModeText("Downtown 0.1");
            SampSharp.GameMode.SAMP.Server.SetWorldTime(00);
            await Game.Business.DbFunctions.SpawnBusiness();

            Console.WriteLine("\n-----------------------------------------------");
            Console.WriteLine(" Downtown Roleplay — Developed by Muphy (v0.0.1)");
            Console.WriteLine("-----------------------------------------------\n");
        }

        protected override void LoadControllers(ControllerCollection controllers)
        {
            base.LoadControllers(controllers);
        }

        protected override void OnPlayerRequestClass(BasePlayer player, RequestClassEventArgs e)
        {
            base.OnPlayerRequestClass(player, e);

            player.ToggleSpectating(true);
            player.InterpolateCameraPosition(new Vector3(1531.179443, -916.917053, 132.871566), new Vector3(1214.361450, -1138.021850, 121.748977), 6000, CameraCut.Move);
            player.SetCameraLookAt(new Vector3(1526.842895, -915.223449, 131.047775), CameraCut.Move);
            player.SelectTextDraw(new Color(255, 255, 255));
            
            Data.Textdraws.downtown = Elements.TextDraw.textDraw(player, 258.333343, 145.185165, "Downtown", 0.589999, 2.906666, 1, -1, -2, 0, 3, 51, true, false);
            Data.Textdraws.downtown.Show();

            Data.Textdraws.roleplay = Elements.TextDraw.textDraw(player, 274.333343, 167.585159, "ROLEPLAY", 0.438999, 1.824000, 1, -2139062017, -2, 0, 2, 51, true, false);
            Data.Textdraws.roleplay.Show();

            Data.Textdraws.box = new PlayerTextDraw(player);
            Data.Textdraws.box.Position = new Vector2(514.666625, 213.470397);
            Data.Textdraws.box.LetterSize = new Vector2(0.000000, 2.310493);
            Data.Textdraws.box.Width = 121.333343f;
            Data.Textdraws.box.Height = 0.000000f;
            Data.Textdraws.box.Alignment = (TextDrawAlignment)1;
            Data.Textdraws.box.BoxColor = 102;
            Data.Textdraws.box.UseBox = true;
            Data.Textdraws.box.Shadow = 0;
            Data.Textdraws.box.Outline = 0;
            Data.Textdraws.box.Font = (TextDrawFont)0;
            Data.Textdraws.box.Show();

            Data.Textdraws.login = Elements.TextDraw.textDraw(player, 129.333465, 218.192535, "INICIAR SESION", 0.298333, 1.272297, 1, -1, 0, 1, 1, 51, true, true);
            Data.Textdraws.login.Click += Data.Response.Textdraws.loginClick;
            Data.Textdraws.login.Show();

            Data.Textdraws.registro = Elements.TextDraw.textDraw(player, 219.666625, 218.607391, "REGISTRO", 0.323666, 1.197629, 1, -1, 0, 1, 1, 51, true, true);
            Data.Textdraws.registro.Click += Data.Response.Textdraws.registerClick;
            Data.Textdraws.registro.Show();

            Data.Textdraws.config = Elements.TextDraw.textDraw(player, 282.666564, 218.607452, "CONFIGURACION", 0.315000, 1.226666, 1, -1, 0, 1, 1, 51, true, true);
            Data.Textdraws.config.Show();

            Data.Textdraws.info = Elements.TextDraw.textDraw(player, 381.333465, 218.192565, "INFORMACION", 0.315000, 1.226666, 1, -1, 0, 1, 1, 51, true, true);
            Data.Textdraws.info.Show();

            Data.Textdraws.salir = Elements.TextDraw.textDraw(player, 474.666870, 217.777740, "SALIR", 0.347666, 1.317926, 1, -1, 0, 1, 1, 51, true, true);
            Data.Textdraws.salir.Show();

            Data.Textdraws.version = Elements.TextDraw.textDraw(player, 291.333465, 182.103530, "version 0.0.1", 0.256666, 1.052445, 1, -1, 0, 1, 2, 51, true, false);
            Data.Textdraws.version.Show();

            Data.Textdraws.web = Elements.TextDraw.textDraw(player, 224.000015, 282.488769, "www.downtown-rp.es", 0.351333, 1.488000, 1, -1, 0, 3, 2, 51, true, false);
            Data.Textdraws.web.Show();
        }

        protected override void OnPlayerSpawned(BasePlayer player, SpawnEventArgs e)
        {
            base.OnPlayerSpawned(player, e);
        }

        protected async override void OnPlayerDisconnected(BasePlayer player, DisconnectEventArgs e)
        {
            base.OnPlayerDisconnected(player, e);
            if (Data.Lists.registerPlayers.Find(x => x.player == player) != null) Data.Lists.registerPlayers.Remove(Data.Lists.registerPlayers.Find(x => x.player == player));

            if(Data.Lists.Players.Find(x => x.client == player) != null)
            {
                await Game.Auth.DbFunctions.SaveAccount(player.Name, player.Position.X, player.Position.Y, player.Position.Z);
                await Game.Vehicles.Main.despawnVehicle(player);
            }
        }

    }
}
