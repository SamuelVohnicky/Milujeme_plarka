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
    public class DeleteModel : PageModel
    {
        public Champion Champion { get; set; }
        private IChampionService _championService;
        public DeleteModel(IChampionService championService)
        {
            _championService = championService;
        }
        
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Champion = await _championService.Delete(id);

            if (Champion == null)
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

            Champion = _championService.Delete(id).Result;

            if (Champion != null)
            {
                await _championService.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}