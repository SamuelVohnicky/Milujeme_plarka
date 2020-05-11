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
using Milujeme_plarka.Services;
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

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = "wwwroot/imgs/" + fileName;
                var fileImage = "/imgs/" + fileName;
                // If file with same name exists delete it
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                // Create new local file and copy contents of uploaded file
                using (var localFile = System.IO.File.OpenWrite(filePath))
                using (var uploadedFile = file.OpenReadStream())
                {
                    uploadedFile.CopyTo(localFile);
                }
                var bm = await _championService.Create(Champion, fileImage);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ErrorMessage = "Armor se nepodařilo přidat";
            }
            return Page();
        }

    }
}