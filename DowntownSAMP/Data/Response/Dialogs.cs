using System;
using System.Collections.Generic;
using System.Text;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;

namespace DowntownSAMP.Data.Response
{
    public class Dialogs : BaseMode
    {
        internal async static void loginDialogResponse(object sender, DialogResponseEventArgs e)
        {
            if(e.DialogButton == DialogButton.Left)
            {
                if (await Game.Auth.DbFunctions.LoginPlayer(e.Player, e.Player.Name, e.InputText) == true) await Game.Auth.Main.spawnUser(e.Player);
                else
                {
                    e.Player.SendClientMessage("Datos incorrectos, intentalo de nuevo");
                    Data.Dialogs.loginDialog = new InputDialog("Iniciar sesion", "Por favor, inicia sesion", true, "Iniciar", "Salir");
                    Data.Dialogs.loginDialog.Show(e.Player);
                    Data.Dialogs.loginDialog.Response += Response.Dialogs.loginDialogResponse;
                }
            }
        }

        internal static void registerDialogResponse(object sender, DialogResponseEventArgs e)
        {
            if (e.DialogButton == DialogButton.Left)
            {
                Data.Classes.RegisterProcess newRegister = new Data.Classes.RegisterProcess(e.Player, e.InputText);
                Data.Lists.registerPlayers.Add(newRegister);

                Data.Dialogs.emailRegister = new InputDialog("Correo electronico", "Ingresa tu correo electronico", false, "Siguiente");
                Data.Dialogs.emailRegister.Show(e.Player);
                Data.Dialogs.emailRegister.Response += Response.Dialogs.emailDialogResponse;
            }
        }

        private static void emailDialogResponse(object sender, DialogResponseEventArgs e)
        {
            if (e.DialogButton == DialogButton.Left)
            {
                Data.Lists.registerPlayers.Find(x => x.player == e.Player).email = e.InputText;
                Data.Dialogs.ageRegister = new InputDialog("Edad", "Ingresa la edad de tu personaje", false, "Siguiente");
                Data.Dialogs.ageRegister.Show(e.Player);
                Data.Dialogs.ageRegister.Response += Response.Dialogs.ageDialogResponse;
            }
        }

        private static void ageDialogResponse(object sender, DialogResponseEventArgs e)
        {
            int check = 0;
            if (e.DialogButton == DialogButton.Left)
            {
                if (int.TryParse(e.InputText, out check))
                {
                    if(Convert.ToInt32(e.InputText) < 100)
                    {
                        Data.Lists.registerPlayers.Find(x => x.player == e.Player).age = Convert.ToInt32(e.InputText);

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

                        e.Player.Skin = 100;
                        e.Player.PutCameraBehindPlayer();
                        e.Player.ToggleSpectating(false);
                        e.Player.Spawn();
                        e.Player.VirtualWorld = 10 + e.Player.Id;
                        e.Player.Position = new Vector3(1481.28076, -1750.32520, 15.45280);
                        e.Player.Angle = -180.00000f;
                        e.Player.Rotation = new Vector3(0, 0, -180.00000);
                        e.Player.SetCameraLookAt(new Vector3(1481.7075, -1747.5944, 16.1200));
                        e.Player.CameraPosition = new Vector3(1481.8268, -1746.6029, 16.3400);

                        Data.Textdraws.boxReg1 = new PlayerTextDraw(e.Player);
                        Data.Textdraws.boxReg1.Position = new Vector2(625.000305, 126.774070);
                        Data.Textdraws.boxReg1.LetterSize = new Vector2(0.000000, 5.544240);
                        Data.Textdraws.boxReg1.Width = 482.666656f;
                        Data.Textdraws.boxReg1.Height = 0.000000f;
                        Data.Textdraws.boxReg1.Alignment = (TextDrawAlignment)1;
                        Data.Textdraws.boxReg1.BoxColor = 102;
                        Data.Textdraws.boxReg1.UseBox = true;
                        Data.Textdraws.boxReg1.Shadow = 0;
                        Data.Textdraws.boxReg1.Outline = 0;
                        Data.Textdraws.boxReg1.Font = (TextDrawFont)0;
                        Data.Textdraws.boxReg1.Show();

                        Data.Textdraws.genero = Elements.TextDraw.textDraw(e.Player, 489.333343, 131.911193, "Selecciona el genero de tu personaje", 0.199333, 1.048295, 1, -1, 0, 1, 1, 51, true, false);
                        Data.Textdraws.genero.Show();

                        Data.Textdraws.boxReg2 = new PlayerTextDraw(e.Player);
                        Data.Textdraws.boxReg2.Position = new Vector2(541.000000, 148.759277);
                        Data.Textdraws.boxReg2.LetterSize = new Vector2(0.000000, 1.851646);
                        Data.Textdraws.boxReg2.Width = 488.666687f;
                        Data.Textdraws.boxReg2.Height = 0.000000f;
                        Data.Textdraws.boxReg2.Alignment = (TextDrawAlignment)1;
                        Data.Textdraws.boxReg2.BackColor = 696826881;
                        Data.Textdraws.boxReg2.BoxColor = 696827135;
                        Data.Textdraws.boxReg2.UseBox = true;
                        Data.Textdraws.boxReg2.Shadow = 0;
                        Data.Textdraws.boxReg2.Outline = 0;
                        Data.Textdraws.boxReg2.Font = (TextDrawFont)0;
                        Data.Textdraws.boxReg2.Show();

                        Data.Textdraws.hombre = DowntownSAMP.Elements.TextDraw.textDraw(e.Player, 495.000030, 151.822250, "HOMBRE", 0.311666, 1.081481, 1, -1, 0, 1, 3, 51, true, true);
                        Data.Textdraws.hombre.Click += Data.Response.Textdraws.hombreResponse;
                        Data.Textdraws.hombre.Show();

                        Data.Textdraws.boxReg3 = new PlayerTextDraw(e.Player);
                        Data.Textdraws.boxReg3.Position = new Vector2(617.999938, 149.174057);
                        Data.Textdraws.boxReg3.LetterSize = new Vector2(0.000000, 1.833333);
                        Data.Textdraws.boxReg3.Width = 565.666625f;
                        Data.Textdraws.boxReg3.Height = 0.000000f;
                        Data.Textdraws.boxReg3.Alignment = (TextDrawAlignment)1;
                        Data.Textdraws.boxReg3.BackColor = 696826881;
                        Data.Textdraws.boxReg3.BoxColor = 696827135;
                        Data.Textdraws.boxReg3.UseBox = true;
                        Data.Textdraws.boxReg3.Shadow = 0;
                        Data.Textdraws.boxReg3.Outline = 0;
                        Data.Textdraws.boxReg3.Font = (TextDrawFont)0;
                        Data.Textdraws.boxReg3.Show();

                        Data.Textdraws.mujer = Elements.TextDraw.textDraw(e.Player, 573.666564, 151.822235, "MUJER", 0.326666, 1.185185, 1, -1, 0, 1, 3, 51, true, true);
                        Data.Textdraws.mujer.Click += Data.Response.Textdraws.mujerResponse;
                        Data.Textdraws.mujer.Show();

                        Data.Textdraws.boxReg4 = new PlayerTextDraw(e.Player);
                        Data.Textdraws.boxReg4.Position = new Vector2(628.666381, 254.122146);
                        Data.Textdraws.boxReg4.LetterSize = new Vector2(0.000000, 5.444650);
                        Data.Textdraws.boxReg4.Width = 485.333465f;
                        Data.Textdraws.boxReg4.Height = 0.000000f;
                        Data.Textdraws.boxReg4.Alignment = (TextDrawAlignment)1;
                        Data.Textdraws.boxReg4.BoxColor = 102;
                        Data.Textdraws.boxReg4.UseBox = true;
                        Data.Textdraws.boxReg4.Shadow = 0;
                        Data.Textdraws.boxReg4.Outline = 0;
                        Data.Textdraws.boxReg4.Font = (TextDrawFont)0;
                        Data.Textdraws.boxReg4.Show();

                        Data.Textdraws.skin = Elements.TextDraw.textDraw(e.Player, 511.333526, 257.185272, "Selecciona un skin", 0.285333, 1.077333, 1, -1, 0, 1, 1, 51, true, false);
                        Data.Textdraws.skin.Show();

                        Data.Textdraws.boxReg5 = new PlayerTextDraw(e.Player);
                        Data.Textdraws.boxReg5.Position = new Vector2(545.333435, 277.766693);
                        Data.Textdraws.boxReg5.LetterSize = new Vector2(0.000000, 1.895679);
                        Data.Textdraws.boxReg5.Width = 491.999969f;
                        Data.Textdraws.boxReg5.Height = 0.000000f;
                        Data.Textdraws.boxReg5.Alignment = (TextDrawAlignment)1;
                        Data.Textdraws.boxReg5.BackColor = 696826881;
                        Data.Textdraws.boxReg5.BoxColor = 696827135;
                        Data.Textdraws.boxReg5.UseBox = true;
                        Data.Textdraws.boxReg5.Shadow = 0;
                        Data.Textdraws.boxReg5.Outline = 0;
                        Data.Textdraws.boxReg5.Font = (TextDrawFont)0;
                        Data.Textdraws.boxReg5.Show();

                        Data.Textdraws.anterior = Elements.TextDraw.textDraw(e.Player, 499.000091, 280.829589, "ANTERIOR", 0.251666, 1.185185, 1, -1, 0, 1, 3, 51, true, true);
                        Data.Textdraws.anterior.Click += Data.Response.Textdraws.anteriorResponse;
                        Data.Textdraws.anterior.Show();

                        Data.Textdraws.boxReg6 = new PlayerTextDraw(e.Player);
                        Data.Textdraws.boxReg6.Position = new Vector2(621.665954, 277.766662);
                        Data.Textdraws.boxReg6.LetterSize = new Vector2(0.000000, 1.895681);
                        Data.Textdraws.boxReg6.Width = 567.999511f;
                        Data.Textdraws.boxReg6.Height = 0.000000f;
                        Data.Textdraws.boxReg6.Alignment = (TextDrawAlignment)1;
                        Data.Textdraws.boxReg6.BackColor = 696826881;
                        Data.Textdraws.boxReg6.BoxColor = 696827135;
                        Data.Textdraws.boxReg6.UseBox = true;
                        Data.Textdraws.boxReg6.Shadow = 0;
                        Data.Textdraws.boxReg6.Outline = 0;
                        Data.Textdraws.boxReg6.Font = (TextDrawFont)0;
                        Data.Textdraws.boxReg6.Show();

                        Data.Textdraws.adelante = Elements.TextDraw.textDraw(e.Player, 571.666748, 280.829589, "SIGUIENTE", 0.283333, 1.143703, 1, -1, 0, 1, 3, 51, true, true);
                        Data.Textdraws.adelante.Click += Data.Response.Textdraws.adelanteResponse;
                        Data.Textdraws.adelante.Show();

                        Data.Textdraws.boxReg7 = new PlayerTextDraw(e.Player);
                        Data.Textdraws.boxReg7.Position = new Vector2(151.666687, 205.588943);
                        Data.Textdraws.boxReg7.LetterSize = new Vector2(0.000000, 2.678395);
                        Data.Textdraws.boxReg7.Width = 10.333308f;
                        Data.Textdraws.boxReg7.Height = 0.000000f;
                        Data.Textdraws.boxReg7.Alignment = (TextDrawAlignment)1;
                        Data.Textdraws.boxReg7.BackColor = 696826881;
                        Data.Textdraws.boxReg7.BoxColor = 696827135;
                        Data.Textdraws.boxReg7.UseBox = true;
                        Data.Textdraws.boxReg7.Shadow = 0;
                        Data.Textdraws.boxReg7.Outline = 0;
                        Data.Textdraws.boxReg7.Font = (TextDrawFont)0;
                        Data.Textdraws.boxReg7.Show();

                        Data.Textdraws.finalizar = Elements.TextDraw.textDraw(e.Player, 17.999982, 210.725875, "FINALIZAR REGISTRO", 0.290000, 1.471407, 1, -1, 0, 1, 2, 51, true, true);
                        Data.Textdraws.finalizar.Click += Data.Response.Textdraws.finalizarResponse;
                        Data.Textdraws.finalizar.Show();
                    }
                    else
                    {
                        e.Player.SendClientMessage("Debes insertar una edad real");
                        Data.Dialogs.ageRegister = new InputDialog("Edad", "Ingresa la edad de tu personaje", false, "Siguiente");
                        Data.Dialogs.ageRegister.Show(e.Player);
                        Data.Dialogs.ageRegister.Response += Response.Dialogs.ageDialogResponse;
                    }
                }
                else
                {
                    e.Player.SendClientMessage("Debes insertar una edad real");
                    Data.Dialogs.ageRegister = new InputDialog("Edad", "Ingresa la edad de tu personaje", false, "Siguiente");
                    Data.Dialogs.ageRegister.Show(e.Player);
                    Data.Dialogs.ageRegister.Response += Response.Dialogs.ageDialogResponse;
                }
            }

        }
    }
}
