using Microsoft.EntityFrameworkCore;
using Milujeme_plarka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milujeme_plarka.Services.Quests
{
    public class QuestService : IQuestService
    {
        private ApplicationDbContext _db;

        public QuestService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Quest> Create(Quest quest)
        {
            var newQuest = new Quest
            {
                QuestId = quest.QuestId,
                QuestQuote = quest.QuestQuote,
            };
            _db.Quests.Add(newQuest);
            await _db.SaveChangesAsync();
            return newQuest;
        }

        public async Task<Quest> Delete(int id)
        {
            Quest quest = await _db.Quests.Where(b => b.QuestId == id).FirstOrDefaultAsync();
            if (quest != null)
            {
                _db.Quests.Remove(quest);
                _db.SaveChanges();
            }
            return quest;
        }

        public async Task<Quest> Update(int id, Quest input)
        {
            Quest quest= await _db.Quests.Where(b => b.QuestId == id).FirstOrDefaultAsync();
            if (quest != null)
            {
                _db.Attach(quest).State = EntityState.Modified;
                quest.QuestId = input.QuestId;
                quest.QuestQuote = input.QuestQuote;
                _db.SaveChanges();
                return quest;
            }
            return null;
        }

        private List<Quest> Quests { get { return _db.Quests.ToList(); } }

        public List<Quest> Questos { get; set; }

        public int RandQuest()
        {
            Questos = _db.Quests.ToList();
            Random rndQuest = new Random();
            int randQuest = rndQuest.Next(Quests.Count);
            Quest quest = Questos[randQuest];
            return quest.QuestId;
        }

        public bool Exists(int id)
        {
            return _db.Quests.Any(e => e.QuestId == id);
        }

        public async Task<Quest> Read(int id)
        {
            var quest = await _db.Quests.Where(b => b.QuestId == id).FirstOrDefaultAsync();
            return quest;
        }
    }
}
