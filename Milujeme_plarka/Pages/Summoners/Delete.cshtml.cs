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
    public class DeleteModel : PageModel
    {
        public Summoner Summoner { get; set; }
        private ISummonerService _summonerService;
        public DeleteModel(ISummonerService summonerService)
        {
            _summonerService = summonerService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Summoner = await _summonerService.Delete(id);

            if (Summoner == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Summoner = _summonerService.Delete(id).Result;

            if (Summoner != null)
            {
                await _summonerService.Delete(id);
            }
            //System.IO.File.Delete("wwwroot/imgs/" + Champion.Image);
            return RedirectToPage("./Index");
        }
    }
}