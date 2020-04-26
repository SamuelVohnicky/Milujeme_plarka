using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Milujeme_plarka.Pages.Roles
{
    public class DeleteModel : PageModel
    {
        private RoleManager<IdentityRole<Guid>> _roleManager;
        public IdentityRole<Guid> IdentityRole { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public DeleteModel(RoleManager<IdentityRole<Guid>> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IdentityRole = await _roleManager.FindByIdAsync(id);

            if (IdentityRole == null)
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

            IdentityRole = await _roleManager.FindByIdAsync(id);

            if (IdentityRole != null)
            {
                await _roleManager.DeleteAsync(IdentityRole);
            }

            return RedirectToPage("./Index");
        }
    }
}