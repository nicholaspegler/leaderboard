using AutoMapper;
using Pegler.Leaderboard.BusinessLogic.Models.PlayersService.GET;
using Pegler.Leaderboard.BusinessLogic.Models.PlayersService.POST;
using Pegler.Leaderboard.BusinessLogic.Models.PlayersService.PUT;
using Pegler.Leaderboard.Models.TournamentEarnings;

namespace Pegler.Leaderboard.AutoMapperMapping
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<PlayerVM, PlayerRespM>()
                .ReverseMap(); ;

            CreateMap<PlayerReqM, CreatePlayerVM>()
                .ReverseMap();

            CreateMap<PlayerUpdReqM, EditPlayerVM>()
                .ReverseMap()
                .ForMember(dest => dest.WinningsAdjustment, opt => opt.MapFrom(src => src.Winnings));

        }
    }
}
