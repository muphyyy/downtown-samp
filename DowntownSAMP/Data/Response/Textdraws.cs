using SampSharp.GameMode;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DowntownSAMP.Data.Response
{
    public class Textdraws : BaseMode
    {
        internal async static void loginClick(object sender, ClickPlayerTextDrawEventArgs e)
        {
            if (await Game.Auth.DbFunctions.CheckIfPlayerRegistered(e.Player.Name))
            {
                Data.Dialogs.loginDialog = new InputDialog("Iniciar sesion", "Por favor, inicia sesion", true, "Iniciar", "Salir");
                Data.Dialogs.loginDialog.Show(e.Player);
                Data.Dialogs.loginDialog.Response += Response.Dialogs.loginDialogResponse;
            }
            else
            {
                MessageDialog mensaje = new MessageDialog("Error", "Ya existe una cuenta registrada con este usuario", "OK");
                mensaje.Show(e.Player);
            }
        }

        internal async static void registerClick(object sender, ClickPlayerTextDrawEventArgs e)
        {
            if (await Game.Auth.DbFunctions.CheckIfPlayerRegistered(e.Player.Name))
            {
                MessageDialog mensaje = new MessageDialog("Error", "Ya existe una cuenta registrada con este usuario", "OK");
                mensaje.Show(e.Player);
            }
            else
            {
                Data.Dialogs.registerDialog = new InputDialog("Registrate", "Por favor, registra tu cuenta insertando tu password", true, "Registrate", "Salir");
                Data.Dialogs.registerDialog.Show(e.Player);
                Data.Dialogs.registerDialog.Response += Response.Dialogs.registerDialogResponse;
            }
        }

        internal static void hombreResponse(object sender, ClickPlayerTextDrawEventArgs e)
        {
            Data.Lists.registerPlayers.Find(x => x.player == e.Player).genero = 1;
            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 1;
            e.Player.Skin = 147;
            e.Player.SendClientMessage("Has escogido genero masculino.");
        }

        internal static void mujerResponse(object sender, ClickPlayerTextDrawEventArgs e)
        {
            Data.Lists.registerPlayers.Find(x => x.player == e.Player).genero = 2;
            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 1;
            e.Player.Skin = 56;
            e.Player.SendClientMessage("Has escogido genero femenino.");
        }

        internal async static void buyBusinessResponse(object sender, ClickPlayerTextDrawEventArgs e)
        {
            Data.Textdraws.boxBuy1.Hide();
            Data.Textdraws.venta.Hide();
            Data.Textdraws.comprar.Hide();
            Data.Textdraws.boxBuy2.Hide();
            Data.Textdraws.tipo.Hide();
            Data.Textdraws.boxBuy3.Hide();
            Data.Textdraws.precio.Hide();
            Data.Textdraws.salirBuy.Hide();

            e.Player.CancelSelectTextDraw();
            Data.Classes.Player player = Data.Lists.Players.Find(x => x.client == e.Player);
            player.isMenuOpen = false;

            if(player.business != null)
            {
                if(player.business.owner == 0)
                {
                    if (e.Player.Money > player.business.price)
                    {
                        player.business.owner = player.idDb;
                        await Game.Business.DbFunctions.UpdateBusinessOwner(player.business.idDb, player.idDb);
                        e.Player.SendClientMessage("Felicidades, ahora eres propietario de tu negocio.");
                        e.Player.SendClientMessage("Usa /negociogestion en tu negocio para configurarlo.");
                    }
                    else e.Player.SendClientMessage("No tienes dinero para comprar este negocio.");
                }
            }
        }

        internal static void anteriorResponse(object sender, ClickPlayerTextDrawEventArgs e)
        {
            int genero = Data.Lists.registerPlayers.Find(x => x.player == e.Player).genero;
            if (genero != 0)
            {
                int skinStatus = Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus;
                if(genero == 1)
                {
                    switch (skinStatus)
                    {
                        case 1:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 5;
                            e.Player.Skin = 60;
                            break;

                        case 2:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 1;
                            e.Player.Skin = 147;
                            break;

                        case 3:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 2;
                            e.Player.Skin = 126;
                            break;

                        case 4:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 3;
                            e.Player.Skin = 121;
                            break;

                        case 5:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 4;
                            e.Player.Skin = 98;
                            break;
                    }
                }
                else
                {
                    switch (skinStatus)
                    {
                        case 1:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 5;
                            e.Player.Skin = 141;
                            break;

                        case 2:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 1;
                            e.Player.Skin = 56;
                            break;

                        case 3:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 2;
                            e.Player.Skin = 55;
                            break;

                        case 4:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 3;
                            e.Player.Skin = 76;
                            break;

                        case 5:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 4;
                            e.Player.Skin = 93;
                            break;
                    }
                }
            }
            else e.Player.SendClientMessage("Debes escoger primero un genero.");
        }

        internal static void exitBuyBusinessResponse(object sender, ClickPlayerTextDrawEventArgs e)
        {
            Data.Textdraws.boxBuy1.Hide();
            Data.Textdraws.venta.Hide();
            Data.Textdraws.comprar.Hide();
            Data.Textdraws.boxBuy2.Hide();
            Data.Textdraws.tipo.Hide();
            Data.Textdraws.boxBuy3.Hide();
            Data.Textdraws.precio.Hide();
            Data.Textdraws.salirBuy.Hide();

            e.Player.CancelSelectTextDraw();
            Data.Lists.Players.Find(x => x.client == e.Player).isMenuOpen = false;
        }

        internal static void adelanteResponse(object sender, ClickPlayerTextDrawEventArgs e)
        {
            int genero = Data.Lists.registerPlayers.Find(x => x.player == e.Player).genero;
            if (genero != 0)
            {
                int skinStatus = Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus;
                if (genero == 1)
                {
                    switch (skinStatus)
                    {
                        case 1:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 2;
                            e.Player.Skin = 126;
                            break;

                        case 2:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 3;
                            e.Player.Skin = 121;
                            break;

                        case 3:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 4;
                            e.Player.Skin = 98;
                            break;

                        case 4:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 5;
                            e.Player.Skin = 60;
                            break;

                        case 5:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 1;
                            e.Player.Skin = 147;
                            break;
                    }
                }
                else
                {
                    switch (skinStatus)
                    {
                        case 1:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 2;
                            e.Player.Skin = 55;
                            break;

                        case 2:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 3;
                            e.Player.Skin = 76;
                            break;

                        case 3:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 4;
                            e.Player.Skin = 93;
                            break;

                        case 4:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 5;
                            e.Player.Skin = 101;
                            break;

                        case 5:
                            Data.Lists.registerPlayers.Find(x => x.player == e.Player).skinStatus = 1;
                            e.Player.Skin = 56;
                            break;
                    }
                }
            }
            else e.Player.SendClientMessage("Debes escoger primero un genero.");
        }

        internal async static void finalizarResponse(object sender, ClickPlayerTextDrawEventArgs e)
        {
            Classes.RegisterProcess userRegister = Data.Lists.registerPlayers.Find(x => x.player == e.Player);

            if (userRegister.genero != 0)
            {
                Data.Textdraws.boxReg1.Hide();
                Data.Textdraws.boxReg2.Hide();
                Data.Textdraws.boxReg3.Hide();
                Data.Textdraws.boxReg4.Hide();
                Data.Textdraws.boxReg5.Hide();
                Data.Textdraws.boxReg6.Hide();
                Data.Textdraws.boxReg7.Hide();
                Data.Textdraws.genero.Hide();
                Data.Textdraws.hombre.Hide();
                Data.Textdraws.mujer.Hide();
                Data.Textdraws.skin.Hide();
                Data.Textdraws.anterior.Hide();
                Data.Textdraws.adelante.Hide();
                Data.Textdraws.finalizar.Hide();


                await Game.Auth.DbFunctions.RegisterPlayer(e.Player.Name, userRegister.password, userRegister.email, userRegister.age, userRegister.genero, e.Player.Skin);
                e.Player.Position = new Vector3(1751.65, -1949.24, 13.54);
                e.Player.VirtualWorld = 0;
                e.Player.PutCameraBehindPlayer();
                e.Player.CancelSelectTextDraw();
                e.Player.SendClientMessage("Bienvenido a Downtown Roleplay. Para mas informacion visita www.downtown-rp.es");
            }
            else e.Player.SendClientMessage("Debes escoger primero un genero.");
        }
    }
}
