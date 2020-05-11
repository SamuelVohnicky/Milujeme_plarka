using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Milujeme_plarka.Models;
using Milujeme_plarka.Services;
using Milujeme_plarka.Services.Champions;
using Milujeme_plarka.Services.Items;

namespace Milujeme_plarka.Pages.Random
{
    
    public class GeneratedModel : PageModel
    {
        private IChampionService _championService;
        private IItemService _itemService;
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _usermanager;
        public Champion Champion;
        public Item Item;


        public GeneratedModel(IChampionService championService, ApplicationDbContext db, UserManager<ApplicationUser> userManager, IItemService itemService)
        {
            _championService = championService;
            _db = db;
            _usermanager = userManager;
            _itemService = itemService;
        }

        private ApplicationUser user { get;set; }

        public void OnGetAsync()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            user = _usermanager.FindByIdAsync(userId).Result;
            Champion = _db.Champions.Find(user.ChampionId);
            Item = _db.Items.Find(user.Item1Id);
        }


        public async Task<IActionResult> OnGetChampAsync()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            user = _usermanager.FindByIdAsync(userId).Result;
            user.ChampionId = _championService.RandChamp();
            user.Item1Id = _itemService.RandItem();
            //user.Item2Id = _itemService.RandItem();
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