using Milujeme_plarka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milujeme_plarka.Services.Champions
{
    public interface IChampionService
    {
        Task<Champion> Create(Champion champion);
        Task<Champion> Delete(int id);
        Task<Champion> Update(int id, Champion champion);
        //Task<IList<Champion>> List(Guid? ChampionId = null, string ChampionName = null, bool mellee = true);
        Task<Champion> Read(int id);
        bool Exists(int id);

        Champion RandChamp();
    }
}
