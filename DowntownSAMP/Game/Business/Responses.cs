using System;
using System.Collections.Generic;
using System.Text;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.SAMP;

namespace DowntownSAMP.Game.Business
{
    class Responses
    {
        internal static void pickUpBusinessResponse(object sender, PlayerEventArgs e)
        {
            Data.Classes.Business business = Data.Lists.Business.Find(x => x.pickup == sender);
            Data.Classes.Player player = Data.Lists.Players.Find(x => x.client == e.Player);
            if(business != null)
            {
                if(business.owner == 0)
                {
                    if (!player.isMenuOpen)
                    {
                        e.Player.SelectTextDraw(new Color(255, 255, 255));
                        string name = DbFunctions.getNameOfTypeOfBusiness(business.type);
                        UI.OpenBuyBusinessMenu(e.Player, name, business.price);
                        player.business = business;
                        player.isMenuOpen = true;
                    }
                }
            }
        }
    }
}
