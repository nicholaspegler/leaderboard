using System;

namespace Pegler.Players.ViewModels.Players.GET
{
    public class PlayerRespVM
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Winnings { get; set; }

        public string Country { get; set; }
    }
}
