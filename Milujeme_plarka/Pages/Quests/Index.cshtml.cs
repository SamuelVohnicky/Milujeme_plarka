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
using Milujeme_plarka.Services.Quests;

namespace Milujeme_plarka.Pages.Quests
{
    public class IndexModel : PageModel
    {
        private IQuestService _questService;
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _usermanager;
        private ILogger<IndexModel> _logger;
        private ApplicationUser user;

        public Quest Quest{ get; set; }

        public List<Quest> Quests { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public IndexModel(IQuestService questService, ApplicationDbContext db, UserManager<ApplicationUser> userManager, ILogger<IndexModel> logger)
        {
            _questService = questService;
            _db = db;
            _usermanager = userManager;
            _logger = logger;
        }
        public async Task<IActionResult> OnGetRandomAsync()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            user = _usermanager.FindByIdAsync(userId).Result;
            user.QuestId = _questService.RandQuest();
            _db.SaveChanges();
            return RedirectToPage("./Generated");
        }
        public void OnGet()
        {
            Quests = _db.Quests.OrderBy(r => r.QuestQuote).ToList();
        }
    }
}