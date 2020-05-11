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
    public class DetailsModel : PageModel
    {
        [TempData]
        public string StatusMessage { get; set; }
        public DetailsModel(IItemService itemService)
        {
            _itemService = itemService;
        }
        public Item Item{ get; set; }
        private IItemService _itemService;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _itemService.Read(id);

            if (Item == null)
            {
                return NotFound();
            }

            return Page();
        }



        public async Task<IActionResult> OnGetUnclaimAsync(int id)
        {
            var r = _itemService.Read(id).Result;
            if (r == null)
            {
                return NotFound();
            }
            return RedirectToPage("Details", new { id = r.ItemId });
        }
    }
}