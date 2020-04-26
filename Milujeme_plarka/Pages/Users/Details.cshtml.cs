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
    public class DetailsModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public UserViewModel UserVM { get; set; }
        [TempData]
        public string StatusMessage { get; set; }
        public DetailsModel(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> OnGetAsync(string id = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userManager.FindByIdAsync(id).Result;
            var roles = await _userManager.GetRolesAsync(user);
            var claims = await _userManager.GetClaimsAsync(user);
            var allRoles = _roleManager.Roles.ToList();

            if (user == null)
            {
                return NotFound();
            }

            UserVM = new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Roles = roles,
                AllRoles = allRoles
            };

            return Page();
        }
        public async Task<IActionResult> OnGetJoinAsync(string user, string role)
        {
            var u = _userManager.FindByIdAsync(user).Result;
            var r = _roleManager.FindByIdAsync(role).Result;
            if (u == null || r == null)
            {
                return NotFound();
            }

            await _userManager.AddToRoleAsync(u, r.Name);

            StatusMessage = "Uživateli byla přidělena role.";
            return RedirectToPage("Details", new { id = u.Id });
        }
        public async Task<IActionResult> OnGetRemoveAsync(string user, string role)
        {
            var u = _userManager.FindByIdAsync(user).Result;
            var r = _roleManager.FindByIdAsync(role).Result;
            if (u == null || r == null)
            {
                return NotFound();
            }

            await _userManager.RemoveFromRoleAsync(u, r.Name);

            StatusMessage = "Uživateli byla odebrána role.";
            return RedirectToPage("Details", new { id = u.Id });
        }
    }
}