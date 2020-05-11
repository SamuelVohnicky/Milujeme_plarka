using Milujeme_plarka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milujeme_plarka.Services.Items
{
    public interface IItemService
    {
        Task<Item> Create(Item item, string fileImage);
        Task<Item> Delete(int id);
        Task<Item> Update(int id, Item item);
        Task<Item> Read(int id);
        bool Exists(int id);

        int RandItem();
    }
}
