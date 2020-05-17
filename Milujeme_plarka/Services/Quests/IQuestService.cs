using Milujeme_plarka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milujeme_plarka.Services.Quests
{
    public interface IQuestService
    {
        Task<Quest> Create(Quest quest);
        Task<Quest> Delete(int id);
        Task<Quest> Update(int id, Quest quest);
        Task<Quest> Read(int id);
        bool Exists(int id);
        int RandQuest();
    }
}
