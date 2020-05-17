using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Milujeme_plarka.Models;
using System.Threading.Tasks;

namespace Milujeme_plarka.Services.Summoners
{
    public class SummonerService : ISummonerService
    {
        private ApplicationDbContext _db;

        public SummonerService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Summoner> Create(Summoner summoner, string path)
        {
            var newSummoner = new Summoner
            {
                SummonerId = summoner.SummonerId,
                SummonerName = summoner.SummonerName,
                Image = path
            };
            _db.Summoners.Add(newSummoner);
            await _db.SaveChangesAsync();
            return newSummoner;
        }

        public async Task<Summoner> Delete(int id)
        {
            Summoner summoner = await _db.Summoners.Where(b => b.SummonerId == id).FirstOrDefaultAsync();
            if (summoner != null)
            {
                _db.Summoners.Remove(summoner);
                _db.SaveChanges();
            }
            return summoner;
        }

        public async Task<Summoner> Update(int id, Summoner input)
        {
            Summoner summoner = await _db.Summoners.Where(b => b.SummonerId == id).FirstOrDefaultAsync();
            if (summoner != null)
            {
                _db.Attach(summoner).State = EntityState.Modified;
                summoner.SummonerId = input.SummonerId;
                summoner.SummonerName = input.SummonerName;
                _db.SaveChanges();
                return summoner;
            }
            return null;
        }

        private List<Summoner> Summs { get { return _db.Summoners.ToList(); } }

        public List<Summoner> Summoners { get; set; }

        public int RandSumm()
        {
            Summoners = _db.Summoners.ToList();
            Random rndCh = new Random();
            int randCh = rndCh.Next(Summs.Count);
            Summoner summoner = Summoners[randCh];
            return summoner.SummonerId;
        }

        public bool Exists(int id)
        {
            return _db.Summoners.Any(e => e.SummonerId == id);
        }

        public async Task<Summoner> Read(int id)
        {
            var summoner = await _db.Summoners.Where(b => b.SummonerId == id).FirstOrDefaultAsync();
            return summoner;
        }
    }
}
