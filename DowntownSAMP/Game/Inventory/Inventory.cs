using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace DowntownSAMP.Game.Inventory
{
    public class Inventory
    {
        public static void OpenInventory(BasePlayer player)
        {
            Data.Textdraws.boxInv1 = new PlayerTextDraw(player);
            Data.Textdraws.boxInv1.Position = new Vector2(320.000000, 165.000000);
            Data.Textdraws.boxInv1.LetterSize = new Vector2(0.679166, 13.800016);
            Data.Textdraws.boxInv1.Width = 294.500000f;
            Data.Textdraws.boxInv1.Height = 141.500000f;
            Data.Textdraws.boxInv1.Alignment = (TextDrawAlignment)2;
            Data.Textdraws.boxInv1.BoxColor = 1296911871;
            Data.Textdraws.boxInv1.BackColor = 1296911871;
            Data.Textdraws.boxInv1.UseBox = true;
            Data.Textdraws.boxInv1.Shadow = 0;
            Data.Textdraws.boxInv1.Outline = 0;
            Data.Textdraws.boxInv1.Font = (TextDrawFont)1;
            Data.Textdraws.boxInv1.Proportional = true;
            Data.Textdraws.boxInv1.Show();

            Data.Textdraws.boxInv2 = new PlayerTextDraw(player);
            Data.Textdraws.boxInv2.Position = new Vector2(320.000000, 165.000000);
            Data.Textdraws.boxInv2.LetterSize = new Vector2(0.600000, 1.699980);
            Data.Textdraws.boxInv2.Width = 298.500000f;
            Data.Textdraws.boxInv2.Height = 141.500000f;
            Data.Textdraws.boxInv2.Alignment = (TextDrawAlignment)2;
            Data.Textdraws.boxInv2.BoxColor = 1097458175;
            Data.Textdraws.boxInv2.BackColor = 255;
            Data.Textdraws.boxInv2.UseBox = true;
            Data.Textdraws.boxInv2.Shadow = 0;
            Data.Textdraws.boxInv2.Outline = 0;
            Data.Textdraws.boxInv2.Font = (TextDrawFont)1;
            Data.Textdraws.boxInv2.Proportional = true;
            Data.Textdraws.boxInv2.Show();

            Data.Textdraws.inventario = Elements.TextDraw.textDrawSize(player, 285.000000, 165.000000, "Inventario", 0.387499, 1.649999, 400.000000f, 17.000000f, 1, -1, 0, 1, 1, 51, true, false);
            Data.Textdraws.inventario.Show();

            Data.Textdraws.item = Elements.TextDraw.textDrawSize(player, 320.000000, 185.000000, "", 0.212500, 1.049998, 400.000000f, 17.000000f, 2, -1, 0, 1, 2, 51, true, false);
            Data.Textdraws.item.Show();

            Data.Textdraws.pesoItem = Elements.TextDraw.textDrawSize(player, 320.000000, 195.000000, "", 0.212500, 1.049998, 400.000000f, 17.000000f, 2, -1, 0, 1, 2, 51, true, false);
            Data.Textdraws.pesoItem.Show();

            Data.Textdraws.invItem1 = new PlayerTextDraw(player);
            Data.Textdraws.invItem1.Position = new Vector2(120.000000, 202.000000);
            Data.Textdraws.invItem1.LetterSize = new Vector2(0.600000, 2.000000);
            Data.Textdraws.invItem1.Width = 112.500000f;
            Data.Textdraws.invItem1.Height = 150.000000f;
            Data.Textdraws.invItem1.Alignment = (TextDrawAlignment)1;
            Data.Textdraws.invItem1.BoxColor = 1097458175;
            Data.Textdraws.invItem1.BackColor = 255;
            Data.Textdraws.invItem1.Shadow = 0;
            Data.Textdraws.invItem1.Outline = 0;
            Data.Textdraws.invItem1.Font = (TextDrawFont)5;
            Data.Textdraws.invItem1.Proportional = true;
            Data.Textdraws.invItem1.PreviewModel = 19559;
            Data.Textdraws.invItem1.PreviewRotation = new Vector3(-10.000000, 0.000000, -20.000000);
            Data.Textdraws.invItem1.PreviewZoom = 1.000000f;
            Data.Textdraws.invItem1.Show();
        }
    }
}
