using System;

namespace Pegler.Leaderboard.Models.TournamentEarnings
{
    public class PlayerVM
    {
        public Guid Id { get; set; }

        public int Rank { get; set; }

        public string Name { get; set; }

        public double Winnings { get; set; }

        public string Country { get; set; }
    }
}
