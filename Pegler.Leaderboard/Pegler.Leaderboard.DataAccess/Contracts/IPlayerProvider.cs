using Pegler.Leaderboard.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pegler.Leaderboard.DataAccess.Contracts
{
    public interface IPlayerProvider
    {
        Task<List<PlayerDto>> GetAllAsync();

        Task<PlayerDto> GetAsync(Guid id);

        Task<PlayerDto> CreateAsync(PlayerDto playerDto);

        Task<bool> UpdateAsync(PlayerDto playerDto);
    }
}
