using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Milujeme_plarka.Models;
using Milujeme_plarka.ViewModels;

namespace Milujeme_plarka.Pages.Users
{
    public class EditModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        [BindProperty]
        public UserViewModel Input { get; set; }
        private readonly ApplicationDbContext _context;
        [TempData]
        public string StatusMessage { get; set; }
        public EditModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser user = _userManager.FindByIdAsync(id).Result;
            Input = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName
            };

            if (user == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByIdAsync(Convert.ToString(Input.Id));
            user.Id = Input.Id;
            user.Email = Input.Email;
            user.UserName = Input.UserName;
            await _userManager.UpdateAsync(user);

            return RedirectToPage("./Index");
        }
    }
}