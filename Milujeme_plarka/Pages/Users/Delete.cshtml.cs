using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Milujeme_plarka.Models;

namespace Milujeme_plarka.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        public ApplicationUser ApplicationUser { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public DeleteModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser = await _userManager.FindByIdAsync(id);

            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser = _userManager.FindByIdAsync(id).Result;

            if (ApplicationUser != null)
            {
                await _userManager.DeleteAsync(ApplicationUser);
            }

            return RedirectToPage("./Index");
        }
    }
}
