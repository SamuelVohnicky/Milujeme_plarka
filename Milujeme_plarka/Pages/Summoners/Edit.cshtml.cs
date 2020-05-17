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
    public class EditModel : PageModel
    {
        [TempData]
        public string StatusMessage { get; set; }

        public EditModel(ISummonerService summonerService, ApplicationDbContext context)
        {
            _summonerService = summonerService;
            _context = context;
        }
        [BindProperty]
        public Summoner Summoner { get; set; }
        private ISummonerService _summonerService;
        private readonly ApplicationDbContext _context;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Summoner = _summonerService.Read(id).Result;

            if (Summoner == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var summoner = _context.Summoners.Where(r => r.SummonerId == Summoner.SummonerId).FirstOrDefault();
            summoner.SummonerName = Summoner.SummonerName;
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}