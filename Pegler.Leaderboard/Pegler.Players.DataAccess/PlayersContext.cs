using Microsoft.EntityFrameworkCore;
using Pegler.Players.DataAccess.Dtos;
using System;

namespace Pegler.Players.DataAccess
{
    public class PlayersContext : DbContext
    {
        public PlayersContext(DbContextOptions<PlayersContext> options) : base(options)
        {
        }

        public DbSet<PlayerDto> PlayerDtos { get; set; }

    }
}
