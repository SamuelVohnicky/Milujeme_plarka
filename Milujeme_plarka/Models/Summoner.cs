using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Milujeme_plarka.Models
{
    public class Summoner
    {
        [Key]
        public int SummonerId { get; set; }
        [Required]
        public string SummonerName { get; set; }
        public string Image { get; set; }
    }
}
