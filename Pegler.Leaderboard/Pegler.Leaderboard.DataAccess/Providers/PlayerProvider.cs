using Microsoft.EntityFrameworkCore;
using Pegler.Leaderboard.DataAccess.Contracts;
using Pegler.Leaderboard.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pegler.Leaderboard.DataAccess.Providers
{
    public class PlayerProvider : IPlayerProvider
    {
        private readonly LeaderboardContext leaderboardContext;

        public PlayerProvider(LeaderboardContext leaderboardContext)
        {
            this.leaderboardContext = leaderboardContext;
        }

        public async Task<PlayerDto> CreateAsync(PlayerDto playerDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PlayerDto>> GetAllAsync()
        {
            return await leaderboardContext.PlayerDtos
                                           .Include(i => i.CountryDto)
                                           .ToListAsync();
        }

        public async Task<PlayerDto> GetAsync(Guid id)
        {
            return await leaderboardContext.PlayerDtos
                                           .Include(i => i.CountryDto)
                                           .Where(w => w.Id == id)
                                           .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(PlayerDto playerDto)
        {
            leaderboardContext.PlayerDtos.Attach(playerDto);
            leaderboardContext.Entry(playerDto).State = EntityState.Modified;

            return await leaderboardContext.SaveChangesAsync() > 0;
        }
    }
}
