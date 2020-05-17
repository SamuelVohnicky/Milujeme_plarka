using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Milujeme_plarka.Models;
using Milujeme_plarka.Services.Quests;

namespace Milujeme_plarka.Pages.Quests
{
    public class EditModel : PageModel
    {
        [TempData]
        public string StatusMessage { get; set; }

        public EditModel(IQuestService questService, ApplicationDbContext context)
        {
            _questService = questService;
            _context = context;
        }
        [BindProperty]
        public Quest Quest { get; set; }
        private IQuestService _questService;
        private readonly ApplicationDbContext _context;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quest = _questService.Read(id).Result;

            if (Quest == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var quest = _context.Quests.Where(r => r.QuestId == Quest.QuestId).FirstOrDefault();
            quest.QuestQuote = Quest.QuestQuote;
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}