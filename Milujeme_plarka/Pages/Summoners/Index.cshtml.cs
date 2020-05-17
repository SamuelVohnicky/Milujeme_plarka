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
using Milujeme_plarka.Services.Summoners;

namespace Milujeme_plarka.Pages.Summoners
{
    public class IndexModel : PageModel
    {
        private ISummonerService _summonerService;
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _usermanager;
        private ILogger<IndexModel> _logger;
        private ApplicationUser user;

        public Summoner Summoner { get; set; }

        public List<Summoner> Summoners { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public IndexModel(ISummonerService itemService, ApplicationDbContext db, UserManager<ApplicationUser> userManager, ILogger<IndexModel> logger)
        {
            _summonerService = itemService;
            _db = db;
            _usermanager = userManager;
            _logger = logger;
        }
        public async Task<IActionResult> OnGetRandomAsync()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            user = _usermanager.FindByIdAsync(userId).Result;
            user.Item1Id = _summonerService.RandSumm();
            _db.SaveChanges();
            return RedirectToPage("./Generated");
        }
        public void OnGet()
        {
            Summoners = _db.Summoners.OrderBy(r => r.SummonerName).ToList();
        }
    }
}