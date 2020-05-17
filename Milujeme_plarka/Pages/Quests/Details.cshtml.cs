using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Milujeme_plarka.Models;
using Milujeme_plarka.Services.Quests;

namespace Milujeme_plarka.Pages.Quests
{
    public class DetailsModel : PageModel
    {
        [TempData]
        public string StatusMessage { get; set; }
        public DetailsModel(IQuestService questService)
        {
            _questService = questService;
        }
        public Quest Quest { get; set; }
        private IQuestService _questService;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quest = await _questService.Read(id);

            if (Quest == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnGetUnclaimAsync(int id)
        {
            var r = _questService.Read(id).Result;
            if (r == null)
            {
                return NotFound();
            }
            return RedirectToPage("Details", new { id = r.QuestId });
        }
    }
}