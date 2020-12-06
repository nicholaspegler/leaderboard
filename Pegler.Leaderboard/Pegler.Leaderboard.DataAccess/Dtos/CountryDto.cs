using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pegler.Leaderboard.DataAccess.Dtos
{
    [Table("LK_Country")]
    public class CountryDto
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string IsoCode { get; set; }
    }
}
