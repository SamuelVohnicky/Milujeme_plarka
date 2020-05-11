using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Milujeme_plarka.Models;
using Milujeme_plarka.Services.Items;

namespace Milujeme_plarka.Pages.Items
{
    public class EditModel : PageModel
    {
        [TempData]
        public string StatusMessage { get; set; }

        public EditModel(IItemService itemService, ApplicationDbContext context)
        {
            _itemService = itemService;
            _context = context;
        }
        [BindProperty]
        public Item Item { get; set; }
        private IItemService _itemService;
        private readonly ApplicationDbContext _context;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = _itemService.Read(id).Result;

            if (Item == null)
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

            var item = _context.Items.Where(r => r.ItemId == Item.ItemId).FirstOrDefault();
            item.ItemName = Item.ItemName;
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}