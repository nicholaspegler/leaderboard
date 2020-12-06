using Microsoft.EntityFrameworkCore;
using Pegler.Players.DataAccess.Contracts;
using Pegler.Players.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pegler.Players.DataAccess.Providers
{
    public class PlayerProvider : IPlayerProvider
    {
        private readonly PlayersContext playersContext;

        public PlayerProvider(PlayersContext playersContext)
        {
            this.playersContext = playersContext;
        }

        public async Task<PlayerDto> CreateAsync(PlayerDto playerDto)
        {
            playersContext.Add(playerDto);
            await playersContext.SaveChangesAsync();

            return playerDto;
        }

        public async Task<bool> DeleteAsync(PlayerDto playerDto)
        {
            playersContext.Attach(playerDto);
            playersContext.PlayerDtos.Remove(playerDto);

            return await playersContext.SaveChangesAsync() > 0;
        }

        public async Task<List<PlayerDto>> GetAllAsync()
        {
            return await playersContext.PlayerDtos
                                       .ToListAsync();
        }

        public async Task<PlayerDto> GetAsync(Guid id)
        {
            return await playersContext.PlayerDtos
                                       .Where(w => w.Id == id)
                                       .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(PlayerDto playerDto)
        {
            playersContext.PlayerDtos.Attach(playerDto);
            playersContext.Entry(playerDto).State = EntityState.Modified;

            return await playersContext.SaveChangesAsync() > 0;
        }
    }
}
