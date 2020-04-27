using Microsoft.EntityFrameworkCore;
using Milujeme_plarka.Models;
using Milujeme_plarka.Services.Champions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milujeme_plarka.Services
{
    public class ChampionService : IChampionService
    {
        private ApplicationDbContext _db;

        public ChampionService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Champion> Create(Champion champion)
        {
            var newChampion = new Champion
            {
                ChampionId = champion.ChampionId,
                ChampionName = champion.ChampionName,
                Mellee = champion.Mellee
            };
            _db.Champions.Add(newChampion);
            await _db.SaveChangesAsync();
            return newChampion;
        }

        public async Task<Champion> Delete(int id)
        {
            Champion champion = await _db.Champions.Where(b => b.ChampionId == id).FirstOrDefaultAsync();
            if (champion != null)
            {
                _db.Champions.Remove(champion);
                _db.SaveChanges();
            }
            return champion;
        }

        public async Task<Champion> Update(int id, Champion input)
        {
            Champion champion = await _db.Champions.Where(b => b.ChampionId == id).FirstOrDefaultAsync();
            if (champion != null)
            {
                _db.Attach(champion).State = EntityState.Modified;
                champion.ChampionId = input.ChampionId;
                champion.ChampionName = input.ChampionName;
                _db.SaveChanges();
                return champion;
            }
            return null;
        }

        private List<Champion> Champs { get; set; }
        public Champion RandChamp()
        {
            Random rndCh = new Random(Champs.Count);
            return Champs[Convert.ToInt32(rndCh)];
        }

        public bool Exists(int id)
        {
            return _db.Champions.Any(e => e.ChampionId == id);
        }

        public async Task<Champion> Read(int id)
        {
            var champion = await _db.Champions.Where(b => b.ChampionId == id).FirstOrDefaultAsync();
            return champion;
        }

        //public async Task<IList<ChampionService>> List(Guid? championId = null, string championName = null, bool mellee = true)
        //{
        //    IQueryable<Champion> champions = _db.Champions;
        //    if (championId != Guid.Empty)
        //        champions = champions.Where(b => (b.ChampionId == championId));
        //    switch()
        //}



    }
}
