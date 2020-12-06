using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Pegler.Leaderboard.BusinessLogic.Contracts;
using Pegler.Leaderboard.BusinessLogic.Models.PlayersService.GET;
using Pegler.Leaderboard.BusinessLogic.Models.PlayersService.POST;
using Pegler.Leaderboard.BusinessLogic.Models.PlayersService.PUT;
using Pegler.Leaderboard.BusinessLogic.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pegler.Leaderboard.BusinessLogic.Managers
{
    public class PlayersServiceManager : IPlayersServiceManager
    {
        private readonly IHttpClientManager httpClientManager;
        private readonly IOptions<EndpointOptions> endpointOptions;

        private static string _Failed_ToCreatePlayer = "Failed to create player.";
        private static string _Failed_ToDeletePlayer = "Failed to delete player.";
        private static string _Failed_ToGetPlayer = "Failed to retrieve player.";
        private static string _Failed_ToUpdatePlayer = "Failed to update player.";

        public PlayersServiceManager(IHttpClientManager httpClientManager,
                                     IOptions<EndpointOptions> endpointOptions)
        {
            this.httpClientManager = httpClientManager;
            this.endpointOptions = endpointOptions;
        }

        public async Task<(PlayerCreatedRespM, ModelStateDictionary)> CreateAsync(PlayerReqM playerReqM, ModelStateDictionary modelStateDictionary)
        {
            string playerReqMAsString = JsonConvert.SerializeObject(playerReqM);

            StringContent stringContent = new StringContent(playerReqMAsString, Encoding.UTF8, "application/json");

            (PlayerCreatedRespM playerCreatedRespM, string errorMessage) = await httpClientManager.PostAsync<PlayerCreatedRespM>(endpointOptions?.Value.Endpoint, stringContent);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                modelStateDictionary.AddModelError("Player", _Failed_ToCreatePlayer);
            }

            return (playerCreatedRespM, modelStateDictionary);
        }

        public async Task<(bool, ModelStateDictionary)> DeleteAsync(Guid playerId, ModelStateDictionary modelStateDictionary)
        {
            (string deleteResp, string errorMessage) = await httpClientManager.DeleteAsync<string>($"{endpointOptions?.Value.Endpoint}{playerId}");

            if (!string.IsNullOrEmpty(errorMessage))
            {
                modelStateDictionary.AddModelError("Player", _Failed_ToDeletePlayer);
            }

            return (string.IsNullOrEmpty(deleteResp), modelStateDictionary);
        }

        public async Task<(List<PlayerRespM>, ModelStateDictionary)> GetAllAsync(ModelStateDictionary modelStateDictionary)
        {
            (List<PlayerRespM> playerRespMs, string errorMessage) = await httpClientManager.GetAsync<List<PlayerRespM>>($"{endpointOptions?.Value.Endpoint}");

            if (!string.IsNullOrEmpty(errorMessage))
            {
                modelStateDictionary.AddModelError("Player", _Failed_ToGetPlayer);
            }

            return (playerRespMs, modelStateDictionary);
        }

        public async Task<(PlayerRespM, ModelStateDictionary)> GetAsync(Guid playerId, ModelStateDictionary modelStateDictionary)
        {
            (PlayerRespM playerRespM, string errorMessage) = await httpClientManager.GetAsync<PlayerRespM>($"{endpointOptions?.Value.Endpoint}{playerId}");

            if (!string.IsNullOrEmpty(errorMessage))
            {
                modelStateDictionary.AddModelError("Player", _Failed_ToGetPlayer);
            }

            return (playerRespM, modelStateDictionary);
        }

        public async Task<(bool, ModelStateDictionary)> UpdateAsync(PlayerUpdReqM playerUpdReqM, ModelStateDictionary modelStateDictionary)
        {
            string playerUpdReqMAsString = JsonConvert.SerializeObject(playerUpdReqM);

            StringContent stringContent = new StringContent(playerUpdReqMAsString, Encoding.UTF8, "application/json");

            (string updateResp, string errorMessage) = await httpClientManager.PutAsync<string>(endpointOptions?.Value.Endpoint, stringContent);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                modelStateDictionary.AddModelError("Player", _Failed_ToUpdatePlayer);
            }

            return (string.IsNullOrEmpty(updateResp), modelStateDictionary);
        }
    }
}
