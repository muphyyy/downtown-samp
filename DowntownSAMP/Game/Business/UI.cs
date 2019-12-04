using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace DowntownSAMP.Game.Business
{
    public class UI
    {
        public static void OpenBuyBusinessMenu(BasePlayer player, string tipo, int precio)
        {
            Data.Textdraws.boxBuy1 = new PlayerTextDraw(player);
            Data.Textdraws.boxBuy1.Position = new Vector2(308.000000, 166.000000);
            Data.Textdraws.boxBuy1.LetterSize = new Vector2(0.912499, 11.650012);
            Data.Textdraws.boxBuy1.Width = 298.500000f;
            Data.Textdraws.boxBuy1.Height = 234.000000f;
            Data.Textdraws.boxBuy1.Alignment = (TextDrawAlignment)2;
            Data.Textdraws.boxBuy1.BackColor = 1097458175;
            Data.Textdraws.boxBuy1.BoxColor = 1097458055;
            Data.Textdraws.boxBuy1.UseBox = true;
            Data.Textdraws.boxBuy1.Shadow = 0;
            Data.Textdraws.boxBuy1.Outline = 1;
            Data.Textdraws.boxBuy1.Font = (TextDrawFont)1;
            Data.Textdraws.boxBuy1.Proportional = true;
            Data.Textdraws.boxBuy1.Show();

            Data.Textdraws.venta = Elements.TextDraw.textDrawSize(player, 229.000000, 172.000000, "Este negocio esta en venta", 0.337500, 1.450000, 400.000000f, 17.000000f, 1, -1, 0, 1, 1, 51, true, false);
            Data.Textdraws.venta.Show();

            Data.Textdraws.comprar = new PlayerTextDraw(player, new Vector2(267.000000, 247.000000), "Comprar");
            Data.Textdraws.comprar.LetterSize = new Vector2(0.258332, 1.750000);
            Data.Textdraws.comprar.Width = 16.500000f; 
            Data.Textdraws.comprar.Height = 71.500000f;
            Data.Textdraws.comprar.Alignment = (TextDrawAlignment)2;
            Data.Textdraws.comprar.BackColor = 1296911871;
            Data.Textdraws.comprar.BoxColor = 200;
            Data.Textdraws.comprar.UseBox = true;
            Data.Textdraws.comprar.Shadow = 0;
            Data.Textdraws.comprar.Outline = 1;
            Data.Textdraws.comprar.Font = (TextDrawFont)2;
            Data.Textdraws.comprar.Proportional = true;
            Data.Textdraws.comprar.Selectable = true;
            Data.Textdraws.comprar.Click += Data.Response.Textdraws.buyBusinessResponse;
            Data.Textdraws.comprar.Show();

            Data.Textdraws.boxBuy2 = new PlayerTextDraw(player);
            Data.Textdraws.boxBuy2.Position = new Vector2(246.000000, 193.000000);
            Data.Textdraws.boxBuy2.LetterSize = new Vector2(0.637499, 4.649981);
            Data.Textdraws.boxBuy2.Width = 302.000000f;
            Data.Textdraws.boxBuy2.Height = 100.000000f;
            Data.Textdraws.boxBuy2.Alignment = (TextDrawAlignment)2;
            Data.Textdraws.boxBuy2.BackColor = 255;
            Data.Textdraws.boxBuy2.BoxColor = 135;
            Data.Textdraws.boxBuy2.UseBox = true;
            Data.Textdraws.boxBuy2.Shadow = 0;
            Data.Textdraws.boxBuy2.Outline = 1;
            Data.Textdraws.boxBuy2.Font = (TextDrawFont)1;
            Data.Textdraws.boxBuy2.Proportional = true;
            Data.Textdraws.boxBuy2.Show();

            Data.Textdraws.tipo = Elements.TextDraw.textDrawSize(player, 201.000000, 205.000000, tipo, 0.379166, 1.950000, 400.000000f, 17.000000f, 1, -1, 0, 1, 3, 51, true, false);
            Data.Textdraws.tipo.Show();

            Data.Textdraws.boxBuy3 = new PlayerTextDraw(player);
            Data.Textdraws.boxBuy3.Position = new Vector2(368.000000, 193.000000);
            Data.Textdraws.boxBuy3.LetterSize = new Vector2(0.637499, 4.649981);
            Data.Textdraws.boxBuy3.Width = 302.000000f;
            Data.Textdraws.boxBuy3.Height = 100.000000f;
            Data.Textdraws.boxBuy3.Alignment = (TextDrawAlignment)2;
            Data.Textdraws.boxBuy3.BackColor = 255;
            Data.Textdraws.boxBuy3.BoxColor = 135;
            Data.Textdraws.boxBuy3.UseBox = true;
            Data.Textdraws.boxBuy3.Shadow = 0;
            Data.Textdraws.boxBuy3.Outline = 1;
            Data.Textdraws.boxBuy3.Font = (TextDrawFont)1;
            Data.Textdraws.boxBuy3.Proportional = true;
            Data.Textdraws.boxBuy3.Show();

            Data.Textdraws.precio = Elements.TextDraw.textDrawSize(player, 325.000000, 204.000000, $"${precio}", 0.600000, 2.000000, 400.000000f, 17.000000f, 1, -1, 0, 1, 3, 51, true, false);
            Data.Textdraws.precio.Show();

            Data.Textdraws.salirBuy = new PlayerTextDraw(player, new Vector2(347.000000, 247.000000), "SALIR");
            Data.Textdraws.salirBuy.LetterSize = new Vector2(0.258332, 1.750000);
            Data.Textdraws.salirBuy.Width = 16.500000f;
            Data.Textdraws.salirBuy.Height = 71.500000f;
            Data.Textdraws.salirBuy.Alignment = (TextDrawAlignment)2;
            Data.Textdraws.salirBuy.BackColor = 1296911871;
            Data.Textdraws.salirBuy.BoxColor = 200;
            Data.Textdraws.salirBuy.UseBox = true;
            Data.Textdraws.salirBuy.Shadow = 0;
            Data.Textdraws.salirBuy.Outline = 1;
            Data.Textdraws.salirBuy.Font = (TextDrawFont)2;
            Data.Textdraws.salirBuy.Proportional = true;
            Data.Textdraws.salirBuy.Selectable = true;
            Data.Textdraws.salirBuy.Click += Data.Response.Textdraws.exitBuyBusinessResponse;
            Data.Textdraws.salirBuy.Show();
        }
    }
}
