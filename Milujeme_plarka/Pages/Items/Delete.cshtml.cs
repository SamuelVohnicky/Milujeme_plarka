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
    public class DeleteModel : PageModel
    {
        public Item Item{ get; set; }
        private IItemService _itemService;
        public DeleteModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _itemService.Delete(id);

            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = _itemService.Delete(id).Result;

            if (Item != null)
            {
                await _itemService.Delete(id);
            }
            //System.IO.File.Delete("wwwroot/imgs/" + Champion.Image);
            return RedirectToPage("./Index");
        }
    }
}