using System;
using System.Collections.Generic;
using System.Text;

namespace Pegler.Leaderboard.BusinessLogic.Models.PlayersService.GET
{
    public class PlayerRespM
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Winnings { get; set; }

        public string Country { get; set; }
    }
}
