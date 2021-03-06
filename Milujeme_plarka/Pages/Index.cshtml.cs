﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Milujeme_plarka.Models;
using Milujeme_plarka.Services.Champions;
using Milujeme_plarka.Services.Items;

namespace Milujeme_plarka.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IItemService _itemService;
        private IChampionService _championService;
        private UserManager<ApplicationUser> _usermanager;
        private ApplicationDbContext _db;
        public ApplicationUser user { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IItemService itemService, IChampionService championService, ApplicationDbContext db, UserManager<ApplicationUser>userManager)
        {
            _logger = logger;
            _db = db;
            _usermanager = userManager;
            _championService = championService;
            _itemService = itemService;
        }

        public async Task<IActionResult> OnGetRandomAsync()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            user = _usermanager.FindByIdAsync(userId).Result;
            user.ChampionId = _championService.RandChamp();
            user.Item1Id = _itemService.RandItem();
            _db.SaveChanges();
            return RedirectToPage("./Generated");
        }
    }
}
