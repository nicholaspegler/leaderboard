using AutoMapper;
using Pegler.Leaderboard.BusinessLogic.Models.PlayersService.GET;
using Pegler.Leaderboard.Models.TournamentEarnings;

namespace Pegler.Leaderboard.AutoMapperMapping
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<PlayerVM, PlayerRespM>()
                .ReverseMap(); ;

        }
    }
}
