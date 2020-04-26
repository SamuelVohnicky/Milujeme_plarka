using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Milujeme_plarka.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int ChampionId { get; set; }
        public int Item1Id { get; set; }
        public int Item2Id { get; set; }
        public int Item3Id { get; set; }
        public int Item4Id { get; set; }
        public int Item5Id { get; set; }
        public int Item6Id { get; set; }
        public int Summoner1Id { get; set; }
        public int Summoner2Id { get; set; }
        public int QuestId { get; set; }

    }
}
