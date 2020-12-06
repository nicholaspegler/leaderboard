using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pegler.Leaderboard.BusinessLogic.Models.PlayersService.GET;
using Pegler.Leaderboard.BusinessLogic.Models.PlayersService.POST;
using Pegler.Leaderboard.BusinessLogic.Models.PlayersService.PUT;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pegler.Leaderboard.BusinessLogic.Contracts
{
    public interface IPlayersServiceManager
    {
        Task<(PlayerCreatedRespM, ModelStateDictionary)> CreateAsync(PlayerReqM playerReqM, ModelStateDictionary modelStateDictionary);

        Task<(bool, ModelStateDictionary)> DeleteAsync(Guid playerId, ModelStateDictionary modelStateDictionary);

        Task<(List<PlayerRespM>, ModelStateDictionary)> GetAllAsync(ModelStateDictionary modelStateDictionary);

        Task<(PlayerRespM, ModelStateDictionary)> GetAsync(Guid playerId, ModelStateDictionary modelStateDictionary);

        Task<(bool, ModelStateDictionary)> UpdateAsync(PlayerUpdReqM playerUpdReqM, ModelStateDictionary modelStateDictionary);
    }
}
