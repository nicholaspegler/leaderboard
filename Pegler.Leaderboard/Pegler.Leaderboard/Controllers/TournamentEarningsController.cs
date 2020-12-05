using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pegler.Leaderboard.Controllers
{
    public class TournamentEarningsController : Controller
    {
        // GET: TournamentEarningsController
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: TournamentEarningsController/Details/5
        [Route("_Details")]
        [HttpGet]
        public async Task<IActionResult> Details()
        {
            // get all






            return PartialView("_Details");
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
