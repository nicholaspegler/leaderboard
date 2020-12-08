using System;
using System.ComponentModel.DataAnnotations;

namespace Pegler.Players.ViewModels.Players.PUT
{
    public class PlayerUpdReqVM
    {
        [Required]
        public Guid? Id { get; set; }

        [Required]
        public double? WinningsAdjustment { get; set; }
    }
}
