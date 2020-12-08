using System.ComponentModel.DataAnnotations;

namespace Pegler.Leaderboard.Models.TournamentEarnings
{
    public class CreatePlayerVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double? Winnings { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
