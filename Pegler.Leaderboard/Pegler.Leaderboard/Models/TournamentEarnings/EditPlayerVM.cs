using System;
using System.ComponentModel.DataAnnotations;

namespace Pegler.Leaderboard.Models.TournamentEarnings
{
    public class EditPlayerVM
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public double? Winnings { get; set; }
    }
}
