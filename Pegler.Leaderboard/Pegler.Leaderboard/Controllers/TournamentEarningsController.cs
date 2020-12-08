using AutoMapper;
using ISO3166;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pegler.Leaderboard.BusinessLogic.Contracts;
using Pegler.Leaderboard.BusinessLogic.Models.PlayersService.GET;
using Pegler.Leaderboard.BusinessLogic.Models.PlayersService.POST;
using Pegler.Leaderboard.BusinessLogic.Models.PlayersService.PUT;
using Pegler.Leaderboard.Models.TournamentEarnings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pegler.Leaderboard.Controllers
{
    public class TournamentEarningsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPlayersServiceManager playersServiceManager;

        public TournamentEarningsController(IMapper mapper,
                                            IPlayersServiceManager playersServiceManager)
        {
            this.mapper = mapper;
            this.playersServiceManager = playersServiceManager;
        }

        public async Task<IActionResult> Index()
        {
            (List<PlayerRespM> playerRespMs, ModelStateDictionary modelStateDictionary) = await playersServiceManager.GetAllAsync(ModelState);

            if (modelStateDictionary.IsValid)
            {
                List<PlayerVM> playerVMs = mapper.Map<List<PlayerRespM>, List<PlayerVM>>(playerRespMs);

                int ranking = 1;
                playerVMs.OrderByDescending(o => o.Winnings)
                         .Select(s => { s.Rank = ranking++; return s; })
                         .ToList();

                PlayersVM playersVM = new PlayersVM()
                {
                    Players = playerVMs
                };

                return View(playersVM);
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePlayerVM createPlayerVM)
        {
            if (ModelState.IsValid)
            {
                PlayerReqM playerReqM = mapper.Map<CreatePlayerVM, PlayerReqM>(createPlayerVM);

                (PlayerCreatedRespM playerCreatedRespM, ModelStateDictionary modelStateDictionary) = await playersServiceManager.CreateAsync(playerReqM, ModelState);

                if (modelStateDictionary.IsValid)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(ModelState);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditPlayerVM editPlayerVM)
        {
            if (ModelState.IsValid)
            {
                PlayerUpdReqM playerUpdReqM = mapper.Map<EditPlayerVM, PlayerUpdReqM>(editPlayerVM);

                (bool success, ModelStateDictionary modelStateDictionary) = await playersServiceManager.UpdateAsync(playerUpdReqM, ModelState);

                if (modelStateDictionary.IsValid)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index", ModelState);
        }
    }
}
