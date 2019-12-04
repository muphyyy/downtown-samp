using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace DowntownSAMP.Elements
{
    public class TextDraw : BaseMode
    {
        public static PlayerTextDraw textDraw(BasePlayer player, double posX, double posY, string text, double letterX, double letterY, int alignment, Color color, int shadow, int outline, int font, uint backcolor, bool proportional, bool clickeable)
        {
            PlayerTextDraw textdraw = new PlayerTextDraw(player, new Vector2(posX, posY), text);
            textdraw.LetterSize = new Vector2(letterX, letterY);
            textdraw.Alignment = (TextDrawAlignment)alignment;
            textdraw.ForeColor = color;
            textdraw.Shadow = shadow;
            textdraw.Outline = outline;
            textdraw.Font = (TextDrawFont)font;
            textdraw.BackColor = backcolor;
            textdraw.Proportional = proportional;
            textdraw.Selectable = clickeable;

            return textdraw;
        }

        public static PlayerTextDraw textDrawSize(BasePlayer player, double posX, double posY, string text, double letterX, double letterY, float width, float height, int alignment, Color color, int shadow, int outline, int font, uint backcolor, bool proportional, bool clickeable)
        {
            PlayerTextDraw textdraw = new PlayerTextDraw(player, new Vector2(posX, posY), text);
            textdraw.LetterSize = new Vector2(letterX, letterY);
            textdraw.Width = width;
            textdraw.Height = height;
            textdraw.Alignment = (TextDrawAlignment)alignment;
            textdraw.ForeColor = color;
            textdraw.Shadow = shadow;
            textdraw.Outline = outline;
            textdraw.Font = (TextDrawFont)font;
            textdraw.BackColor = backcolor;
            textdraw.Proportional = proportional;
            textdraw.Selectable = clickeable;

            return textdraw;
        }
    }
}
