using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Milujeme_plarka.Models;
using Milujeme_plarka.Services;
using Milujeme_plarka.Services.Champions;


namespace Milujeme_plarka.Pages.Random
{
    
    public class GeneratedModel : PageModel
    {
        private IChampionService _championService;

        public GeneratedModel(IChampionService championService)
        {
            _championService = championService;
        }

        public string Champ = "fsd";

        public void OnGet()
        {
            Champ = _championService.RandChamp().ChampionName;
        }
        public void OnGetChamp()
        {
            Champ = _championService.RandChamp().ChampionName;
        }


        public string Item1 = "1. Item";
        public string Item2 = "2. Item";
        public string Item3 = "3. Item";
        public string Item4 = "4. Item";
        public string Item5 = "5. Item";
        public string Item6 = "6. Item";
        public string Spell1 = "Summoner 1";
        public string Spell2 = "Summoner 2";
        public string Ukol = "Ukol";
        
    }
}