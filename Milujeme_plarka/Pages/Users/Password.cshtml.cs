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
    public class PasswordModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        public ApplicationUser ApplicationUser { get; set; }
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        public PasswordModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
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

            Input = new InputModel { Id = ApplicationUser.Id };
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var userFromDb = _context.Users.Where(u => u.Id == Input.Id).FirstOrDefault();
            userFromDb.PasswordHash = null;
            _context.SaveChanges();

            var user = _userManager.FindByIdAsync(Convert.ToString(Input.Id)).Result;
            if (user == null)
            {
                throw new ApplicationException($"Nepodařilo se získat data uživatele s ID '{_userManager.GetUserId(User)}'.");
            }

            var addPasswordResult = await _userManager.AddPasswordAsync(user, Input.Password);
            if (!addPasswordResult.Succeeded)
            {
                StatusMessage = "Nastavení hesla se nepodařilo. Splňuje heslo všechny požadované podmínky?";
                ApplicationUser = _userManager.FindByIdAsync(Convert.ToString(Input.Id)).Result;
                return Page();
            }

            StatusMessage = "Heslo bylo nastaveno.";

            return RedirectToPage("./Index");
        }
    }
}