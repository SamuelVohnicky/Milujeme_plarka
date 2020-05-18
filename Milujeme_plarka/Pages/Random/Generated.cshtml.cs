using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Milujeme_plarka.Models;
using Milujeme_plarka.Services;
using Milujeme_plarka.Services.Champions;
using Milujeme_plarka.Services.Items;
using Milujeme_plarka.Services.Quests;
using Milujeme_plarka.Services.Summoners;
using Org.BouncyCastle.Asn1.Mozilla;

namespace Milujeme_plarka.Pages.Random
{
    [Authorize]
    public class GeneratedModel : PageModel
    {
        private IChampionService _championService;
        private IItemService _itemService;
        private IQuestService _questService;
        private ISummonerService _summonerService;
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _usermanager;
        public Champion Champion;
        public Item Item;
        public Quest Quest;
        public Summoner Summoner;


        public GeneratedModel(ISummonerService summonerService,IChampionService championService, ApplicationDbContext db, UserManager<ApplicationUser> userManager, IItemService itemService, IQuestService questService)
        {
            _championService = championService;
            _db = db;
            _usermanager = userManager;
            _itemService = itemService;
            _questService = questService;
            _summonerService = summonerService;
        }

        private ApplicationUser user { get;set; }

        public void OnGetAsync()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            user = _usermanager.FindByIdAsync(userId).Result;
            Champion = _db.Champions.Find(user.ChampionId);
            Item = _db.Items.Find(user.Item1Id);
            Quest = _db.Quests.Find(user.QuestId);
            Summoner = _db.Summoners.Find(user.Summoner1Id);
        }


        public async Task<IActionResult> OnGetChampAsync()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            user = _usermanager.FindByIdAsync(userId).Result;
            user.ChampionId = _championService.RandChamp();
            user.Item1Id = _itemService.RandItem();
            //user.Item2Id = _itemService.RandItem();
            user.QuestId = _questService.RandQuest();
            user.Summoner1Id = _questService.RandQuest();
            _db.SaveChanges();
            return RedirectToPage("Generated");
        }

        public async Task<IActionResult> OnGetTimerAsync()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            user = _usermanager.FindByIdAsync(userId).Result;
            user.QuestId = _questService.RandQuest();
            _db.SaveChanges();
            return RedirectToPage("Generated");
        }

        //public string Item1 = "1. Item";
        //public string Item2 = "2. Item";
        //public string Item3 = "3. Item";
        //public string Item4 = "4. Item";
        //public string Item5 = "5. Item";
        //public string Item6 = "6. Item";
        //public string Spell1 = "Summoner 1";
        //public string Spell2 = "Summoner 2";
        //public string Ukol = "Ukol";

    }
}