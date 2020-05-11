using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Milujeme_plarka.Models;
using Milujeme_plarka.Services.Items;

namespace Milujeme_plarka.Pages.Items
{
    public class IndexModel : PageModel
    {
        private IItemService _itemService;
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _usermanager;
        private ILogger<IndexModel> _logger;
        private ApplicationUser user;

        public Item Item { get; set; }

        public List<Item> Items { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public IndexModel(IItemService itemService, ApplicationDbContext db, UserManager<ApplicationUser> userManager, ILogger<IndexModel> logger)
        {
            _itemService = itemService;
            _db = db;
            _usermanager = userManager;
            _logger = logger;
        }
        public async Task<IActionResult> OnGetRandomAsync()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            user = _usermanager.FindByIdAsync(userId).Result;
            user.Item1Id = _itemService.RandItem();
            _db.SaveChanges();
            return RedirectToPage("./Generated");
        }
        public void OnGet()
        {
            Items = _db.Items.OrderBy(r => r.ItemName).ToList();
        }
    }
}