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
    public class DeleteModel : PageModel
    {
        public Quest Quest{ get; set; }
        private IQuestService _questService;
        public DeleteModel(IQuestService questService)
        {
            _questService = questService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quest = await _questService.Delete(id);

            if (Quest == null)
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

            Quest = _questService.Delete(id).Result;

            if (Quest != null)
            {
                await _questService.Delete(id);
            }
            //System.IO.File.Delete("wwwroot/imgs/" + Champion.Image);
            return RedirectToPage("./Index");
        }
    }
}