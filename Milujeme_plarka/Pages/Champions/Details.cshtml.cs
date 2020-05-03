using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Milujeme_plarka.Models;
using Milujeme_plarka.Services.Champions;

namespace Milujeme_plarka.Pages.Champions
{
    public class DetailsModel : PageModel
    {
        [TempData]
        public string StatusMessage { get; set; }
        public DetailsModel(IChampionService championService)
        {
            _championService = championService;
        }
        public Champion Champion { get; set; }
        private IChampionService _championService;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Champion = await _championService.Read(id);

            if (Champion == null)
            {
                return NotFound();
            }

            return Page();
        }



        public async Task<IActionResult> OnGetUnclaimAsync(int id)
        {
            var r = _championService.Read(id).Result;
            if (r == null)
            {
                return NotFound();
            }
            return RedirectToPage("Details", new { id = r.ChampionId });
        }
    }
}