using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Milujeme_plarka.Helpers;
using Milujeme_plarka.Models;
using Milujeme_plarka.Services;
using Milujeme_plarka.Services.Champions;
using Milujeme_plarka.ViewModels;

namespace Milujeme_plarka.Pages.Champions
{
    public class IndexModel : PageModel
    {
        private IChampionService _championService;
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _usermanager;
        private ILogger<IndexModel> _logger;
        private ApplicationUser user;

        public Champion Champion { get; set; }

        public List<Champion> Champions { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public IndexModel(IChampionService championService, ApplicationDbContext db, UserManager<ApplicationUser> userManager, ILogger<IndexModel>logger)
        {
            _championService = championService;
            _db = db;
            _usermanager = userManager;
            _logger = logger;
        }
        public async Task<IActionResult> OnGetRandomAsync()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            user = _usermanager.FindByIdAsync(userId).Result;
            user.ChampionId = _championService.RandChamp();
            _db.SaveChanges();
            return RedirectToPage("./Generated");
        }
        public void OnGet()
        {
            Champions = _db.Champions.OrderBy(r => r.ChampionName).ToList();
        }
    }
}