using System;
using System.Collections.Generic;
using System.Text;

namespace Pegler.Leaderboard.BusinessLogic.Models.PlayersService.PUT
{
    public class PlayerUpdReqM
    {
        public Guid Id { get; set; }

        public double WinningsAdjustment { get; set; }
    }
}
