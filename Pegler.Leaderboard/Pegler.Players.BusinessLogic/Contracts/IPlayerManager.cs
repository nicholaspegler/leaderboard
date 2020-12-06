using Pegler.Players.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pegler.Players.BusinessLogic.Contracts
{
    public interface IPlayerManager
    {
        Task<PlayerDto> CreateAsync(PlayerDto playerDto);

        Task<bool> DeleteAsync(PlayerDto playerDto);

        Task<List<PlayerDto>> GetAllAsync();

        Task<PlayerDto> GetAsync(Guid id);

        Task<bool> UpdateAsync(PlayerDto playerDto);
    }
}
