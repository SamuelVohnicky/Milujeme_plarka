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
    public class EditModel : PageModel
    {
        [TempData]
        public string StatusMessage { get; set; }

        public EditModel(IChampionService championService, ApplicationDbContext context)
        {
            _championService = championService;
            _context = context;
        }
        [BindProperty]
        public Champion Champion { get; set; }
        private IChampionService _championService;
        private readonly ApplicationDbContext _context;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Champion = _championService.Read(id).Result;

            if (Champion == null)
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

            var champion = _context.Champions.Where(r => r.ChampionId == Champion.ChampionId).FirstOrDefault();
            champion.ChampionName = Champion.ChampionName;
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}