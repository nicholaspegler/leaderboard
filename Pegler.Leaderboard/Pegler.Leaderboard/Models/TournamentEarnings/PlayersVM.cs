using System.Collections.Generic;

namespace Pegler.Leaderboard.Models.TournamentEarnings
{
    public class PlayersVM
    {
        public PlayersVM()
        {
            Players = new List<PlayerVM>();
        }

        public List<PlayerVM> Players { get; set; }
    }
}
