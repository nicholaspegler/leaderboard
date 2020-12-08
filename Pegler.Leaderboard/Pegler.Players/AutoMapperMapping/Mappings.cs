using AutoMapper;
using Pegler.Players.DataAccess.Dtos;
using Pegler.Players.ViewModels.Players.GET;
using Pegler.Players.ViewModels.Players.POST;

namespace Pegler.Players.AutoMapperMapping
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<PlayerDto, PlayerRespVM>()
                .ReverseMap();

            CreateMap<PlayerDto, PlayerReqVM>()
                .ReverseMap()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.ToString()));

        }
    }
}
