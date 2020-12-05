using System;
using System.Collections.Generic;
using System.Text;

namespace Pegler.Leaderboard.DataAccess.Dtos
{
    public class PlayerDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Winnings { get; set; }

        public int CountryId { get; set; }

        public CountryDto CountryDto { get; set; }
    }
}
