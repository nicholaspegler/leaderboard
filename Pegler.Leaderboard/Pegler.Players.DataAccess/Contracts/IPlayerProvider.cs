using Pegler.Players.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pegler.Players.DataAccess.Contracts
{
    public interface IPlayerProvider
    {
        Task<PlayerDto> CreateAsync(PlayerDto playerDto);

        Task<bool> DeleteAsync(PlayerDto playerDto);

        Task<List<PlayerDto>> GetAllAsync();

        Task<PlayerDto> GetAsync(Guid id);

        Task<bool> UpdateAsync(PlayerDto playerDto);
    }
}
