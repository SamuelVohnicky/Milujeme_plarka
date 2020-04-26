using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Milujeme_plarka.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private RoleManager<IdentityRole<Guid>> _roleManager;
        public List<IdentityRole<Guid>> Roles { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public IndexModel(RoleManager<IdentityRole<Guid>> roleManager)
        {
            _roleManager = roleManager;
        }

        public void OnGet()
        {
            Roles = new List<IdentityRole<Guid>>();
            Roles = _roleManager.Roles.OrderBy(r => r.Name).ToList();
        }
    }
}