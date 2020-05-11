using Microsoft.EntityFrameworkCore;
using Milujeme_plarka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milujeme_plarka.Services.Items
{
    public class ItemService : IItemService
    {
        private ApplicationDbContext _db;

        public ItemService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Item> Create(Item item, string path)
        {
            var newItem = new Item
            {
                ItemId = item.ItemId,
                ItemName = item.ItemName,
                Mellee = item.Mellee,
                Image = path
            };
            _db.Items.Add(newItem);
            await _db.SaveChangesAsync();
            return newItem;
        }

        public async Task<Item> Delete(int id)
        {
            Item item= await _db.Items.Where(b => b.ItemId == id).FirstOrDefaultAsync();
            if (item != null)
            {
                _db.Items.Remove(item);
                _db.SaveChanges();
            }
            return item;
        }

        public async Task<Item> Update(int id, Item input)
        {
            Item item= await _db.Items.Where(b => b.ItemId == id).FirstOrDefaultAsync();
            if (item != null)
            {
                _db.Attach(item).State = EntityState.Modified;
                item.ItemId= input.ItemId;
                item.ItemName= input.ItemName;
                _db.SaveChanges();
                return item;
            }
            return null;
        }

        private List<Item> Items { get { return _db.Items.ToList(); } }

        public List<Item> Itemos { get; set; }

        public int RandItem()
        {
            Itemos = _db.Items.ToList();
            Random rndItem = new Random();
            int randItem = rndItem.Next(Items.Count);
            Item item= Itemos[randItem];
            return item.ItemId;
        }

        public bool Exists(int id)
        {
            return _db.Items.Any(e => e.ItemId == id);
        }

        public async Task<Item> Read(int id)
        {
            var item = await _db.Items.Where(b => b.ItemId == id).FirstOrDefaultAsync();
            return item;
        }
    }
}
