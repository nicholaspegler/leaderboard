using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pegler.Players.DataAccess.Dtos
{
    [Table("DT_Player")]
    public class PlayerDto
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Winnings { get; set; }

        public int Country { get; set; }
    }
}
