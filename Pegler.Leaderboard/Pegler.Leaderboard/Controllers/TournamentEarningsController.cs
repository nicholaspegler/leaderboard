using AutoMapper;
using ISO3166;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pegler.Leaderboard.BusinessLogic.Contracts;
using Pegler.Leaderboard.BusinessLogic.Models.PlayersService.GET;
using Pegler.Leaderboard.Models.TournamentEarnings;
using System.Collections.Generic;
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
            return View();
        }


        //[Route("_Details")]
        public async Task<IActionResult> Details()
        {
            // get all

            (List<PlayerRespM> PlayerRespMs, ModelStateDictionary modelStateDictionary) = await playersServiceManager.GetAllAsync(ModelState);

            if (modelStateDictionary.IsValid)
            {
                List<PlayerVM> playerVMs = mapper.Map<List<PlayerRespM>, List<PlayerVM>>(PlayerRespMs);

                PlayersVM playersVM = new PlayersVM()
                {
                    Players = playerVMs
                };

                return PartialView("_Details", playersVM);
            }

            return PartialView("_Details");
        }

        [Route("_Create")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {

                Country[] countries = Country.List;


                return PartialView("_Create");
            }
            catch
            {
                return View();
            }
        }

        // POST: TournamentEarningsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: TournamentEarningsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: TournamentEarningsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

}
