using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Milujeme_plarka.Models
{
    public class Champion
    {
        [Key]
        public int ChampionId { get; set; }
        [Required]
        public string ChampionName { get; set; }
        [Required]
        public bool Mellee { get; set; }
    }
}
