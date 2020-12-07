using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pegler.Players.BusinessLogic.Contracts;
using Pegler.Players.DataAccess.Dtos;
using Pegler.Players.ViewModels.Players.GET;
using Pegler.Players.ViewModels.Players.POST;
using Pegler.Players.ViewModels.Players.PUT;

namespace Pegler.Players.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPlayerManager playerManager;

        public PlayersController(IMapper mapper,
                                 IPlayerManager playerManager)
        {
            this.mapper = mapper;
            this.playerManager = playerManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PlayerRespVM>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            List<PlayerDto> playerDtos = await playerManager.GetAllAsync();


            List<PlayerRespVM> playerRespVMs = mapper.Map<List<PlayerDto>, List<PlayerRespVM>>(playerDtos);

            return Ok(playerRespVMs);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PlayerRespVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            PlayerRespVM playerRespVM = new PlayerRespVM();

            return Ok(playerRespVM);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PlayerCreatedRespVM), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(PlayerReqVM playerReqVM)
        {
            if (ModelState.IsValid)
            {

            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(PlayerUpdReqVM playerUpdReqVM)
        {
            if (ModelState.IsValid)
            {

            }

            return BadRequest(ModelState);
        }

        // DELETE api/<PlayersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {

            return NoContent();
        }
    }
}
