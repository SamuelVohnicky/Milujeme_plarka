using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Milujeme_plarka.Models;
using Milujeme_plarka.Services.Quests;

namespace Milujeme_plarka.Pages.Quests
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Quest Quest { get; set; }

        private IQuestService _questService;
        [TempData]
        public string ErrorMessage { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string InfoMessage { get; set; }

        public CreateModel(IQuestService itemService)
        {
            _questService = itemService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var currentUserId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            if (currentUserId != null)
            {
                try
                {
                    var bm = await _questService.Create(Quest);
                    SuccessMessage = "Champion been added.";
                    return RedirectToPage("./Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    ErrorMessage = "Storing of champion has failed.";
                    return Page();
                }
            }
            return Page();
        }

    }
}