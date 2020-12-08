using Pegler.Players.BusinessLogic.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pegler.Players.ViewModels.Players.POST
{
    public class PlayerReqVM
    {
        [Required, MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public double? Winnings { get; set; }

        [Required]
        public Country Country { get; set; }
    }
}
