using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Milujeme_plarka.Models;
using Milujeme_plarka.Services.Summoners;

namespace Milujeme_plarka.Pages.Summoners
{
    public class DetailsModel : PageModel
    {
        [TempData]
        public string StatusMessage { get; set; }
        public DetailsModel(ISummonerService itemService)
        {
            _summonerService = itemService;
        }
        public Summoner Summoner { get; set; }
        private ISummonerService _summonerService;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Summoner = await _summonerService.Read(id);

            if (Summoner == null)
            {
                return NotFound();
            }

            return Page();
        }



        public async Task<IActionResult> OnGetUnclaimAsync(int id)
        {
            var r = _summonerService.Read(id).Result;
            if (r == null)
            {
                return NotFound();
            }
            return RedirectToPage("Details", new { id = r.SummonerId });
        }
    }
}