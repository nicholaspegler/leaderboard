using System;
using System.Collections.Generic;
using System.Text;

namespace Pegler.Leaderboard.BusinessLogic.Models.PlayersService.POST
{
    public class PlayerCreatedRespM
    {
        public Guid Id { get; set; }

        public string Href { get; set; }
    }
}
