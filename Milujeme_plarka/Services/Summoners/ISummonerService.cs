using System;
using Milujeme_plarka.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milujeme_plarka.Services.Summoners
{
    public interface ISummonerService
    {
        Task<Summoner> Create(Summoner summoner, string fileImage);
        Task<Summoner> Delete(int id);
        Task<Summoner> Update(int id, Summoner summoner);
        Task<Summoner> Read(int id);
        bool Exists(int id);

        int RandSumm();
    }
}
