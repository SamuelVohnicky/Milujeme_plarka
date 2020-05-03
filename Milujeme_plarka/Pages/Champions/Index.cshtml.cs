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
using Milujeme_plarka.Services;
using Milujeme_plarka.ViewModels;

namespace Milujeme_plarka.Pages.Champions
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;

        public List<Champion> Champions { get; set; }


        [TempData]
        public string StatusMessage { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Champions = _db.Champions.OrderBy(r => r.ChampionName).ToList();
        }
    }
}