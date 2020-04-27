using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Milujeme_plarka.Helpers;
using Milujeme_plarka.Models;
using Milujeme_plarka.ViewModels;

namespace Milujeme_plarka.Pages.Users
{
    public class IndexModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public PaginatedList<UserViewModel> Users { get; set; }

        public string IdSort { get; set; }
        public string UserNameSort { get; set; }
        public string UserNameFilter { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public List<SelectListItem> Roles { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        public IndexModel(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            Roles = new List<SelectListItem>();
            foreach (var r in _roleManager.Roles.OrderBy(o => o.Name))
            {
                Roles.Add(new SelectListItem(r.Name, Convert.ToString(r.Id)));
            }
        }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            IdSort = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            UserNameSort = (sortOrder == "username") ? "username_desc" : "username";
            UserNameFilter = searchString;
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<UserViewModel> users = _userManager.Users.Select(u =>
            new UserViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
            });

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => (Convert.ToString(s.Id).Contains(searchString) || s.UserName.Contains(searchString)));
            }

            switch (sortOrder)
            {
                case "username":
                    users = users.OrderBy(u => u.UserName);
                    break;
                case "id_desc":
                    users = users.OrderByDescending(u => u.Id);
                    break;
                case "username_desc":
                    users = users.OrderByDescending(u => u.UserName);
                    break;
                default:
                    users = users.OrderBy(u => u.UserName);
                    break;
            }

            Users = await PaginatedList<UserViewModel>.CreateAsync(users.AsNoTracking(), pageIndex ?? 1, 100);
        }
    }
}