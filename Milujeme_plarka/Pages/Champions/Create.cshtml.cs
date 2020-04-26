using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Milujeme_plarka.Models;
using Milujeme_plarka.Services.Champions;

namespace Milujeme_plarka.Pages.Champions
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Champion Champion { get; set; }

        private IChampionService _championService;
        [TempData]
        public string ErrorMessage { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string InfoMessage { get; set; }

        public CreateModel(IChampionService championService)
        {
            _championService = championService;
        }

        //public async Task<IActionResult> OnGetAsync()
        //{
        //    Champion = new Champion { Url = "https://" };
        //    return Page();
        //}

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
                    var bm = await _championService.Create(Champion);
                    SuccessMessage = "Champion been added.";
                    return RedirectToPage("./Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    ErrorMessage = "Storing of champion has failed.";
                    return Page();
                }                
            }
            ModelState.AddModelError("", "There are no user data available.");
            return Page();
        }

    }
}