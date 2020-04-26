using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Milujeme_plarka.Pages.Roles
{
    public class CreateModel : PageModel
    {
        private RoleManager<IdentityRole<Guid>> _roleManager;
        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Název")]
            public string Name { get; set; }
        }

        public CreateModel(RoleManager<IdentityRole<Guid>> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                IdentityRole<Guid> role = new IdentityRole<Guid>
                {
                    Name = Input.Name
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    StatusMessage = "Role byla vytvořena.";
                    return RedirectToPage("./Index");
                }
            }
            return Page();
        }
    }
}