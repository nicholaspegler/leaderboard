using Pegler.Players.BusinessLogic.Contracts;
using Pegler.Players.DataAccess.Contracts;
using Pegler.Players.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pegler.Players.BusinessLogic.Managers
{
    public class PlayerManager : IPlayerManager
    {
        private readonly IPlayerProvider playerProvider;

        public PlayerManager(IPlayerProvider playerProvider)
        {
            this.playerProvider = playerProvider;
        }

        public async Task<PlayerDto> CreateAsync(PlayerDto playerDto)
        {
            return await playerProvider.CreateAsync(playerDto);
        }

        public async Task<bool> DeleteAsync(PlayerDto playerDto)
        {
            return await playerProvider.DeleteAsync(playerDto);
        }

        public async Task<List<PlayerDto>> GetAllAsync()
        {
            return await playerProvider.GetAllAsync();
        }

        public async Task<PlayerDto> GetAsync(Guid id)
        {
            return await playerProvider.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(PlayerDto playerDto)
        {
            return await playerProvider.UpdateAsync(playerDto);
        }
    }
}
