using AutoMapper;
using Pegler.Players.DataAccess.Dtos;
using Pegler.Players.ViewModels.Players.GET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pegler.Players.AutoMapperMapping
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<PlayerDto, PlayerRespVM>()
                .ReverseMap();
        }
    }
}
